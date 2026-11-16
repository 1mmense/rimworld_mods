# Private RimWorld 1.7 compatibility companion

Original mod and credit: YAYO and Soky, https://github.com/DRA-Mods/Yayos-Animation . Briana authorized this private update. Nothing here authorizes a Workshop upload.

The original `yayoAni.dll` is retained byte-for-byte. On the inspected RimWorld 1.7.4980 / Harmony 3 installation, its multi-target reset annotation activated LoadedGame but not StartedNewGame. The small 1.7-only companion restores the missing new-game cache reset by calling the original Reset implementation. It skips when that original-owner patch already exists, and preserves the original Prepatcher exclusion. No animation curves, settings, pawn poses or weapon calculations are rewritten.

`Build.ps1` rebuilds only this companion with existing local compiler/game/Harmony references. It never downloads dependencies or rebuilds the original 1.6 project. A rebuild changes the release DLL hash and requires fresh native verification before installation. Older version folders remain untouched.

Private lab diagnostics, generated saves, test fixtures and captured evidence are outside this candidate package and must not be installed with it. The upstream PublishedFileId is retained in Original, not in this local derivative.

Qualification and limitations are recorded in the parent lab's receipts; this note is not itself a compatibility pass or a claim of support for all third-party integrations.
