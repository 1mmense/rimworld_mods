# Achtung! Expanded

Achtung! Expanded supports RimWorld 1.6 and 1.7. It focuses on better colonist commanding: force work, line formations, multi-colonist orders, and lower-friction moment-to-moment control.

## Install

### Easiest

1. Install Harmony.
2. Download the latest Achtung! Expanded release from:
   `https://github.com/pardeike/Achtung2/releases/latest`
3. Unzip the `Achtung` folder into your RimWorld `Mods` directory.
4. Enable `Harmony` and `Achtung! Expanded` in RimWorld.

Steam Workshop is also available:
`https://steamcommunity.com/sharedfiles/filedetails/?id=730936602`

## Requirements

- RimWorld 1.6 or 1.7
- Harmony (`brrainz.harmony`)

RimWorld 1.7 uses a separate native `net10.0` assembly under `1.7/Assemblies`.
The 1.6 release assembly remains under `1.6/Assemblies`.

## Multiplayer

Achtung 1.6 supports the official
[RimWorld Multiplayer](https://github.com/rwmt/Multiplayer) mod. Multiplayer is
optional; when it is active, Achtung registers its synchronized commands through
MultiplayerAPI and shares gameplay-affecting Achtung settings through the save.

The compatibility layer covers drafting and undrafting, formation movement,
force work, thorough room cleaning, firefighting, portal entry, cancellation,
deterministic background expansion, and late-join restoration. Visual
preferences remain local to each player.

All players must use the same Rescue setting before starting a Multiplayer
session and leave it unchanged until the session ends. Rescue adds or removes a
work type, so changing it while a game is hosted is not supported.

Load Prepatcher and Multiplayer according to Multiplayer's own requirements.
Achtung declares Multiplayer as an optional `loadAfter` dependency.

## Build From Source

```bash
git clone https://github.com/pardeike/Achtung2.git
cd Achtung2
env -u RIMWORLD_MOD_DIR ./scripts/build-quiet.sh -c Release
./scripts/build-quiet.sh -c Release -p:RIMWORLD_MOD_DIR=/path/to/RimWorld/Mods
```

Build the native 1.7 assembly against the local game installation with:

```bash
dotnet build Source/Achtung17.csproj -c Release \
  -p:RIMWORLD_GAME_DIR=/path/to/RimWorld
dotnet build Source/Achtung17.csproj -c Release \
  -p:RIMWORLD_GAME_DIR=/path/to/RimWorld \
  -p:RIMWORLD_MOD_DIR=/path/to/RimWorld/Mods
```

The first command builds without deploying. The second deploys the mod with
both version folders. BridgeTools targets 1.6 and is deployed by the 1.6 project.
A deploy build refuses to overwrite a running RimWorld process.
See [TESTING.md](TESTING.md) for the live test workflow.

## What The Mod Adds

- Force-work commands that keep important jobs moving
- Better multi-colonist command handling
- Formation and line movement tools
- Smarter drafting and undrafting behavior around issued commands
- Utility commands such as room cleaning, firefighting, and sowing workflows

## Live Developer Workflow

The reproducible mod-debugging stack is:

1. `Achtung2` for the mod under test
2. `RimBridgeServer` for live RimWorld inspection and control
3. `GABS` for starting RimWorld and exposing the bridge tools cleanly to an AI client
4. `DecompilerServer` for reading RimWorld's managed assemblies while debugging job flow

The companion DLL under `Source/BridgeTools` contains named, reusable contracts
that exercise Achtung against a running game. The main project restores and
builds it automatically. Build, deploy, lifecycle, required mod configuration,
and contract details are documented in [TESTING.md](TESTING.md).

Toolchain projects:

- RimBridgeServer: `https://github.com/pardeike/RimBridgeServer`
- GABS: `https://github.com/pardeike/GABS`
- DecompilerServer: `https://github.com/pardeike/DecompilerServer`

## Notes

- Achtung! is designed to minimize save dependencies, but an active custom Achtung job can still be serialized into a save. If you want to remove the mod cleanly from a save, cancel current Achtung jobs first and save again.
- Force-work jobs are intentionally aggressive. They are meant for priority intervention, not soft scheduling.

## Feedback

- GitHub: `https://github.com/pardeike/Achtung2`
- Steam Workshop: `https://steamcommunity.com/sharedfiles/filedetails/?id=730936602`
- Ludeon Forums: `https://ludeon.com/forums/index.php?topic=22130.0`

## License

Free as in free beer. Copy, learn, and be respectful.
