# Local 1.7 integration changes

## Current release: upstream custom-job repair, native assembly 1.0.2.0

2026-10-20: Adopted the narrower CheckAni prefix from ifchen0's same-day Workshop update (3813339062). It invalidates a standing job's indefinitely cached result only if fixedRot exists and differs from the rendering rotation, setting nextUpdateTick to int.MinValue so the original CheckAni recomputes it. Scheduled animations keep their own facing. The initial local setter-hook implementation below is superseded and removed from this package.

The added scheduled-animation control rejected the intermediate setter build (Baseline04-ScheduledPose: 27 PASS, 1 FAIL). Fixed02-UpstreamFacing passed all 37 checks. Final Fixed03-PoseGuardCoverage also passed all 37, with the scheduled and lying controls strengthened to invoke the patched render/CheckAni path and assert both facing and timer preservation. Final exit 0, zero matched native errors and zero protected changes. Both turning APIs, four directions before and after private save/reload, same-value and lying controls, ten existing hooks, lifecycle resets, 21 remainder replacements and 1,080 arithmetic cases passed. This is native RimWorld 1.7.4982 rev1280 / Harmony 3 with official expansions; full player stack and Prepatcher-enabled operation remain untested.

Source provenance: the installed Workshop Source/Patch.cs was captured and hashed in Development/YayosAnimation-1.7/Workshop-20261020/UpstreamWorkshopCapture. GitHub master at 55983535df5c68a90501f2298f7adee9ab443242 did not yet contain this change, so it is not claimed as the source of the new prefix. CustomJobFacingPatch.cs retains the upstream prefix body. Patch.cs retains the prior explicit PatchAll(typeof(Init).Assembly) integration and unchanged arithmetic/transpiler implementation. Original license and notices remain. The animation-core and lifecycle-helper DLLs and older version folders retain their bytes.

Current DLL SHA256: E58E93C1E17017BB1E1D2CC803CA3B7325CCCB54535B382D1A12922F6A6F55DA. Source/Build-1.7.ps1 reproduces this native-only DLL. Publication receipts are separate from these package notes; the earlier local build's publication status below is historical.

## Superseded local setter-hook build, assembly 1.0.1.0

2026-10-20: Added PawnRotationPatch.cs. A Harmony prefix records the original rotation; a postfix on the Thing.Rotation setter updates the public PawnDataUtility.GetData(pawn).fixedRot when a living, spawned, standing pawn actually changes to a valid rotation. This repairs stationary custom jobs whose unknown job name selects an indefinite animation cache. It also catches FaceTarget(), which calls the same setter. Same-value assignments, lying poses, non-pawn things and unspawned pawns are excluded. The hook changes only fixedRot; it does not reset the job name, offsets or next-update schedule.

The tick-fix DLL was freshly compiled from the complete small bundled source with the new hook. Patch.cs is unchanged from the 2026-10-17 integration baseline; the positive-remainder algorithm, two transpilers and explicit PatchAll(typeof(Init).Assembly) call are retained. The separate animation-core and lifecycle-helper DLLs retain their prior bytes. Build with Source/Build-1.7.ps1 against the installed native 1.7 runtime and Harmony 3; NativeVersion.cs sets assembly version 1.0.1.0 for that build only. The upstream .NET Framework project remains supplied for provenance; it is not the build recipe for this native DLL. No new 1.6 build is supplied.

Native evidence: Development/YayosAnimation-1.7/FacingCache-20261020/Baseline03 and Fixed01. Baseline: 21 passing checks and six stale-facing failures. Fixed: 36 passing checks, zero failures, native exit 0, zero matched native errors, zero protected file changes. Both rotation APIs were exercised inside a real custom JobDriver in all four directions, before and after private save/reload. The effective render prefix and actual native render invocation agreed with the pawn rotation. Existing ten hooks, new-game/load cache resets, 21 remainder replacements and 1,080 arithmetic cases passed. Official expansions were enabled. Metadata and native shutdown warnings remain; Prepatcher-enabled operation, unrelated animation integrations and the full player mod stack are unverified.

Current DLL SHA256: F6095A98EAE3858646AEAFD027BA3334C8C4BDCAF7F415F1169D71B8B4A7F11C. Original ifchen0 copyright, MIT LICENSE and NOTICE are retained. The reported failure mechanism and setter-hook suggestion were supplied by the user, including seeki's follow-up report about stationary custom jobs. These local changes have not been submitted to the upstream author or published to Steam.

## Earlier integration baseline

2026-10-17: Init now calls `PatchAll(typeof(Init).Assembly)` instead of relying on Harmony's calling-stack assembly inference. No arithmetic or animation transpiler code was changed. Original ifchen0 attribution, LICENSE and NOTICE remain intact.

That earlier 1.7 DLL was rebuilt with a narrow Mono.Cecil call-site transformation of the prior DLL, matching the source change. Build and native verification evidence is maintained in Development/YayosAnimation-1.7/Evidence/ExplicitAssemblyFix. It is superseded by the native build described above.
