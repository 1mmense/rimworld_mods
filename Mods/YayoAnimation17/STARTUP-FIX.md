# Explicit assembly startup fix — 2026-10-17

Yayo initialization now uses `harmony.PatchAll(typeof(Core).Assembly)`.
The bundled ifchen0 tick fix uses `PatchAll(typeof(Init).Assembly)`.
Neither depends on stack-frame inference to identify its own assembly.

The 1.7 compatibility helper independently checks StartedNewGame and LoadedGame,
adding a missing cache-reset postfix only when neither the original owner nor
the compatibility owner already supplies it. The existing Prepatcher exclusion
is retained. This covers the observed native run where only StartedNewGame
received the upstream reset patch. Both lifecycle hooks must reset the cache.

The two upstream DLLs were rebuilt through a narrow Mono.Cecil IL transformation,
not a complete recompilation of the old upstream projects. Matching source edits
are included. All other method instruction streams and assembly references were
checked unchanged. The compatibility helper was compiled from its updated source.
Older version folders are unchanged. Original author attribution and licenses remain.

This addresses the reported assembly-discovery risk. It does not establish that
the reporter's exact intermittent failure was reproduced, or certify every mod
combination. No changes to animation arithmetic, saves, settings or load order are required.
