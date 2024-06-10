using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ManagerMonsters : MonoBehaviour
{
    [Header("怪物刷新时间")]
    [Tooltip("黄色飞蛾")]
    public GameObject a1;
    [Tooltip("灰色飞蛾")]
    public GameObject a2;
    [Tooltip("紫色飞虫")]
    public GameObject a3;
    [Tooltip("海洋草")]
    public GameObject a4;
    [Tooltip("火骷髅")]
    public GameObject a5;
    [Tooltip("毛毛虫")]
    public GameObject a6;
    [Tooltip("小红")]
    public GameObject a7;
    [Tooltip("小黄")]
    public GameObject a8;
    [Tooltip("乌贼")]
    public GameObject a9;
    [Tooltip("爬行者")]
    public GameObject a10;
    [Tooltip("深渊大虫")]
    public GameObject a11;
    [Tooltip("克苏鲁")]
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
    //低等生物随机位置数
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

        CreatTime1 -= Time.deltaTime;    //开始倒计时
        CreatTime2 -= Time.deltaTime;    //开始倒计时
        CreatTime3 -= Time.deltaTime;    //开始倒计时
        CreatTime4 -= Time.deltaTime;    //开始倒计时
        CreatTime5 -= Time.deltaTime;    //开始倒计时
        CreatTime6 -= Time.deltaTime;    //开始倒计时
        CreatTime7 -= Time.deltaTime;    //开始倒计时
        CreatTime8 -= Time.deltaTime;    //开始倒计时
        CreatTime9 -= Time.deltaTime;    //开始倒计时
        CreatTime10 -= Time.deltaTime;    //开始倒计时
        CreatTime11 -= Time.deltaTime;    //开始倒计时
        CreatTime12 -= Time.deltaTime;    //开始倒计时
        if (CreatTime1 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime1 = Random.Range(8, 17);     //随机8到17秒内
            GameObject obj1 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster14");    //生成毛毛虫
            a6 = Instantiate(obj1);
            a6.transform.position = new Vector2(b6.x + x1, b6.y);    //随机生成怪物的位置
        }
        if (CreatTime2 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime2 = Random.Range(8, 17);     //随机8到17秒内
            GameObject obj2 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster3");    //生成灰色飞蛾
            a2 = Instantiate(obj2);
            a2.transform.position = new Vector2(b2.x + x1, b2.y + y1);    //随机生成怪物的位置
        }
        if (CreatTime3 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime3 = Random.Range(8, 17);     //随机8到17秒内
            GameObject obj3 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster11");    //生成黄色飞蛾
            a1 = Instantiate(obj3);
            a1.transform.position = new Vector2(b1.x + x1, b1.y + y1);    //随机生成怪物的位置
        }
        if (CreatTime4 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime4 = Random.Range(8, 17);     //随机8到17秒内
            GameObject obj4 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster6");    //生成海洋草
            a4 = Instantiate(obj4);
            a4.transform.position = new Vector2(b4.x + x1, b4.y + y1);    //随机生成怪物的位置
        }
        if (CreatTime5 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime5 = Random.Range(20, 40);     //随机25到40秒内
            GameObject obj5 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster2");    //生成紫色飞虫
            a3 = Instantiate(obj5);
            a3.transform.position = new Vector2(b3.x + x1, b3.y + y1);    //随机生成怪物的位置
        }
        if (CreatTime6 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime6 = Random.Range(20, 40);     //随机25到40秒内
            GameObject obj6 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster18");    //生成火骷髅
            a5 = Instantiate(obj6);
            a5.transform.position = new Vector2(b5.x + x1, b5.y + y1);    //随机生成怪物的位置
        }
        if (CreatTime7 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime7 = Random.Range(20, 40);     //随机25到40秒内
            GameObject obj7 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster16");    //生成乌贼
            a9 = Instantiate(obj7);
            a9.transform.position = new Vector2(b9.x + x1, b9.y + y1);    //随机生成怪物的位置
        }
        if (CreatTime8 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime8 = Random.Range(20, 40);     //随机25到40秒内
            GameObject obj8 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster9");    //生成小黄
            a8 = Instantiate(obj8);
            a8.transform.position = new Vector2(b8.x + x1, b8.y + y1);    //随机生成怪物的位置
        }
        if (CreatTime9 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime9 = Random.Range(90, 140);     //随机60到140秒内
            GameObject obj9 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster8");    //生成小红
            a7 = Instantiate(obj9);
            a7.transform.position = new Vector2(b7.x + x1, b7.y + y1);    //随机生成怪物的位置
        }
        if (CreatTime10 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime10 = Random.Range(90, 140);     //随机60到140秒内
            GameObject obj10 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster20");    //生成深渊虫
            a11 = Instantiate(obj10);
            a11.transform.position = new Vector2(b11.x, b11.y);    //随机生成怪物的位置
        }
        if (CreatTime11 <= 0)    //如果倒计时为0 的时候
        {
            x1 = Random.Range(-1, 1);
            y1 = Random.Range(-1, 1);
            CreatTime11 = Random.Range(90, 140);     //随机60到140秒内
            GameObject obj11 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster7");    //生成爬行者
            a10 = Instantiate(obj11);
            a10.transform.position = new Vector2(b10.x + x1, b10.y);    //随机生成怪物的位置
        }

        
        if (CreatTime12 <= 0)    //如果倒计时为0 的时候
        {
            CreatTime12 = 200;     //200s
            GameObject obj12 = (GameObject)Resources.Load("prefabs/bagsystem1/海洋生物/monster15");    //生成Boss 
            a12 = Instantiate(obj12);
            a12.transform.position = new Vector2(b12.x, b12.y);    //生成怪物的位置
           
        }


    }
}
