using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public Slot slotPrefab;
    public Item slotItem;
    public Image slotImage;
    public Text slotNumber;
    public List MysuperBag;

    private int playerStatemode = -1;
    private int playerStatemode2 = -1;
    private int playerStatemode3 = -1;
    private int playerStatemode4 = -1;
    private int playerStatemode5 = -1;
    private int playerStatemode6 = -1;
    private GameObject player;
    private Text num;
    private effect3Buff buffcontroller;
    private MovingT0 playercontroller;
    private bool open = true;//近战武器开关
    private bool open2 = true;//盾牌开关
    private bool open3 = true;//徽章开关
    private bool open4 = true;//项链开关
    private bool open5 = true;//戒指开关


    private Slot newItem;

    private Image a;//备用药品图片
    private float b;//备用药品数量

    //初始值
    private GameObject ringPicture;//戒指图标
    private GameObject neckLacePicture;//项链图标
    private GameObject badgePicture;//徽章图标
    private float startMaxH;
    private float startCurH;
    private float startMagicV;
    private float startEnduranceV;
    private float startAtk1;
    private float startAtk2;
    private float startAttackT;
    private float startBulletT;
    private float startSkillT;
    private float startDef1;
    private float startDef2;
    private void Start()
    {
        num = GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(3).gameObject.GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        buffcontroller = player.gameObject.GetComponent<effect3Buff>();
        playercontroller = player.gameObject.GetComponent<MovingT0>();

        ringPicture = GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).GetChild(3).GetChild(0).gameObject;
        neckLacePicture = GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).GetChild(3).GetChild(2).gameObject;
        badgePicture = GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).GetChild(3).GetChild(1).gameObject;
    }
    public void objectclicked()
    {
        Manager.instance.ObjectInfo(slotItem.info);
        if (slotItem.style == "武器")
        {
            Refresh();
        }else if(slotItem.style == "防具")
        {
            Refresh2();
        }else if(slotItem.style == "技能")
        {
            if(slotItem.style2 == "徽章")
            {
                Refresh3();
            }else if(slotItem.style2 == "项链")
            {
                Refresh4();
            }else if(slotItem.style2 == "戒指")
            {
                Refresh5();
            }
        }else if(slotItem.style == "消耗品")
        {
            if (GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2).childCount == 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2).GetChild(0).gameObject);
                //重新复制
                newItem = Instantiate(slotPrefab, GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2).position, Quaternion.identity);
                newItem.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2));
                newItem.slotItem = slotItem;
                newItem.slotImage.sprite = slotItem.Image;
                newItem.transform.localScale = new Vector3(1, 1, 1);
                num.text = slotItem.number.ToString();
            }
            else
            {
                //复制到快捷栏
                newItem = Instantiate(slotPrefab, GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2).position, Quaternion.identity);
                newItem.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2));
                newItem.slotItem = slotItem;
                newItem.slotImage.sprite = slotItem.Image;
                newItem.transform.localScale = new Vector3(1, 1, 1);
                num.text = slotItem.number.ToString();
            }
            //ReduceDrug();

        }


        changeStste();
        changeState2();
        changeState3();
        changeState4();
        changeState5();
        //changeState6();
        State1();//近战武器状态
        State2();//盾牌状态
        State3();//徽章状态
        State4();//项链状态
        State5();//戒指状态
        //State6();//药品状态
       
    }


    public void State1()
    {
        switch (playerStatemode)
        {
            case 0:
                player.transform.GetChild(0).GetChild(0).gameObject.SetActive(open);
                open = !open;
                break;
            case 1:
                player.transform.GetChild(0).GetChild(1).gameObject.SetActive(open);
                open = !open;
                break;
            case 2:
                player.transform.GetChild(0).GetChild(2).gameObject.SetActive(open);
                open = !open;
                break;
            case 3:
                player.transform.GetChild(0).GetChild(3).gameObject.SetActive(open);
                open = !open;
                break;
            case 4:
                player.transform.GetChild(0).GetChild(4).gameObject.SetActive(open);
                open = !open;
                break;
            case 5:
                player.transform.GetChild(0).GetChild(5).gameObject.SetActive(open);
                open = !open;
                break;
            case 6:
                player.transform.GetChild(0).GetChild(6).gameObject.SetActive(open);
                open = !open;
                break;
            case 7:
                player.transform.GetChild(0).GetChild(7).gameObject.SetActive(open);
                open = !open;
                break;
            case 8:
                player.transform.GetChild(1).GetChild(0).gameObject.SetActive(open);
                open = !open;
                break;
            case 9:
                player.transform.GetChild(1).GetChild(1).gameObject.SetActive(open);
                open = !open;
                break;
            case 10:
                player.transform.GetChild(1).GetChild(2).gameObject.SetActive(open);
                open = !open;
                break;
            case 11:
                player.transform.GetChild(1).GetChild(3).gameObject.SetActive(open);
                open = !open;
                break;
            case 12:
                player.transform.GetChild(2).GetChild(0).gameObject.SetActive(open);
                open = !open;
                break;
            case 13:
                player.transform.GetChild(2).GetChild(1).gameObject.SetActive(open);
                open = !open;
                break;
            case 14:
                player.transform.GetChild(2).GetChild(2).gameObject.SetActive(open);
                open = !open;
                break;
            case 15:
                player.transform.GetChild(2).GetChild(3).gameObject.SetActive(open);
                open = !open;
                break;

        }
    }
    public void State2()
    {
        switch (playerStatemode2)
        {
            case 0:
                player.transform.GetChild(6).GetChild(0).gameObject.SetActive(open2);
                open2 = !open2;
                break;
            case 1:
                player.transform.GetChild(6).GetChild(1).gameObject.SetActive(open2);
                open2 = !open2;
                break;
            case 2:
                player.transform.GetChild(6).GetChild(2).gameObject.SetActive(open2);
                open2 = !open2;
                break;
            case 3:
                player.transform.GetChild(6).GetChild(3).gameObject.SetActive(open2);
                open2 = !open2;
                break;
            case 4:
                player.transform.GetChild(6).GetChild(4).gameObject.SetActive(open2);
                open2 = !open2;
                break;
            case 5:
                player.transform.GetChild(6).GetChild(5).gameObject.SetActive(open2);
                open2 = !open2;
                break;
        }
    }
    public void State3()
    {
        switch (playerStatemode3)
        {
            case 0:
                player.transform.GetChild(3).GetChild(0).gameObject.SetActive(open3);
                //显示图标
                badgePicture.SetActive(open3);
                open3 = !open3;

                badgePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 1:
                player.transform.GetChild(3).GetChild(1).gameObject.SetActive(open3);
                //显示图标
                badgePicture.SetActive(open3);
                open3 = !open3;

                badgePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 2:
                player.transform.GetChild(3).GetChild(2).gameObject.SetActive(open3);
                //显示图标
                badgePicture.SetActive(open3);
                open3 = !open3;

                badgePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            
        }
    }
    public void State4()
    {
        switch (playerStatemode4)
        {
            case 0:
                player.transform.GetChild(4).GetChild(0).gameObject.SetActive(open4);
                //显示图标
                neckLacePicture.SetActive(open4);
                open4 = !open4;

                neckLacePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 1:
                player.transform.GetChild(4).GetChild(1).gameObject.SetActive(open4);
                //显示图标
                neckLacePicture.SetActive(open4);
                open4 = !open4;

                neckLacePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 2:
                player.transform.GetChild(4).GetChild(2).gameObject.SetActive(open4);
                //显示图标
                neckLacePicture.SetActive(open4);
                open4 = !open4;

                neckLacePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;

        }
    }
    public void State5()
    {
        switch (playerStatemode5)
        {

            case 0:
                player.transform.GetChild(5).GetChild(0).gameObject.SetActive(open5);
                //显示图标
                ringPicture.SetActive(open5);
                open5 = !open5;

                ringPicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 1:
                player.transform.GetChild(5).GetChild(1).gameObject.SetActive(open5);
                //显示图标
                ringPicture.SetActive(open5);
                open5 = !open5;

                ringPicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 2:
                player.transform.GetChild(5).GetChild(2).gameObject.SetActive(open5);
                //显示图标
                ringPicture.SetActive(open5);
                open5 = !open5;

                ringPicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;

        }
    }
    public void State6()
    {
        switch (playerStatemode6)
        {
            case 0:
                buffcontroller.Addbuff1();
                
                break;
            case 1:
                if (player.transform.GetChild(7).GetChild(1).gameObject.activeInHierarchy == true) return;
                player.transform.GetChild(7).GetChild(1).gameObject.SetActive(true);
                buffcontroller.Addbuff2();
                
                break;
            case 2:
                if (player.transform.GetChild(7).GetChild(2).gameObject.activeInHierarchy == true) return;
                player.transform.GetChild(7).GetChild(2).gameObject.SetActive(true);
                buffcontroller.Addbuff3();

                break;
            case 3:
                if (player.transform.GetChild(7).GetChild(3).gameObject.activeInHierarchy == true) return;
                player.transform.GetChild(7).GetChild(3).gameObject.SetActive(true);
                buffcontroller.Addbuff4();

                break;
            case 4:
                buffcontroller.Addbuff5();

                break;
            
        }
    }

    //切换近战武器状态
    public void changeStste()
    {
        if(slotItem.Name == "做工精良的铁剑")
        {
            playerStatemode = 0;
        }
        else if(slotItem.Name == "带毒的剑")
        {
            playerStatemode = 1;
        }
        else if (slotItem.Name == "刺客小刀")
        {
            playerStatemode = 2;
        }
        else if (slotItem.Name == "护卫者的长剑")
        {
            playerStatemode = 3;
        }
        else if (slotItem.Name == "骑士大剑")
        {
            playerStatemode = 4;
        }
        else if (slotItem.Name == "雷光剑")
        {
            playerStatemode = 5;
        }
        else if (slotItem.Name == "二叉戟刃")
        {
            playerStatemode = 6;
        }
        else if (slotItem.Name == "木剑")
        {
            playerStatemode = 7;
        }
        else if (slotItem.Name == "粗制石斧")
        {
            playerStatemode = 8;
        }
        else if (slotItem.Name == "双头斧")
        {
            playerStatemode = 9;
        }
        else if (slotItem.Name == "细柄直斧")
        {
            playerStatemode = 10;
        }
        else if (slotItem.Name == "黑骑士大斧")
        {
            playerStatemode = 11;
        }
        else if (slotItem.Name == "粗制铜锤")
        {
            playerStatemode = 12;
        }
        else if (slotItem.Name == "工程锤")
        {
            playerStatemode = 13;
        }
        else if (slotItem.Name == "白银大锤")
        {
            playerStatemode = 14;
        }
        else if (slotItem.Name == "神圣回声")
        {
            playerStatemode = 15;
        }

    }

    //切换盾牌状态
    private void changeState2()
    {
        //盾牌
        if (slotItem.Name == "牢固的木板")
        {
            playerStatemode2 = 0;
        }
        else if (slotItem.Name == "小圆盾")
        {
            playerStatemode2 = 1;
        }
        else if (slotItem.Name == "亚诺尔隆德步兵盾")
        {
            playerStatemode2 = 2;
        }
        else if (slotItem.Name == "魔法师护身盾")
        {
            playerStatemode2 = 3;
        }
        else if (slotItem.Name == "红狮子战士盾牌")
        {
            playerStatemode2 = 4;
        }
        else if (slotItem.Name == "国王近卫军大盾")
        {
            playerStatemode2 = 5;
        }
    }
    //切换徽章状态
    private void changeState3()
    {
        if (slotItem.Name == "蓝色武士徽章")
        {
            playerStatemode3 = 0;
        }
        else if (slotItem.Name == "红色骑兵徽章")
        {
            playerStatemode3 = 1;
        }
        else if (slotItem.Name == "堕落魔女徽章")
        {
            playerStatemode3 = 2;
        }
    }
    //切换项链状态
    private void changeState4()
    {
        if (slotItem.Name == "草纹项链")
        {
            playerStatemode4 = 0;
        }
        else if (slotItem.Name == "熔岩项链")
        {
            playerStatemode4 = 1;
        }
        else if (slotItem.Name == "飓风项链")
        {
            playerStatemode4 = 2;
        }
    }
    //切换戒指状态
    private void changeState5()
    {
        if (slotItem.Name == "幽灵戒指")
        {
            playerStatemode5 = 0;
        }
        else if (slotItem.Name == "大地戒指")
        {
            playerStatemode5 = 1;
        }
        else if (slotItem.Name == "贵族戒指")
        {
            playerStatemode5 = 2;
        }
    }
    //切换药品状态
    private void changeState6()
    {
        if (slotItem.Name == "健康口服液")
        {
            playerStatemode6 = 0;
        }
        else if (slotItem.Name == "加速药水")
        {
            playerStatemode6 = 1;
        }
        else if (slotItem.Name == "攻击药水")
        {
            playerStatemode6 = 2;
        }
        else if (slotItem.Name == "防御药水")
        {
            playerStatemode6 = 3;
        }
        else if (slotItem.Name == "净化药")
        {
            playerStatemode6 = 4;
        }
        
    }

    //近战武器装备状态恢复
    private void Refresh()
    {
        player.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        player.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
        player.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
        player.transform.GetChild(0).GetChild(5).gameObject.SetActive(false);
        player.transform.GetChild(0).GetChild(6).gameObject.SetActive(false);
        player.transform.GetChild(0).GetChild(7).gameObject.SetActive(false);
        player.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        player.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
        player.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        player.transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
        
        
    }

    //盾牌状态恢复
    private void Refresh2()
    {
        player.transform.GetChild(6).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(2).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(3).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
    }

    //徽章状态恢复
    private void Refresh3()
    {
        player.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
        badgePicture.SetActive(false);
    }
    //项链状态恢复
    private void Refresh4()
    {
        player.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
        neckLacePicture.SetActive(false);
    }
    //戒指状态恢复
    private void Refresh5()
    {
        player.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(5).GetChild(2).gameObject.SetActive(false);
        ringPicture.SetActive(false);
    }


    //药品应该被消耗
    void ReduceDrug()
    {
        if(slotItem.number > 1)
        {
            slotItem.number -= 1;
            num.text = slotItem.number.ToString();
        }
        else if(slotItem.number == 1)
        {
            MysuperBag.list.Remove(slotItem);
            Destroy(GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2).GetChild(0).gameObject);
            num.text = "00";
        }
        Manager.instance.RefreshItem();
    }

    //从快捷栏中使用药品
    public void UseDrug()
    {
        ReduceDrug();
        changeState6();
        State6();
    }

}
