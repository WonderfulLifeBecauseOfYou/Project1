using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI�������
/// </summary>
public class UImanager : MonoBehaviour
{
    public static UImanager instance { get; private set; }
    private void Start()
    {
        instance = this;
    }
    public Image healthBar; //��ɫ��Ѫ��
    public Image BosshealthBar;//boss��Ѫ��
    
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
