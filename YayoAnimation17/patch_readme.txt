[h1]20 October 2026 — Custom Job Facing Fix[/h1]
[list]
[*]Updated the bundled Tick Fix with ifchen0's custom-job facing repair. Stationary pawns now visibly turn when a custom JobDriver changes direction through Pawn.Rotation or FaceTarget().
[*]The repair refreshes only indefinitely cached standing-job results when their facing changes. Scheduled animations and lying poses retain their chosen direction.
[*]Retained the tick-overflow arithmetic correction, explicit-assembly Harmony startup fix, and new-game/load animation-cache resets.
[*]Verified on native RimWorld 1.7.4982 rev1280 / Harmony 3: all 37 native checks passed, including both turning APIs in all four directions before and after private save/reload, preservation of scheduled-animation facing, and 1,080 tick-arithmetic cases.
[/list]
[b]Scope:[/b] The updated DLL targets native RimWorld 1.7. Older version folders are unchanged. Prepatcher-enabled operation and the full player mod stack have not been validated.

Thanks to seeki for the detailed report and to ifchen0 for the upstream repair. Original animation credits remain YAYO and Soky; copyright, source and license notices are retained. Enable this bundled package without also enabling the separate Yayo or Tick Fix copies.

