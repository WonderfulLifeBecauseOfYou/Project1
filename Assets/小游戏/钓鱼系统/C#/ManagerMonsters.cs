using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ManagerMonsters : MonoBehaviour
{
    [Header("����ˢ��ʱ��")]
    [Tooltip("��ɫ�ɶ�")]
    public GameObject a1;
    [Tooltip("��ɫ�ɶ�")]
    public GameObject a2;
    [Tooltip("��ɫ�ɳ�")]
    public GameObject a3;
    [Tooltip("�����")]
    public GameObject a4;
    [Tooltip("������")]
    public GameObject a5;
    [Tooltip("ëë��")]
    public GameObject a6;
    [Tooltip("С��")]
    public GameObject a7;
    [Tooltip("С��")]
    public GameObject a8;
    [Tooltip("����")]
    public GameObject a9;
    [Tooltip("������")]
    public GameObject a10;
    [Tooltip("��Ԩ���")]
    public GameObject a11;
    [Tooltip("����³")]
    public GameObject a12;


    private Vector2 b1;
    private Vector2 b2;
    private Vector2 b3;
    private Vector2 b4;
    private Vector2 b5;
    private Vector2 b6;
    private Vector2 b7;
    private Vector2 b8;
    private Vector2 b9;
    private Vector2 b10;
    private Vector2 b11;
    private Vector2 b12;
    float CreatTime1 = 0f;
    float CreatTime2= 0f;
    float CreatTime3 = 0f;
    float CreatTime4 = 0f;
    float CreatTime5 = 15;
    float CreatTime6 = 20;
    float CreatTime7 = 27;
    float CreatTime8 = 37;
    float CreatTime9 = 90;
    float CreatTime10 = 110;
    float CreatTime11 = 100;
    float CreatTime12 = 200f;
    //�͵��������λ����
    private float x1;
    private float y1;
    // Start is called before the first frame update
    void Start()
    {
        b1 = a1.transform.position;
        b2 = a2.transform.position;
        b3 = a3.transform.position;
        b4 = a4.transform.position;
        b5 = a5.transform.position;
        b6 = a6.transform.position;
        b7 = a7.transform.position;
        b8 = a8.transform.position;
        b9 = a9.transform.position;
        b10 = a10.transform.position;
        b11 = a11.transform.position;
        b12 = a12.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");
        int enemyCount = enemies.Length;
        if (enemyCount > 14) return;

        CreatTime1 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime2 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime3 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime4 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime5 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime6 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime7 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime8 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime9 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime10 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime11 -= Time.deltaTime;    //��ʼ����ʱ
        CreatTime12 -= Time.deltaTime;    //��ʼ����ʱ
        if (CreatTime1 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime1 = Random.Range(8, 17);     //���8��17����
            GameObject obj1 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster14");    //����ëë��
            a6 = Instantiate(obj1);
            a6.transform.position = new Vector2(b6.x + x1, b6.y);    //������ɹ����λ��
        }
        if (CreatTime2 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime2 = Random.Range(8, 17);     //���8��17����
            GameObject obj2 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster3");    //���ɻ�ɫ�ɶ�
            a2 = Instantiate(obj2);
            a2.transform.position = new Vector2(b2.x + x1, b2.y + y1);    //������ɹ����λ��
        }
        if (CreatTime3 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime3 = Random.Range(8, 17);     //���8��17����
            GameObject obj3 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster11");    //���ɻ�ɫ�ɶ�
            a1 = Instantiate(obj3);
            a1.transform.position = new Vector2(b1.x + x1, b1.y + y1);    //������ɹ����λ��
        }
        if (CreatTime4 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime4 = Random.Range(8, 17);     //���8��17����
            GameObject obj4 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster6");    //���ɺ����
            a4 = Instantiate(obj4);
            a4.transform.position = new Vector2(b4.x + x1, b4.y + y1);    //������ɹ����λ��
        }
        if (CreatTime5 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime5 = Random.Range(20, 40);     //���25��40����
            GameObject obj5 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster2");    //������ɫ�ɳ�
            a3 = Instantiate(obj5);
            a3.transform.position = new Vector2(b3.x + x1, b3.y + y1);    //������ɹ����λ��
        }
        if (CreatTime6 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime6 = Random.Range(20, 40);     //���25��40����
            GameObject obj6 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster18");    //���ɻ�����
            a5 = Instantiate(obj6);
            a5.transform.position = new Vector2(b5.x + x1, b5.y + y1);    //������ɹ����λ��
        }
        if (CreatTime7 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime7 = Random.Range(20, 40);     //���25��40����
            GameObject obj7 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster16");    //��������
            a9 = Instantiate(obj7);
            a9.transform.position = new Vector2(b9.x + x1, b9.y + y1);    //������ɹ����λ��
        }
        if (CreatTime8 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime8 = Random.Range(20, 40);     //���25��40����
            GameObject obj8 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster9");    //����С��
            a8 = Instantiate(obj8);
            a8.transform.position = new Vector2(b8.x + x1, b8.y + y1);    //������ɹ����λ��
        }
        if (CreatTime9 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime9 = Random.Range(90, 140);     //���60��140����
            GameObject obj9 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster8");    //����С��
            a7 = Instantiate(obj9);
            a7.transform.position = new Vector2(b7.x + x1, b7.y + y1);    //������ɹ����λ��
        }
        if (CreatTime10 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime10 = Random.Range(90, 140);     //���60��140����
            GameObject obj10 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster20");    //������Ԩ��
            a11 = Instantiate(obj10);
            a11.transform.position = new Vector2(b11.x, b11.y);    //������ɹ����λ��
        }
        if (CreatTime11 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime11 = Random.Range(90, 140);     //���60��140����
            GameObject obj11 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster7");    //����������
            a10 = Instantiate(obj11);
            a10.transform.position = new Vector2(b10.x + x1, b10.y);    //������ɹ����λ��
        }

        
        if (CreatTime12 <= 0)    //�������ʱΪ0 ��ʱ��
        {
            CreatTime12 = 200;     //200s
            GameObject obj12 = (GameObject)Resources.Load("prefabs/bagsystem1/��������/monster15");    //����Boss 
            a12 = Instantiate(obj12);
            a12.transform.position = new Vector2(b12.x, b12.y);    //���ɹ����λ��
           
        }


    }
}
