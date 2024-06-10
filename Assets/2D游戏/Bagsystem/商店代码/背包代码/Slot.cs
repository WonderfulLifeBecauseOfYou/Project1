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
    private bool open = true;//��ս��������
    private bool open2 = true;//���ƿ���
    private bool open3 = true;//���¿���
    private bool open4 = true;//��������
    private bool open5 = true;//��ָ����


    private Slot newItem;

    private Image a;//����ҩƷͼƬ
    private float b;//����ҩƷ����

    //��ʼֵ
    private GameObject ringPicture;//��ָͼ��
    private GameObject neckLacePicture;//����ͼ��
    private GameObject badgePicture;//����ͼ��
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
        if (slotItem.style == "����")
        {
            Refresh();
        }else if(slotItem.style == "����")
        {
            Refresh2();
        }else if(slotItem.style == "����")
        {
            if(slotItem.style2 == "����")
            {
                Refresh3();
            }else if(slotItem.style2 == "����")
            {
                Refresh4();
            }else if(slotItem.style2 == "��ָ")
            {
                Refresh5();
            }
        }else if(slotItem.style == "����Ʒ")
        {
            if (GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2).childCount == 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2).GetChild(0).gameObject);
                //���¸���
                newItem = Instantiate(slotPrefab, GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2).position, Quaternion.identity);
                newItem.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("UI").transform.GetChild(1).GetChild(2));
                newItem.slotItem = slotItem;
                newItem.slotImage.sprite = slotItem.Image;
                newItem.transform.localScale = new Vector3(1, 1, 1);
                num.text = slotItem.number.ToString();
            }
            else
            {
                //���Ƶ������
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
        State1();//��ս����״̬
        State2();//����״̬
        State3();//����״̬
        State4();//����״̬
        State5();//��ָ״̬
        //State6();//ҩƷ״̬
       
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
                //��ʾͼ��
                badgePicture.SetActive(open3);
                open3 = !open3;

                badgePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 1:
                player.transform.GetChild(3).GetChild(1).gameObject.SetActive(open3);
                //��ʾͼ��
                badgePicture.SetActive(open3);
                open3 = !open3;

                badgePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 2:
                player.transform.GetChild(3).GetChild(2).gameObject.SetActive(open3);
                //��ʾͼ��
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
                //��ʾͼ��
                neckLacePicture.SetActive(open4);
                open4 = !open4;

                neckLacePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 1:
                player.transform.GetChild(4).GetChild(1).gameObject.SetActive(open4);
                //��ʾͼ��
                neckLacePicture.SetActive(open4);
                open4 = !open4;

                neckLacePicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 2:
                player.transform.GetChild(4).GetChild(2).gameObject.SetActive(open4);
                //��ʾͼ��
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
                //��ʾͼ��
                ringPicture.SetActive(open5);
                open5 = !open5;

                ringPicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 1:
                player.transform.GetChild(5).GetChild(1).gameObject.SetActive(open5);
                //��ʾͼ��
                ringPicture.SetActive(open5);
                open5 = !open5;

                ringPicture.GetComponent<Image>().sprite = slotImage.sprite;
                break;
            case 2:
                player.transform.GetChild(5).GetChild(2).gameObject.SetActive(open5);
                //��ʾͼ��
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

    //�л���ս����״̬
    public void changeStste()
    {
        if(slotItem.Name == "��������������")
        {
            playerStatemode = 0;
        }
        else if(slotItem.Name == "�����Ľ�")
        {
            playerStatemode = 1;
        }
        else if (slotItem.Name == "�̿�С��")
        {
            playerStatemode = 2;
        }
        else if (slotItem.Name == "�����ߵĳ���")
        {
            playerStatemode = 3;
        }
        else if (slotItem.Name == "��ʿ��")
        {
            playerStatemode = 4;
        }
        else if (slotItem.Name == "�׹⽣")
        {
            playerStatemode = 5;
        }
        else if (slotItem.Name == "�������")
        {
            playerStatemode = 6;
        }
        else if (slotItem.Name == "ľ��")
        {
            playerStatemode = 7;
        }
        else if (slotItem.Name == "����ʯ��")
        {
            playerStatemode = 8;
        }
        else if (slotItem.Name == "˫ͷ��")
        {
            playerStatemode = 9;
        }
        else if (slotItem.Name == "ϸ��ֱ��")
        {
            playerStatemode = 10;
        }
        else if (slotItem.Name == "����ʿ��")
        {
            playerStatemode = 11;
        }
        else if (slotItem.Name == "����ͭ��")
        {
            playerStatemode = 12;
        }
        else if (slotItem.Name == "���̴�")
        {
            playerStatemode = 13;
        }
        else if (slotItem.Name == "������")
        {
            playerStatemode = 14;
        }
        else if (slotItem.Name == "��ʥ����")
        {
            playerStatemode = 15;
        }

    }

    //�л�����״̬
    private void changeState2()
    {
        //����
        if (slotItem.Name == "�ι̵�ľ��")
        {
            playerStatemode2 = 0;
        }
        else if (slotItem.Name == "СԲ��")
        {
            playerStatemode2 = 1;
        }
        else if (slotItem.Name == "��ŵ��¡�²�����")
        {
            playerStatemode2 = 2;
        }
        else if (slotItem.Name == "ħ��ʦ�����")
        {
            playerStatemode2 = 3;
        }
        else if (slotItem.Name == "��ʨ��սʿ����")
        {
            playerStatemode2 = 4;
        }
        else if (slotItem.Name == "�������������")
        {
            playerStatemode2 = 5;
        }
    }
    //�л�����״̬
    private void changeState3()
    {
        if (slotItem.Name == "��ɫ��ʿ����")
        {
            playerStatemode3 = 0;
        }
        else if (slotItem.Name == "��ɫ�������")
        {
            playerStatemode3 = 1;
        }
        else if (slotItem.Name == "����ħŮ����")
        {
            playerStatemode3 = 2;
        }
    }
    //�л�����״̬
    private void changeState4()
    {
        if (slotItem.Name == "��������")
        {
            playerStatemode4 = 0;
        }
        else if (slotItem.Name == "��������")
        {
            playerStatemode4 = 1;
        }
        else if (slotItem.Name == "쫷�����")
        {
            playerStatemode4 = 2;
        }
    }
    //�л���ָ״̬
    private void changeState5()
    {
        if (slotItem.Name == "�����ָ")
        {
            playerStatemode5 = 0;
        }
        else if (slotItem.Name == "��ؽ�ָ")
        {
            playerStatemode5 = 1;
        }
        else if (slotItem.Name == "�����ָ")
        {
            playerStatemode5 = 2;
        }
    }
    //�л�ҩƷ״̬
    private void changeState6()
    {
        if (slotItem.Name == "�����ڷ�Һ")
        {
            playerStatemode6 = 0;
        }
        else if (slotItem.Name == "����ҩˮ")
        {
            playerStatemode6 = 1;
        }
        else if (slotItem.Name == "����ҩˮ")
        {
            playerStatemode6 = 2;
        }
        else if (slotItem.Name == "����ҩˮ")
        {
            playerStatemode6 = 3;
        }
        else if (slotItem.Name == "����ҩ")
        {
            playerStatemode6 = 4;
        }
        
    }

    //��ս����װ��״̬�ָ�
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

    //����״̬�ָ�
    private void Refresh2()
    {
        player.transform.GetChild(6).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(2).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(3).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
        player.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
    }

    //����״̬�ָ�
    private void Refresh3()
    {
        player.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
        badgePicture.SetActive(false);
    }
    //����״̬�ָ�
    private void Refresh4()
    {
        player.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
        neckLacePicture.SetActive(false);
    }
    //��ָ״̬�ָ�
    private void Refresh5()
    {
        player.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(5).GetChild(2).gameObject.SetActive(false);
        ringPicture.SetActive(false);
    }


    //ҩƷӦ�ñ�����
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

    //�ӿ������ʹ��ҩƷ
    public void UseDrug()
    {
        ReduceDrug();
        changeState6();
        State6();
    }

}
