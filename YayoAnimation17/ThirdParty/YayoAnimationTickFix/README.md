# Bundled tick overflow and facing-cache corrections

Yayo Animation Tick Overflow Fix by ifchen0, with local integration changes and a custom-job facing-cache repair in the 1.7 Assemblies folder.
Source: https://github.com/ifchen0/YayoAnimationTickFix
Workshop: https://steamcommunity.com/sharedfiles/filedetails/?id=3813339062
Retained source, MIT LICENSE and NOTICE accompany this distribution. Original Yayo animation credits remain YAYO and Soky.

Includes ifchen0's 2026-10-20 custom-job repair. A prefix on AnimationCore.CheckAni invalidates an indefinitely cached standing-job result only when its cached facing differs from the current rendering rotation. Original CheckAni then recomputes the facing. Scheduled animations and lying poses retain their chosen direction. Both Pawn.Rotation and Pawn_RotationTracker.FaceTarget() are covered when rendering next checks the pawn. No rotation-setter hook remains. See LOCAL-CHANGES.md for provenance and build instructions.

Native 1.7 DLL version: 1.0.2.0. SHA256: E58E93C1E17017BB1E1D2CC803CA3B7325CCCB54535B382D1A12922F6A6F55DA.

Verified on RimWorld 1.7.4982 rev1280 / Harmony 3: 37 native checks passed, including an actual custom JobDriver turning through both APIs, native render arguments, private save/reload, preservation of scheduled-animation facing, lifecycle resets, and 1,080 arithmetic cases. The original baseline failed the six expected stale-facing checks. A later control exposed an overbroad setter-hook override; that intermediate build is superseded. Older version folders are unchanged; this new DLL was built and tested only for the native 1.7 runtime. Prepatcher-enabled operation and a full mod stack were not tested.

Do not also enable the separate Tick Overflow Fix mod: this package already includes its assembly. The package ID of the installed local copy remains com.yayo.yayoAni.continued.briana17 so the existing stack entry continues to work. No additional mod-list entry is needed.
