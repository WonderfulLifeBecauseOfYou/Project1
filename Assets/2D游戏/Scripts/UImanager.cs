using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI各项管理
/// </summary>
public class UImanager : MonoBehaviour
{
    public static UImanager instance { get; private set; }
    private void Start()
    {
        instance = this;
    }
    public Image healthBar; //角色的血条
    public Image BosshealthBar;//boss的血条
    
    public void UpdatahealthBar (int currentamount, int maxamount)
    {
        healthBar.fillAmount = (float)currentamount / (float)maxamount;

    }

    /*
    public void UpdatahealthBarofBoss(int currentamount, int maxamount)
    {
        BosshealthBar.fillAmount = (float)currentamount / (float)maxamount;
    }
    */
}
