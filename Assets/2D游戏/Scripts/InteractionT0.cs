using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 和第一个图的npc1接触时
/// </summary>
public class InteractionT0 : MonoBehaviour
{
    public float showTime = 4;
    public float showTimer;
    private bool BOSSdied;
    public GameObject TipImage;//UI提示
    public GameObject dialogImage;//对话
    public GameObject GoodJob;
    // Start is called before the first frame update
    void Start()
    {
        TipImage.SetActive(true);
        dialogImage.SetActive(false);//对话框默认隐藏
        showTimer = -1;
    }

    // Update is called once per frame
    void Update()
    {
        showTimer -= Time.deltaTime;
        if(showTimer < 0 )
        {
            TipImage.SetActive(true);
            dialogImage.SetActive (false);
            GoodJob.SetActive(false);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        MovingT0 pc = other.GetComponent<MovingT0>();
        if (pc != null)
        {
            //Debug.Log("您好，欢迎来后死后世界!");
        }
    }

    public void ShowDialog()
    {
        if (BOSSdied == false)
        {
            showTimer = showTime;
            TipImage.SetActive(false);
            dialogImage.SetActive(true);
        }

        if(BOSSdied == true)
        {
            showTimer = showTime;
            TipImage.SetActive (false);
            dialogImage.SetActive(false);
            GoodJob.SetActive(true);
        }
    }




    public void IfBOOSDied()
    {
        BOSSdied = true;
    }
}
