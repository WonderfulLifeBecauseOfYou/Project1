using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class saveSystem1 : MonoBehaviour
{
    //各类存档
    public PlayerData dfpData1;
    public PlayerData dfpData2;
    public PlayerData dfpData3;

    //判断是否从读档中加载
    public bool needLoadData = false;
    //判断加载哪个存档
    public string needLoadDataFileName;

    //判断存/读, 1存2读
    public int dataType=0;
    // 初始化
    public void OnEnable()
    {
        if (dataType == 1)//存档
        {
            //换标题
            GameObject.Find("存档/Canvas/save/a/标题").GetComponent<TextMeshProUGUI>().text = "存档";
            //获取到所有按钮
            Button data1Button = GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetComponent<Button>();
            Button data2Button = GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetComponent<Button>();
            Button data3Button = GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetComponent<Button>();
            //先清除所有绑定方法
            data1Button.onClick.RemoveAllListeners();
            data2Button.onClick.RemoveAllListeners();
            data3Button.onClick.RemoveAllListeners();
            //绑定方法
            data1Button.onClick.AddListener(delegate { saveDate1(); });
            data2Button.onClick.AddListener(delegate { saveDate2(); });
            data3Button.onClick.AddListener(delegate { saveDate3(); });
            
            //获取存档数据文件，判断是否右对应文件，显示不同画面
            TextAsset data1 = Resources.Load<TextAsset>("saveData/data1");
            TextAsset data2 = Resources.Load<TextAsset>("saveData/data2");
            TextAsset data3 = Resources.Load<TextAsset>("saveData/data3");
            UnityEditor.AssetDatabase.Refresh();
            if (!data1)
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            }
            if (!data2)
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            }
            
            else
            {
                //获取数据进行赋值
                string[] fileContent = data2.text.Split(new string[] {"\n\n"}, System.StringSplitOptions.None);
                dfpData2 = JsonUtility.FromJson<PlayerData>(fileContent[0]);
                gameObject.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = dfpData2.dataName;
                gameObject.transform.GetChild(3).GetChild(1).GetChild(3).GetComponent<Text>().text = dfpData2.saveTime;
                gameObject.transform.GetChild(3).GetChild(1).GetChild(5).GetComponent<Text>().text = dfpData2.addr;
                
                GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
            }
            if (!data3)
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            }
            
        }
        else//读档
        {
            //dataType=2的时候
            //换标题
            GameObject.Find("存档/Canvas/save/a/标题").GetComponent<TextMeshProUGUI>().text = "读档";
            //获取到所有按钮
            Button data1Button = GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetComponent<Button>();
            Button data2Button = GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetComponent<Button>();
            Button data3Button = GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetComponent<Button>();
            //先清除所有绑定方法
            data1Button.onClick.RemoveAllListeners();
            data2Button.onClick.RemoveAllListeners();
            data3Button.onClick.RemoveAllListeners();
            //绑定方法
            data1Button.onClick.AddListener(delegate { loadDate1(); });
            data2Button.onClick.AddListener(delegate { loadDate2(); });
            data3Button.onClick.AddListener(delegate { loadDate3(); });
            //获取存档数据文件，判断是否右对应文件，显示不同画面
            TextAsset data1 = Resources.Load<TextAsset>("saveData/data1");
            TextAsset data2 = Resources.Load<TextAsset>("saveData/data2");
            TextAsset data3 = Resources.Load<TextAsset>("saveData/data3");
            UnityEditor.AssetDatabase.Refresh();
            if (!data1)
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("存档/Canvas/save").transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            }
            if (!data2)
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                string[] fileContent = data2.text.Split(new string[] { "\n\n" }, System.StringSplitOptions.None);
                dfpData2 = JsonUtility.FromJson<PlayerData>(fileContent[0]);
                gameObject.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = dfpData2.dataName;
                gameObject.transform.GetChild(3).GetChild(1).GetChild(3).GetComponent<Text>().text = dfpData2.saveTime;
                gameObject.transform.GetChild(3).GetChild(1).GetChild(5).GetComponent<Text>().text = dfpData2.addr;
                GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("存档/Canvas/save").transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
            }
            if (!data3)
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("存档/Canvas/save").transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveDate1()
    {
        print("存档1");
    }

    public void loadDate1()
    {
        print("读档1");
    }

    public void saveDate2()
    {
        //删除原来的文件
        string path = "Assets/Resources/saveData/";
        string name = "Data2.txt";
        //TextAsset(txt、json、yml…
        deleteFile(path + name);
        //赋值给到保存的数据
        string data;
        string saveTime = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss");
        string dataName = "存档2";
        string addr = SceneManager.GetActiveScene().name;
        data = DataJson(saveTime, dataName);

        //数据文件创建下来
        CreateOrOpenFiles(path, name, data);
        //显示存档后的内容\查找需要变更文本的物体
        gameObject.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = dataName;
        gameObject.transform.GetChild(3).GetChild(1).GetChild(3).GetComponent<Text>().text = saveTime;
        gameObject.transform.GetChild(3).GetChild(1).GetChild(5).GetComponent<Text>().text = addr;

        if (gameObject.transform.GetChild(3).GetChild(0).gameObject.activeSelf == true)
        {
            gameObject.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
        }
    }

    public void loadDate2()
    {
        //判断是否有读档文件
        TextAsset data = Resources.Load<TextAsset>("saveData/Data2");
        if (!data)
        {
            return;
        }
        gameObject.SetActive(false);
        //判断是否需要跳转场景
        if (SceneManager.GetActiveScene().name == dfpData2.addr)
        {
            //调用
            loadGameData("Data2");
        }
        else
        {
            //判断是否需要进行读档
            needLoadData = true;
            needLoadDataFileName = "Data2";
            //复写到预制体
            GameObject saveObject = GameObject.FindGameObjectWithTag("UI").gameObject;
            PrefabUtility.SaveAsPrefabAssetAndConnect(saveObject, "Assets/Resources/prefabs/重要/Canvas.prefab", InteractionMode.AutomatedAction);
            UnityEditor.AssetDatabase.Refresh();
            //跳转场景
            SceneManager.LoadScene(dfpData2.addr);
        }
        
    }


    public void saveDate3()
    {
        print("存档3");
    }

    public void loadDate3()
    {
        print("读档3");
    }





    public void backsave()
    {
        gameObject.SetActive(false);
    }


    public void deleteFile(string path)
    {
        File.Delete(path);
    }

    public void CreateOrOpenFiles(string path, string name, string info)
    {
        //打开文件
        StreamWriter sw;
        FileInfo fi = new FileInfo(path + "//" + name);
        sw = fi.CreateText();
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();

    }

    public string DataJson(string saveTime, string dataName)
    {
        string data;

        MovingT0 playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingT0>();
        PlayerData dataForPlayer = new PlayerData();
        dataForPlayer.dataName = dataName;
        dataForPlayer.saveTime = saveTime;
        dataForPlayer.Health = playerController.currentHealth;
        dataForPlayer.addr = playerController.currentSceneName;

        dataForPlayer.speed = playerController.speed;
        dataForPlayer.level = playerController.level;
        dataForPlayer.state = playerController.state;
        dataForPlayer.maxHealth = playerController.maxHealth;
        dataForPlayer.bulletTime = playerController.bulletTime;
        dataForPlayer.skillTime = playerController.skillTime;
        dataForPlayer.attackTime = playerController.attackTime;
        dataForPlayer.atk1 = playerController.atk1;
        dataForPlayer.atk2 = playerController.atk2;
        dataForPlayer.def1 = playerController.def1;
        dataForPlayer.def2 = playerController.def2;
        dataForPlayer.magicValues = playerController.magicValues;
        dataForPlayer.EnduranceValues = playerController.EnduranceValues;
        dataForPlayer.smart = playerController.smart;
        dataForPlayer.belief = playerController.belief;

        Transform player = playerController.playerposition;
        dataForPlayer.playerX = player.position.x;
        dataForPlayer.playerY = player.position.y;
        dataForPlayer.playerZ = player.position.z;
        data = JsonUtility.ToJson(dataForPlayer) + "\n\n";
        
        return data;
    }
    

    //读档加载游戏数据
    public void loadGameData(string name)
    {
        string path = "saveData/";
        string fileName = name;
        //刷新
        AssetDatabase.Refresh();
        //定义变量接收存档数据
        TextAsset data = Resources.Load<TextAsset>(path + fileName);
        string[] fileContent = data.text.Split(new string[] { "\n\n" }, System.StringSplitOptions.None);
        PlayerData dataForPlayer = JsonUtility.FromJson<PlayerData>(fileContent[0]);
        // 赋值属性
        MovingT0 playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingT0>();
        playerController.currentHealth = dataForPlayer.Health;
        playerController.currentSceneName = dataForPlayer.addr;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 playerstation = new Vector3();
        playerstation.x = dataForPlayer.playerX;
        playerstation.y = dataForPlayer.playerY;
        playerstation.z = dataForPlayer.playerZ;
        player.position = playerstation;

        playerController.Coins = dataForPlayer.Coins;
        playerController.speed = dataForPlayer.speed;
        playerController.level = dataForPlayer.level;
        playerController.state = dataForPlayer.state;
        playerController.maxHealth = dataForPlayer.maxHealth;
        playerController.bulletTime = dataForPlayer.bulletTime;
        playerController.skillTime = dataForPlayer.skillTime;
        playerController.attackTime = dataForPlayer.attackTime;
        playerController.atk1 = dataForPlayer.atk1;
        playerController.atk2 = dataForPlayer.atk2;
        playerController.def1 = dataForPlayer.def1;
        playerController.def2 = dataForPlayer.def2;
        playerController.magicValues = dataForPlayer.magicValues;
        playerController.EnduranceValues = dataForPlayer.EnduranceValues;
        playerController.smart = dataForPlayer.smart;
        playerController.belief = dataForPlayer.belief;
    }


    
}



