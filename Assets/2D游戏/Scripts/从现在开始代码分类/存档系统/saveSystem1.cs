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
    //����浵
    public PlayerData dfpData1;
    public PlayerData dfpData2;
    public PlayerData dfpData3;

    //�ж��Ƿ�Ӷ����м���
    public bool needLoadData = false;
    //�жϼ����ĸ��浵
    public string needLoadDataFileName;

    //�жϴ�/��, 1��2��
    public int dataType=0;
    // ��ʼ��
    public void OnEnable()
    {
        if (dataType == 1)//�浵
        {
            //������
            GameObject.Find("�浵/Canvas/save/a/����").GetComponent<TextMeshProUGUI>().text = "�浵";
            //��ȡ�����а�ť
            Button data1Button = GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetComponent<Button>();
            Button data2Button = GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetComponent<Button>();
            Button data3Button = GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetComponent<Button>();
            //��������а󶨷���
            data1Button.onClick.RemoveAllListeners();
            data2Button.onClick.RemoveAllListeners();
            data3Button.onClick.RemoveAllListeners();
            //�󶨷���
            data1Button.onClick.AddListener(delegate { saveDate1(); });
            data2Button.onClick.AddListener(delegate { saveDate2(); });
            data3Button.onClick.AddListener(delegate { saveDate3(); });
            
            //��ȡ�浵�����ļ����ж��Ƿ��Ҷ�Ӧ�ļ�����ʾ��ͬ����
            TextAsset data1 = Resources.Load<TextAsset>("saveData/data1");
            TextAsset data2 = Resources.Load<TextAsset>("saveData/data2");
            TextAsset data3 = Resources.Load<TextAsset>("saveData/data3");
            UnityEditor.AssetDatabase.Refresh();
            if (!data1)
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            }
            if (!data2)
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            }
            
            else
            {
                //��ȡ���ݽ��и�ֵ
                string[] fileContent = data2.text.Split(new string[] {"\n\n"}, System.StringSplitOptions.None);
                dfpData2 = JsonUtility.FromJson<PlayerData>(fileContent[0]);
                gameObject.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = dfpData2.dataName;
                gameObject.transform.GetChild(3).GetChild(1).GetChild(3).GetComponent<Text>().text = dfpData2.saveTime;
                gameObject.transform.GetChild(3).GetChild(1).GetChild(5).GetComponent<Text>().text = dfpData2.addr;
                
                GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
            }
            if (!data3)
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            }
            
        }
        else//����
        {
            //dataType=2��ʱ��
            //������
            GameObject.Find("�浵/Canvas/save/a/����").GetComponent<TextMeshProUGUI>().text = "����";
            //��ȡ�����а�ť
            Button data1Button = GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetComponent<Button>();
            Button data2Button = GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetComponent<Button>();
            Button data3Button = GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetComponent<Button>();
            //��������а󶨷���
            data1Button.onClick.RemoveAllListeners();
            data2Button.onClick.RemoveAllListeners();
            data3Button.onClick.RemoveAllListeners();
            //�󶨷���
            data1Button.onClick.AddListener(delegate { loadDate1(); });
            data2Button.onClick.AddListener(delegate { loadDate2(); });
            data3Button.onClick.AddListener(delegate { loadDate3(); });
            //��ȡ�浵�����ļ����ж��Ƿ��Ҷ�Ӧ�ļ�����ʾ��ͬ����
            TextAsset data1 = Resources.Load<TextAsset>("saveData/data1");
            TextAsset data2 = Resources.Load<TextAsset>("saveData/data2");
            TextAsset data3 = Resources.Load<TextAsset>("saveData/data3");
            UnityEditor.AssetDatabase.Refresh();
            if (!data1)
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            }
            if (!data2)
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                string[] fileContent = data2.text.Split(new string[] { "\n\n" }, System.StringSplitOptions.None);
                dfpData2 = JsonUtility.FromJson<PlayerData>(fileContent[0]);
                gameObject.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<Text>().text = dfpData2.dataName;
                gameObject.transform.GetChild(3).GetChild(1).GetChild(3).GetComponent<Text>().text = dfpData2.saveTime;
                gameObject.transform.GetChild(3).GetChild(1).GetChild(5).GetComponent<Text>().text = dfpData2.addr;
                GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
            }
            if (!data3)
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("�浵/Canvas/save").transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveDate1()
    {
        print("�浵1");
    }

    public void loadDate1()
    {
        print("����1");
    }

    public void saveDate2()
    {
        //ɾ��ԭ�����ļ�
        string path = "Assets/Resources/saveData/";
        string name = "Data2.txt";
        //TextAsset(txt��json��yml��
        deleteFile(path + name);
        //��ֵ�������������
        string data;
        string saveTime = DateTime.Now.ToString("yyyy��MM��dd�� hh:mm:ss");
        string dataName = "�浵2";
        string addr = SceneManager.GetActiveScene().name;
        data = DataJson(saveTime, dataName);

        //�����ļ���������
        CreateOrOpenFiles(path, name, data);
        //��ʾ�浵�������\������Ҫ����ı�������
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
        //�ж��Ƿ��ж����ļ�
        TextAsset data = Resources.Load<TextAsset>("saveData/Data2");
        if (!data)
        {
            return;
        }
        gameObject.SetActive(false);
        //�ж��Ƿ���Ҫ��ת����
        if (SceneManager.GetActiveScene().name == dfpData2.addr)
        {
            //����
            loadGameData("Data2");
        }
        else
        {
            //�ж��Ƿ���Ҫ���ж���
            needLoadData = true;
            needLoadDataFileName = "Data2";
            //��д��Ԥ����
            GameObject saveObject = GameObject.FindGameObjectWithTag("UI").gameObject;
            PrefabUtility.SaveAsPrefabAssetAndConnect(saveObject, "Assets/Resources/prefabs/��Ҫ/Canvas.prefab", InteractionMode.AutomatedAction);
            UnityEditor.AssetDatabase.Refresh();
            //��ת����
            SceneManager.LoadScene(dfpData2.addr);
        }
        
    }


    public void saveDate3()
    {
        print("�浵3");
    }

    public void loadDate3()
    {
        print("����3");
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
        //���ļ�
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
    

    //����������Ϸ����
    public void loadGameData(string name)
    {
        string path = "saveData/";
        string fileName = name;
        //ˢ��
        AssetDatabase.Refresh();
        //����������մ浵����
        TextAsset data = Resources.Load<TextAsset>(path + fileName);
        string[] fileContent = data.text.Split(new string[] { "\n\n" }, System.StringSplitOptions.None);
        PlayerData dataForPlayer = JsonUtility.FromJson<PlayerData>(fileContent[0]);
        // ��ֵ����
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



