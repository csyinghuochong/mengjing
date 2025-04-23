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
			self.View.E_TextTip_3Text.text = GlobalValueConfigCategory.Instance.SingleHappyBuyCost.ToString();

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

		public static void ShowTimes(this DlgSingleHappyMain self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentS = unit.GetComponent<NumericComponentC>();
			
			long remainTimes = numericComponentS.GetAsLong(NumericType.SingleHappyRemainTimes);
			Log.Debug($"ShowTimes....remainTimes:  {remainTimes}");
			self.View.E_TextTip_4Text.text = $"{remainTimes}/{GlobalValueConfigCategory.Instance.SingleHappyInitTimes}";
		}
		

		private static void ShowCD(this DlgSingleHappyMain self)
		{
			self.View.E_TextTip_1Text.text = string.Empty;
			self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
			self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UISingleHappyMoveTimer, self);

			self.SingleHappyTimer();
		}

		public static void SingleHappyTimer(this DlgSingleHappyMain self)
		{
			DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
			long cursecond = (dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second) * TimeHelper.Second;
			long singlerecover = GlobalValueConfigCategory.Instance.SingleHappyrecoverTime;
			//计算下个恢复时间点
			long leftTime = singlerecover - cursecond % singlerecover;
			
			self.View.E_TextTip_1Text.text = TimeHelper.FormatSecondsToTime(leftTime);
		}
		
		private static async  ETTask OnuttonMove_1Button(this DlgSingleHappyMain self)
		{
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentS = unit.GetComponent<NumericComponentC>();

			int remainTimes = numericComponentS.GetAsInt(NumericType.SingleHappyRemainTimes);
			if (remainTimes <= 0)
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
			int buyCost = GlobalValueConfigCategory.Instance.SingleHappyBuyCost;
			int buyadd =  GlobalValueConfigCategory.Instance.SingleHappyBuyAdd;
			UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
			if (userInfoComponent.UserInfo.Diamond < buyCost)
			{
				FlyTipComponent.Instance.ShowFlyTip("钻石不足!");
				return;
			}
			Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
			NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
			int remainTimes = numericComponentC.GetAsInt(NumericType.SingleHappyRemainTimes);
			if (remainTimes + GlobalValueConfigCategory.Instance.SingleHappyBuyAdd > GlobalValueConfigCategory.Instance.SingleHappyInitTimes)
			{
				FlyTipComponent.Instance.ShowFlyTip("次数溢出，建议少于5次再购买!");
				return;
			}

			int buyTimes = numericComponentC.GetAsInt(NumericType.SingleBuyTimes);
			if (buyTimes >= GlobalValueConfigCategory.Instance.SingleHappyBuyMax)
			{
				FlyTipComponent.Instance.ShowFlyTip("购买次数不足!");
				return;
			}

			PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", $"是否花费{buyCost}钻石增加{buyadd}次？", () =>
			{
				self.SingleHappyRequestBuyTimes().Coroutine();
			}, null).Coroutine();
		}

		private static async ETTask SingleHappyRequestBuyTimes(this DlgSingleHappyMain self)
		{
			M2C_SingleHappyOperateResponse response = await ActivityNetHelper.SingleHappyOperateRequest( self.Root(),3);
			if (response == null || self.IsDisposed || response.Error!= ErrorCode.ERR_Success)
			{
				return;
			}

			FlyTipComponent.Instance.ShowFlyTip("购买次数成功!");
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
