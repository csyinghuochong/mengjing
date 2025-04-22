using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	
	[Invoke(TimerInvokeType.UISingleHappyMoveTimer)]
	public class UISingleHappyMoveTimer : ATimer<DlgSingleHappyMain>
	{
		protected override void Run(DlgSingleHappyMain self)
		{
			try
			{
				self.SingleHappyTimer();
			}
			catch (Exception e)
			{
				using (zstring.Block())
				{
					Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
				}
			}
		}
	}
	
	[FriendOf(typeof(DlgSingleHappyMain))]
	public static  class DlgSingleHappyMainSystem
	{

		public static void RegisterUIEvent(this DlgSingleHappyMain self)
		{
			
			self.View.E_ButtonMove_1Button.AddListenerAsync( self.OnuttonMove_1Button );
			self.View.E_ButtonMove_2Button.AddListener( self.OnuttonMove_2Button );
			self.View.E_ButtonMove_3Button.AddListener( self.OnuttonMove_3Button );
			self.View.E_ButtonExplain.AddListener( self.OnButtonExplain );


			self.View.E_TextTip_2Text.text = GlobalValueConfigCategory.Instance.Get(132).Value;
			self.View.E_TextTip_3Text.text = GlobalValueConfigCategory.Instance.Get(133).Value;

			self.ShowTimes();
			self.ShowCD();
		}

		public static void HideWindow(this DlgSingleHappyMain self)
		{
			self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
		}

		public static void ShowWindow(this DlgSingleHappyMain self, Entity contextData = null)
		{
		}

		private static void ShowTimes(this DlgSingleHappyMain self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentS = unit.GetComponent<NumericComponentC>();

			int mianfeitimes = int.Parse(GlobalValueConfigCategory.Instance.Get(130).Value);
			int extendTimes =  int.Parse(GlobalValueConfigCategory.Instance.Get(131).Value);
			int buyTimes = numericComponentS.GetAsInt(NumericType.SingleBuyTimes);

			int moveTimes = numericComponentS.GetAsInt(NumericType.SingleHappyMoveTimes);
			int recoverTimes = CommonHelp.GetHappyRecoverTimes(TimeHelper.ServerNow(), extendTimes);

			//int canmoveTimes = mianfeitimes + recoverTimes + buyTimes - moveTimes;
			self.View.E_TextTip_4Text.text = $"{moveTimes}/{mianfeitimes + buyTimes + recoverTimes }";
		}
		
		private static void ShowCD(this DlgSingleHappyMain self)
		{
			self.View.E_TextTip_1Text.text = string.Empty;
			self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            
			int extendTimes =  int.Parse(GlobalValueConfigCategory.Instance.Get(131).Value);
			
			int recoverTimes = CommonHelp.GetHappyRecoverTimes(TimeHelper.ServerNow(), extendTimes);

			if (extendTimes <= recoverTimes)
			{
				return;
			}

			DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
			if (dateTime.Hour >= extendTimes)
			{
				return;
			}

			int leftSeond = (60 - dateTime.Minute) * 60 + dateTime.Second;
			self.RecoverTime = TimeHelper.ServerNow() + leftSeond * TimeHelper.Second;
			self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
			self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UISingleHappyMoveTimer, self);

			self.SingleHappyTimer();
		}

		public static void SingleHappyTimer(this DlgSingleHappyMain self)
		{
			long leftTimer = self.RecoverTime - TimeHelper.ServerNow();
			if (leftTimer > 0)
			{
				self.View.E_TextTip_1Text.text = TimeHelper.FormatSecondsToTime(leftTimer);
			}
			else
			{
				self.ShowCD();
			}
		}


		private static async  ETTask OnuttonMove_1Button(this DlgSingleHappyMain self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentS = unit.GetComponent<NumericComponentC>();

			int mianfeitimes = int.Parse(GlobalValueConfigCategory.Instance.Get(130).Value);
			int extendTimes =  int.Parse(GlobalValueConfigCategory.Instance.Get(131).Value);
			int buyTimes = numericComponentS.GetAsInt(NumericType.SingleBuyTimes);

			int moveTimes = numericComponentS.GetAsInt(NumericType.SingleHappyMoveTimes);
			int recoverTimes = CommonHelp.GetHappyRecoverTimes(TimeHelper.ServerNow(), extendTimes);

			int canmoveTimes = mianfeitimes + recoverTimes + buyTimes - moveTimes;

			if (canmoveTimes <= 0)
			{
				FlyTipComponent.Instance.ShowFlyTip("当前没有免费的次数！");
				return;
			}

		 	await ActivityNetHelper.SingleHappyOperateRequest( self.Root(),1 );
		    if (self.IsDisposed)
		    {
			    return;
		    }
		    self.ShowTimes();
		    self.OnButtonPick();
		}
		
		public static void OnButtonPick(this DlgSingleHappyMain self)
		{
			if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) <= 0)
			{
				HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_BagIsFull);
				return;
			}

			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			int cellindex = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.SingleHappyCellIndex);

			List<Unit> units = MapHelper.GetCanShiQuByCell(self.Root(), cellindex);
			if (units.Count > 0)
			{
				self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainSkill.RequestShiQu(units).Coroutine();

				//播放音效
				CommonViewHelper.PlayUIMusic("10004");
				return;
			}
		}

		
		private static  void OnuttonMove_2Button(this DlgSingleHappyMain self)
		{
			GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(132);
			UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
			if (userInfoComponent.UserInfo.Diamond < int.Parse(globalValueConfig.Value))
			{
				FlyTipComponent.Instance.ShowFlyTip("钻石不足!");
				return;
			}
			PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", $"是否花费{globalValueConfig.Value}钻石刷新奖励？", () =>
			{
				self.SingleHappyRequestRefresh().Coroutine();
			}, null).Coroutine();
			
		}

		private static async ETTask SingleHappyRequestRefresh(this DlgSingleHappyMain self)
		{
			M2C_SingleHappyOperateResponse response = await ActivityNetHelper.SingleHappyOperateRequest( self.Root(),2 );
			if (response == null || self.IsDisposed)
			{
				return;
			}

			self.OnButtonPick();
		}
        
		private static  void OnuttonMove_3Button(this DlgSingleHappyMain self)
		{
			GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(133);
			UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
			if (userInfoComponent.UserInfo.Diamond < int.Parse(globalValueConfig.Value))
			{
				FlyTipComponent.Instance.ShowFlyTip("钻石不足!");
				return;
			}

			
			PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", $"是否花费{globalValueConfig.Value}钻石刷新奖励？", () =>
			{
				self.SingleHappyRequestBuyTimes().Coroutine();
			}, null).Coroutine();
		}

		private static async ETTask SingleHappyRequestBuyTimes(this DlgSingleHappyMain self)
		{
			M2C_SingleHappyOperateResponse response = await ActivityNetHelper.SingleHappyOperateRequest( self.Root(),3);
			if (response == null || self.IsDisposed)
			{
				return;
			}

			self.ShowTimes();
		}

		private static void OnButtonExplain(this DlgSingleHappyMain self)
		{
			PopupTipHelp.OpenPopupTip_2(self.Root(), "系统提示",
				"1.每1小时额外恢复一次次数！\n" +
				"2.每天凌晨重置恢复5次次数！\n" +
				"3.钻石可以购买次数！",
				null).Coroutine();
		}
		 

	}
}
