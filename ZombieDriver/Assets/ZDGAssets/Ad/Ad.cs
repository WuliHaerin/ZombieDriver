using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieDriveGame;



public class Ad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void ClickBtn()
    {
        AdManager.ShowVideoAd("kfg3f9292eg41lvjpm",
            (bol) => {
                if (bol)
                {
                    if (ZDGGameController.instance.playerObject.health <= 0 && ZDGGameController.instance.playerObject.fuel <= 0)
                    {
                        ZDGGameController.instance.ChangeHealth(ZDGGameController.instance.playerObject.healthMax);
                        ZDGGameController.instance.ChangeFuel(ZDGGameController.instance.playerObject.fuelMax);
                    }
                    else if (ZDGGameController.instance.playerObject.health<=0 && ZDGGameController.instance.playerObject.fuel > 0)
                    {
                        ZDGGameController.instance.ChangeHealth(ZDGGameController.instance.playerObject.healthMax);
                    }
                    else if(ZDGGameController.instance.playerObject.fuel<=0 && ZDGGameController.instance.playerObject.health > 0)
                    {
                        ZDGGameController.instance.ChangeFuel(ZDGGameController.instance.playerObject.fuelMax);
                    }
                    ZDGGameController.instance.StopCoroutines();
                    ClosePanel();

                    AdManager.clickid = "";
                    AdManager.getClickid();
                    AdManager.apiSend("game_addiction", AdManager.clickid);
                    AdManager.apiSend("lt_roi", AdManager.clickid);


                }
                else
                {
                    StarkSDKSpace.AndroidUIManager.ShowToast("观看完整视频才能获取奖励哦！");
                }
            },
            (it, str) => {
                Debug.LogError("Error->" + str);
                //AndroidUIManager.ShowToast("广告加载异常，请重新看广告！");
            });

    }


    public void ClosePanel()
    {
        ZDGGameController.instance.SetAdPanel(false);
    }

}
