// using Unity.Mathematics;
//
// namespace ET.Server
// {
//     public class AI_PetMelee_PetTarget : AAIHandler
//     {
//         public override int Check(AIComponent aiComponent, AIConfig aiConfig)
//         {
//             if (aiComponent.TargetID != 0)
//             {
//                 return 1;
//             }
//
//             Unit unit = aiComponent.GetParent<Unit>();
//             Unit nearest = GetTargetHelpS.GetNearestEnemy(unit, aiComponent.ActRange, true);
//             if (nearest != null && !aiComponent.IsRetreat)
//             {
//                 aiComponent.TargetZhuiJi = unit.Position;
//                 aiComponent.TargetID = nearest.Id;
//                 return 1;
//             }
//
//             return 0;
//         }
//
//         public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
//         {
//             Unit unit = aiComponent.GetParent<Unit>();
//
//             while (true)
//             {
//                 await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(1000, cancellationToken);
//                 if (cancellationToken.IsCancel())
//                 {
//                     return;
//                 }
//             }
//         }
//     }
// }