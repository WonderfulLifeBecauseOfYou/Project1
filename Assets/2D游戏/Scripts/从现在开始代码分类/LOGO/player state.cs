using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class playerstate : MonoBehaviour
{
    private MovingT0 player;
    private Transform stateUI;

    private TextMeshProUGUI num1;
    private TextMeshProUGUI num2;
    private TextMeshProUGUI num3;
    private TextMeshProUGUI num4;
    private TextMeshProUGUI num5;
    private TextMeshProUGUI num6;
    private TextMeshProUGUI num7;
    private TextMeshProUGUI num8;
    private TextMeshProUGUI num9;
    private TextMeshProUGUI num10;
    private TextMeshProUGUI num11;
    private TextMeshProUGUI num12;
    private TextMeshProUGUI num13;
    private TextMeshProUGUI num14;
    private Text num15;
    private TextMeshProUGUI num01;
    // Start is called before the first frame update
    void Start()
    {
        stateUI = GetComponent<Transform>();
        //开始获取
        num1 = stateUI.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        num2 = stateUI.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        num3 = stateUI.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        num4 = stateUI.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        num5 = stateUI.GetChild(0).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>();
        num6 = stateUI.GetChild(0).GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
        num7 = stateUI.GetChild(0).GetChild(6).GetChild(0).GetComponent<TextMeshProUGUI>();
        num8 = stateUI.GetChild(0).GetChild(7).GetChild(0).GetComponent<TextMeshProUGUI>();
        num9 = stateUI.GetChild(0).GetChild(8).GetChild(0).GetComponent<TextMeshProUGUI>();
        num10 = stateUI.GetChild(0).GetChild(9).GetChild(0).GetComponent<TextMeshProUGUI>();
        num11 = stateUI.GetChild(0).GetChild(10).GetChild(0).GetComponent<TextMeshProUGUI>();
        num12 = stateUI.GetChild(0).GetChild(11).GetChild(0).GetComponent<TextMeshProUGUI>();
        num13 = stateUI.GetChild(0).GetChild(12).GetChild(0).GetComponent<TextMeshProUGUI>();
        num14 = stateUI.GetChild(0).GetChild(13).GetChild(0).GetComponent<TextMeshProUGUI>();
        num15 = stateUI.GetChild(5).GetChild(0).GetChild(0).GetComponent<Text>();
        num01 = stateUI.GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        stateConttroll();
    }

    void stateConttroll()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<MovingT0>();
        num1.text = player.currentHealth.ToString();
        num2.text = player.speed.ToString();
        num3.text = player.state.ToString();
        num4.text = player.atk1.ToString();
        num5.text = player.atk2.ToString();
        num6.text = player.def1.ToString();
        num7.text = player.def2.ToString();
        num8.text = player.bulletTime.ToString();
        num9.text = player.skillTime.ToString();
        num10.text = player.attackTime.ToString();
        num11.text = player.magicValues.ToString();
        num12.text = player.EnduranceValues.ToString();
        num13.text = player.smart.ToString();
        num14.text = player.belief.ToString();
        num15.text = player.level.ToString();
        num01.text = player.maxHealth.ToString();
    }
}
