﻿using FantasyRPG;

public class PanelStage : PanelBase
{
    public Navicontrol navicontrol;
    
    public void Click_Prev()
    {
        navicontrol.Prev();
    }

    public void Click_Next()
    {
        navicontrol.Next();
    }

    public void Click_Stage()
    {
        PlayManager.Instance.LoadScene(Data.scene_play);
    }
}
