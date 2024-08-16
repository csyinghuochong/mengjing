﻿using UnityEngine;

namespace ET.Client
{
    public static class TowerOfSealHelpr
    {
        /// <summary>
        /// 封印之塔摇色子
        /// </summary>
        /// <param name="root"></param>
        /// <param name="costType"></param>
        public static async ETTask StartPlayDice(Scene root, int costType)
        {
            // 生成骰子
            var path = ABPathHelper.GetUnitPath("Component/shaizi");
            var bundleGameObject = await root.GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, GlobalComponent.Instance.Unit);
            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(root);
            // 初始位置
            gameObject.transform.position = (Vector3)myUnit.Position + new Vector3(0, 3f, 0);

            // 给骰子随机一个向上的力和扭力
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Vector3 force = new Vector3(0, Random.Range(5f, 10f), 0);
            Vector3 torque = new Vector3(Random.Range(-8f, 8f), Random.Range(-8f, 8f), Random.Range(-8f, 8f));
            rb.AddForce(force, ForceMode.Impulse);
            rb.AddTorque(torque, ForceMode.Impulse);

            TimerComponent timerComponent = root.GetComponent<TimerComponent>();

            long startTime = TimeInfo.Instance.ServerNow();
            await timerComponent.WaitAsync(1000);
            while (TimeInfo.Instance.ServerNow() - startTime < 5000 && rb.angularVelocity.magnitude > 0.1f)
            {
                await timerComponent.WaitAsync(1000);
            }

            // 算出骰子结果
            Vector3[] vertices = new Vector3 [8];
            BoxCollider diceCollider = gameObject.GetComponent<BoxCollider>();
            var bounds = diceCollider.bounds;
            Vector3 diceCenter = bounds.center;

            float dicex = bounds.size.x;
            float dicey = bounds.size.y;
            float dicez = bounds.size.z;

            //下面四个点
            vertices[0] = diceCenter + new Vector3(dicex, -dicey, dicez) * 0.5f;
            vertices[1] = diceCenter + new Vector3(-dicex, -dicey, dicez) * 0.5f;
            vertices[2] = diceCenter + new Vector3(-dicex, -dicey, -dicez) * 0.5f;
            vertices[3] = diceCenter + new Vector3(dicex, -dicey, -dicez) * 0.5f;

            //上面四个点
            vertices[4] = diceCenter + new Vector3(dicex, dicey, dicez) * 0.5f;
            vertices[5] = diceCenter + new Vector3(-dicex, dicey, dicez) * 0.5f;
            vertices[6] = diceCenter + new Vector3(-dicex, dicey, -dicez) * 0.5f;
            vertices[7] = diceCenter + new Vector3(dicex, dicey, -dicez) * 0.5f;

            Vector3[] newVertices = new Vector3 [8];
            for (int i = 0; i < newVertices.Length; i++)
            {
                newVertices[i] = diceCollider.transform.TransformPoint(vertices[i]);
            }

            float newVertice_0_y = Mathf.Round(newVertices[0].y);
            float newVertice_1_y = Mathf.Round(newVertices[1].y);
            float newVertice_2_y = Mathf.Round(newVertices[2].y);
            float newVertice_3_y = Mathf.Round(newVertices[3].y);
            float newVertice_4_y = Mathf.Round(newVertices[4].y);
            float newVertice_5_y = Mathf.Round(newVertices[5].y);
            float newVertice_6_y = Mathf.Round(newVertices[6].y);
            float newVertice_7_y = Mathf.Round(newVertices[7].y);

            int diceResult = 0;

            if (newVertice_0_y > newVertice_3_y && newVertice_1_y > newVertice_2_y && newVertice_4_y > newVertice_7_y &&
                newVertice_5_y > newVertice_6_y)
            {
                diceResult = 1;
            }

            if (newVertice_4_y > newVertice_0_y && newVertice_5_y > newVertice_1_y && newVertice_6_y > newVertice_2_y &&
                newVertice_7_y > newVertice_3_y)
            {
                diceResult = 6;
            }

            if (newVertice_1_y > newVertice_0_y && newVertice_2_y > newVertice_3_y && newVertice_5_y > newVertice_4_y &&
                newVertice_6_y > newVertice_7_y)
            {
                diceResult = 2;
            }

            if (newVertice_0_y > newVertice_1_y && newVertice_3_y > newVertice_2_y && newVertice_4_y > newVertice_5_y &&
                newVertice_7_y > newVertice_6_y)
            {
                diceResult = 5;
            }

            if (newVertice_0_y > newVertice_4_y && newVertice_1_y > newVertice_5_y && newVertice_2_y > newVertice_6_y &&
                newVertice_3_y > newVertice_7_y)
            {
                diceResult = 4;
            }

            if (newVertice_2_y > newVertice_1_y && newVertice_3_y > newVertice_0_y && newVertice_6_y > newVertice_5_y &&
                newVertice_7_y > newVertice_4_y)
            {
                diceResult = 3;
            }

            // 销毁骰子
            UnityEngine.Object.Destroy(gameObject);

            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("骰子点数是:{0}", diceResult));
            }

            int finished = myUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.SealTowerFinished);
            if (finished % 10 + diceResult > 10 && finished + diceResult <= 100)
            {
                await root.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TowerOfSealJump);
                root.GetComponent<UIComponent>().GetDlgLogic<DlgTowerOfSealJump>().InitUI(diceResult, costType);
            }
            else
            {
                C2M_TowerOfSealNextRequest request = C2M_TowerOfSealNextRequest.Create();
                request.DiceResult = diceResult;
                request.CostType = costType;

                int error = await ActivityNetHelper.TowerOfSealNextRequest(root, diceResult, costType);
                if (error != ErrorCode.ERR_Success)
                {
                    FlyTipComponent.Instance.ShowFlyTip("操作错误！！");
                    return;
                }

                // 更新面板信息
                root.GetComponent<UIComponent>().GetDlgLogic<DlgTowerOfSealMain>().UpdateInfo();
            }
        }
    }
}