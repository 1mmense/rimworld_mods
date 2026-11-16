# Writing social interactions (RimWorld 1.6 and 1.7)

Open Mod Settings > Interaction Bubbles > Social interaction frequency.
The default is 2x; use 1x for vanilla or up to 5x for more frequent random
interaction attempts. This divides vanilla mean time between random attempts;
it does not guarantee exactly twice as many successful conversations. Normal
social modes, the minimum cooldown, recipient availability, distance and other
vanilla eligibility checks still apply. It affects all pawns using the random
interaction tracker, not only colonists. It works even if bubbles are hidden.

## Where to write your phrases

Edit `Common/Patches/Interactions_Social.xml` in this source folder. Search for
`defName="Chitchat"`, `DeepTalk`, `Slight`, `Insult` or `KindWords`.
Within the corresponding `logRulesInitiator` value, edit the `<rulesStrings>`
list or add more `<li>` entries. All initial phrases are the game's original
text; no new dialogue has been written for you.

A complete sentence is a rule beginning `r_logentry->` followed by YOUR TEXT.
Use `[INITIATOR_nameDef]` for the speaker and `[RECIPIENT_nameDef]` for the
other pawn. Square brackets refer to grammar rules; plain text is literal.
You can also add variants to existing subrules such as `talkedabout`.
`(p=4)` gives a rule a relative weight of 4, not a 4 percent chance.
Escape XML punctuation: `&amp;` for &, `&lt;` for <, `&gt;` for >.
These rules change the social log as well as the displayed bubbles.
The copied English rules can override localized social text.

When SpeakUp or SpeakUp Child is active, the five `logRulesInitiator`
replacements automatically skip. Write dialogue in those mods' rule packs instead;
their child-specific conditions and conversation reply tags are preserved.
The thought, XP, fight-chance and relationship edits here still apply.
With neither mod active, these replacement phrases work as usual.

The patches also expose existing initiatorThought and recipientThought links,
socialFightBaseChance where present, and social XP amounts. These are real
interaction effects; sentences alone do not choose relationship outcomes.
Changing an insult's text to a compliment does not make it a positive interaction.

Bubble backgrounds turn green only when the interaction actually grants or
refreshes positive mood memories, and red for negative mood memories. Opinion changes alone
stay neutral. The colour uses effective MoodOffset values from the memories that
survive the interaction, including linked memories such as InsultedMood and
KindWordsMood. Existing unchanged memories do not affect the colour. If both
participants receive mood effects, their contributions are added to choose the
colour; a zero total keeps the default. Interactions outside the normal
TryInteractWith flow stay neutral when their outcome cannot be established.
When SpeakUp compatibility is active, lines without a measured mood effect can
instead use a conservative English phrase match on the actual resolved dialogue:
clearly hostile wording is red and clearly friendly wording is green. Mixed,
negated, quoted, reported or unrecognized wording stays neutral. This includes
common SpeakUp Child phrases and does not change pawn moods or relationships.
Tinted bubbles use black text, with inline name colours removed so the whole
sentence stays black. Neutral bubbles retain their configured text colour.
The background receives a subtle red or green tint
(18% blend) from the mood effect, including when the pawn is selected.
Neutral bubbles keep their configured background. Borders, hover opacity and
fading retain their existing behavior. Adjust MoodBackgroundTint in Bubble.cs
to change the tint strength.
Selected and unselected pawns share the same base background colour, so opening
the Social tab does not add a yellow selection highlight to bubbles.

Left-click a visible bubble to select its speaker, open the Social tab, and
scroll to that exact conversation in the log. Pawns without a Social tab show
a notification instead.

The default font size is 12, using normal text rendering without a stroke or
extra thickening.

## Where to change relationships

Edit `Common/Patches/Social_Relationships.xml`. Every initial value matches the
installed RimWorld 1.7.4990 definitions:

| Social memory | Base opinion change |
| --- | ---: |
| Chitchat | +0.66 per memory, cumulative cap +10 |
| DeepTalk | +15 |
| Slighted | -5 |
| Insulted | -15 |
| KindWords | +15 |

`baseOpinionOffset` changes how the pawn holding the memory views the other
pawn. `durationDays` controls how long the memory lasts, when explicitly set.
`stackLimitForSameOtherPawn` limits repeated memories about the same pawn;
`stackedEffectMultiplier` reduces the effect of subsequent stacked memories.
Chitchat uses its own cumulative memory class and maxCumulatedOpinionOffset.
InsultedMood and KindWordsMood control the linked mood changes (-5 and +5),
which are distinct from opinion. Traits and other vanilla rules still apply.
Chitchat and DeepTalk give thoughts to both participants. Slights, insults and
kind words give the configured thought to the recipient.

These patches retain the existing definition names. Do not copy the entire
vanilla Defs file into the mod, since that would introduce duplicate defs.
Other mods patching the same fields may override these values based on load order.

## Testing bubbles in Development mode

Enable Development mode, open the debug actions menu (the same menu used to
spawn things), and search for `Conversation:` under `Interaction Bubbles`.
Choose random, neutral, negative mood, or positive mood. The action selects two
random eligible colonists on the current map, applies the interaction's real
social thoughts and linked mood memories, and adds the normal generated text to
the play log and bubble. Neutral tests use Chitchat/DeepTalk, negative tests use
Insult, and positive tests use KindWords.

The test pauses the game and jumps the camera to the speaker. It bypasses
distance, jobs, trait-based interaction selection, and conversation cooldowns;
memory eligibility and mood effects still apply. These actions change pawn
memories in your current game. They do not run interaction workers or start
social fights. Repeated tests can stay neutral if memory stack limits prevent a
new or refreshed mood effect; the notification reports the actual result.
Bubble display must be enabled; normal zoom/display limits still apply.

## Applying edits

Edit the source files above, then run `./build.sh --no-link` to rebuild/package.
The existing local mod link loads `dist/`, so editing source alone does not
change the installed content. Restart RimWorld after XML or DLL edits. Do not
edit files under dist: the next build replaces them. Base game files remain
untouched. Both supported versions (1.6 and 1.7) load the same patches from
Common/Patches and compile the same C# source for their respective runtimes.
