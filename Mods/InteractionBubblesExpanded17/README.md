# Interaction Bubbles

Supports RimWorld **1.6 and 1.7 only**. Both versions compile the same
source and share conversation customizations, frequency settings, relationship
effects, and mood-based bubble background tints with black text.

Use this mod instead of the original Interaction Bubbles (`jaxe.bubbles`),
which is declared incompatible to avoid loading both together.

SpeakUp and SpeakUp Child compatibility switches on automatically when either
mod is active, and off when neither is active. No compatibility setting is needed.
Our five replacement dialogue packs yield to their dialogue and reply rules;
frequency, relationship effects, mood colours and clickable bubbles remain available.
SpeakUp replies without a measured mood effect also receive a red or green tint
when their resolved wording contains a clear hostile or friendly phrase, including
common SpeakUp Child wording. Mixed signals, negation, reported speech and
unrecognized wording stay neutral. This is conservative English phrase matching;
it does not infer the tone of every possible sentence or translation.
Dialogue resolves when an interaction is logged, so SpeakUp replies do not depend
on rendering a bubble or viewing the speaker's map. These two mods can also accept
Expanded as their original Interaction Bubbles dependency while Expanded is running;
Workshop files are never edited. Restart after changing the active mod list.
SpeakUp Child is a dialogue add-on and still needs SpeakUp's conversation engine.
Enabling Child alone activates our compatibility guard but cannot supply that engine.

The installed SpeakUp (2502518544) and SpeakUp Child (2785687159) dialogue
definitions were inspected for this integration. In-game conversation testing
remains required. Their own support for
RimWorld 1.7 is separate from Bubbles' compatibility.

For conversation frequency and handwritten social text/relationship edits, see
[SOCIAL_EDITING.md](SOCIAL_EDITING.md). These additions apply to both supported versions.

Local RimWorld 1.6/1.7 port (compiled against 1.6.4871 references and installed
build 1.7.4990). The C# source
in `Source/` was recovered from the supplied Jaxe v4.2 assembly using ILSpy,
then adapted to the game's .NET 10 runtime and Unity compatibility assemblies.
Original author: [Jaxe](https://github.com/Jaxe-Dev/Bubbles).

## Uploading to Steam Workshop

1. Run `./build-all.sh` to build both versions and update the local mod link.
2. Start RimWorld through Steam while logged into your account, and enable
   Development mode in Options.
3. Open Mods and select the local **Interaction Bubbles Expanded** entry.
   Choose **More actions > Upload to Steam Workshop** and follow the prompts.
4. Check the resulting listing's description and visibility on Steam.

The uploader uses `dist/`, containing both supported versions, the shared
patches, and `About/Preview.png`. The source tree, build outputs, and game
reference assemblies are excluded from the upload package.

This fork starts without a PublishedFileId so the first upload creates your
own listing. RimWorld writes the new ID to `dist/About/PublishedFileId.txt`.
Subsequent builds copy it into `About/PublishedFileId.txt` and preserve it in
the package; use **Update on Steam Workshop** for later releases. Keep that ID
when moving the project to another computer. If source and package IDs differ,
the build stops so you can choose the correct listing without losing either ID.

From this folder, run:

```bash
./build-all.sh         # Build 1.6 and 1.7, package dist/, and update the mod link
./restart.sh           # Close RimWorld, wait for it to exit, then launch via Steam
./restart.sh --build   # Build and update the link before restarting
```

Save your game before restarting. The restart script sends SIGTERM and waits up
to 30 seconds; if the game stays open, it stops without launching another copy.
It never forces a kill. It launches RimWorld if the game was already closed.

The build requires the .NET 10 SDK, installed RimWorld 1.7, and Harmony's 1.6
and 1.7 assemblies (Workshop subscription 2009463077). Steam libraries are discovered
automatically. Override paths when needed:

```bash
RIMWORLD_DIR='/path/to/steamapps/common/RimWorld' \
HARMONY_DLL='/path/to/Harmony/1.7/Assemblies/0Harmony.dll' ./build.sh
```

`dist/` contains all runtime files, including shared textures/translations,
metadata, `1.6/Assemblies/Bubbles.dll` (.NET Framework 4.7.2), and
`1.7/Assemblies/Bubbles.dll` (.NET 10). `LoadFolders.xml` selects one version's DLL and the shared assets.
Game and Harmony assemblies are referenced locally and are not bundled.
The 1.6 build uses the Krafs.RimWorld.Ref 1.6.4871 NuGet reference package
and .NET Framework reference assemblies. The first build needs these packages
in the NuGet cache or network access; subsequent builds work offline. Both
Harmony 1.6 and 1.7 assemblies are required. Set HARMONY16_DLL if its 1.6 DLL
is not alongside Harmony 1.7 in the standard version folders. `./build.sh` forwards to `./build-all.sh` for compatibility.

The default link is `RimWorld/Mods/Interaction Bubbles (1.7)` pointing to this
folder's `dist/`. Set `RIMWORLD_MOD_LINK` to override that destination, or use
`./build.sh --no-link` to package only. Existing folders or links pointing
elsewhere are never overwritten. If the Steam directory is read-only inside an
editor sandbox, run `./build.sh` from your normal terminal to create the link.
Enable the local Interaction Bubbles mod with Harmony loaded first.

Compilation, reflected patch targets/private fields, and packaged load folders
have been checked against 1.7.4990. Visual behavior still needs an in-game check.
The 1.6 build is compiled against reference assemblies; its patch targets and
private field names are checked against those references. In-game 1.6 behavior,
including the frequency transpiler and XML patch application, still needs a
check in an actual 1.6 installation.

![Mod Version](https://img.shields.io/badge/Mod_Version-4.2-blue)
![RimWorld Version](https://img.shields.io/badge/Built_for_RimWorld-1.6%20%26%201.7-blue)
![Harmony Version](https://img.shields.io/badge/Powered_by_Harmony-2.4.0-blue)\
[![Steam Subscribers](https://img.shields.io/steam/downloads/1516158345?color=blue&label=Steam%20Downloads&logo=Steam)](https://steamcommunity.com/sharedfiles/filedetails/?id=1516158345)
[![GitHub Downloads](https://img.shields.io/github/downloads/Jaxe-Dev/Bubbles/total?color=blue&label=GitHub%20Downloads&logo=GitHub)](https://github.com/Jaxe-Dev/Bubbles)

[Link to Steam Workshop page](https://steamcommunity.com/sharedfiles/filedetails/?id=1516158345)\
[Link to Ludeon Forum thread](https://ludeon.com/forums/index.php?topic=45958.0)

[![Chat on Discord](https://img.shields.io/badge/Chat_on_Discord-_-_?style=social&logo=Discord)](https://discord.gg/VvSnYQ8)\
[![Donate via PayPal](https://img.shields.io/badge/Donate_via_PayPal-_-_?style=social&logo=PayPal)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=6RS7DLLGCJT8L)\
[![Support on Patreon](https://img.shields.io/badge/Support_via_Patreon-_-_?style=social&logo=Patreon)](https://www.patreon.com/jaxe)

---

Shows bubbles when pawns perform a social interaction with the text that would normally only be found in the log.

Bubbles will fade away after a short time but they are linked to the game time so pausing the game will halt the bubble from fading. Hovering over a bubble makes it nearly transparent. Left-clicking a bubble selects its speaker, opens the Social tab, and scrolls to that conversation in the log. Use the toggle button in the play settings area to disable bubbles from being shown.

---

##### STEAM INSTALLATION
- **[Go to the Steam Workshop page](https://steamcommunity.com/sharedfiles/filedetails/?id=1516158345]) and subscribe to the mod.**

##### NON-STEAM INSTALLATION
- **[Download the latest release](https://github.com/Jaxe-Dev/Bubbles/releases/latest) and unzip it into your *RimWorld/Mods* folder.**

---

The following base methods are patched with Harmony:
```
Postfix : RimWorld.PlaySettings.DoPlaySettingsGlobalControls
Postfix : RimWorld.MapInterface.MapInterfaceOnGUI_BeforeMainTabs
Postfix : Verse.PlayLog.Add
Prefix  : Verse.Profile.MemoryUtility.ClearAllMapsAndWorld
```

