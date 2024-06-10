using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.SceneManagement;
public class initScene : MonoBehaviour
{
    private PlayerData playerD;
    private TextAsset loadData;

    [Header("ǰһ������1")]
    public string beforScene1;
    public float vx = 1;
    public float vy = 2;
    public float vz = 0;


    [Header("ǰһ������2")]
    public string beforScene2;
    public float vxx = 1;
    public float vyy = 2;
    public float vzz = 0;


    [Header("ǰһ������3")]
    public string beforScene3;
    public float vxxx = 1;
    public float vyyy = 2;
    public float vzzz = 0;


    [Header("ǰһ������4")]
    public string beforScene4;
    public float vxxxx = 1;
    public float vyyyy = 2;
    public float vzzzz = 0;
    private void Awake()
    {
        LoadData();
        InitPlayer();
        InitUiSystem();
        setValue();
        loadGameData();
    }

    //��ȡ�ļ�����ֵ
    public void LoadData()
    {
        AssetDatabase.Refresh();
        loadData = Resources.Load<TextAsset>("moveScene/moveSceneData/moveSceneDatas");
        if (loadData)
        {
            string[] DataStringList = loadData.text.Split(new string[] { "\n\n" }, System.StringSplitOptions.None);
            for(int i = 0; i < DataStringList.Length; i++)
            {
                playerD = JsonUtility.FromJson<PlayerData>(DataStringList[0]);
            }
        }
    }



    //��ʼ�����
    public void InitPlayer()
    {
        //if (GameObject.FindGameObjectWithTag("Player") != null) return;
        GameObject playerPrefab = Resources.Load<GameObject>("prefabs/��Ҫ/������ţ��");
        Instantiate(playerPrefab);
        if (moveToScene.isChangeScene == true)
        {
            setPlayerValue();
            moveToScene.isChangeScene = false;
        }
        else
        {
            Transform playerTi = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 vector3 = new Vector3();
            vector3.x = 0;
            vector3.y = -2;
            vector3.z = 0;
            playerTi.position = vector3;
            
        }
    }


    //������ݸ�ֵ
    public void setPlayerValue()
    {
        if(playerD != null)
        {
            Transform playerT = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 vector3 = new Vector3();
            MovingT0 playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingT0>();
            playerController.currentHealth = playerD.Health;

            playerController.Coins = playerD.Coins;
            playerController.speed = playerD.speed;
            playerController.level = playerD.level;
            playerController.state = playerD.state;
            playerController.maxHealth = playerD.maxHealth;
            playerController.bulletTime = playerD.bulletTime;
            playerController.skillTime = playerD.skillTime;
            playerController.attackTime = playerD.attackTime;
            playerController.atk1 = playerD.atk1;
            playerController.atk2 = playerD.atk2;
            playerController.def1 = playerD.def1;
            playerController.def2 = playerD.def2;
            playerController.magicValues = playerD.magicValues;
            playerController.EnduranceValues = playerD.EnduranceValues;
            playerController.smart = playerD.smart;
            playerController.belief = playerD.belief;


            //������ҵ�����
            if (playerD.addr == beforScene1)
            {
                vector3.x = vx;
                vector3.y = vy;
                vector3.z = vz;
            }
            if (playerD.addr == beforScene2)
            {
                vector3.x = vxx;
                vector3.y = vyy;
                vector3.z = vzz;
            }
            if (playerD.addr == beforScene3)
            {
                vector3.x = vxxx;
                vector3.y = vyyy;
                vector3.z = vzzz;
            }
            if (playerD.addr == beforScene4)
            {
                vector3.x = vxxxx;
                vector3.y = vyyyy;
                vector3.z = vzzzz;
            }
            playerT.position = vector3;
        }

    }

    //��ʼ��ui
    public void InitUiSystem()
    {
        GameObject uiSystem = Resources.Load<GameObject>("prefabs/��Ҫ/Canvas");
        GameObject UI = GameObject.FindGameObjectWithTag("UI");
        if (!UI)
        {
            Instantiate(uiSystem);
        }
    }



    //����Ĭ������
    public void setValue()
    {
        //�󶨸���
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        CinemachineVirtualCamera cine = GameObject.FindGameObjectWithTag("cinemachine").GetComponent<CinemachineVirtualCamera>();
        if (!cine.Follow)
        {
            cine.Follow = player;
        }

        //�󶨱������������浵
        GameObject bag = GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).GameObject();
        GameObject died = GameObject.FindGameObjectWithTag("UI").transform.GetChild(10).GameObject();
        GameObject S = GameObject.FindGameObjectWithTag("SAVE").transform.GetChild(0).GameObject();
        MovingT0 playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingT0>();
        PauseMenu save = GameObject.FindGameObjectWithTag("UI").GetComponent<PauseMenu>();
        playerController.Bag = bag;
        playerController.Died = died;
        save.save = S;
    }


    //��дԤ����ָ�ԭ��״̬
    public void OverrideUiPrefab()
    {
        GameObject.FindGameObjectWithTag("SAVE").transform.GetChild(1).GetComponent<saveSystem1>().needLoadData = false;
        //���»���޸ĺ������
        GameObject OverideSAVE = GameObject.FindGameObjectWithTag("UI").gameObject;
        //�������Ե�Ԥ����
        PrefabUtility.SaveAsPrefabAssetAndConnect(OverideSAVE, "Assets/Resources/prefabs/��Ҫ/Canvas.prefab", InteractionMode.AutomatedAction);
        AssetDatabase.Refresh();
    }


    public void loadGameData()
    {
        GameObject save = GameObject.FindGameObjectWithTag("SAVE").transform.GetChild(1).gameObject;
        if (save.GetComponent<saveSystem1>().needLoadData == true)
        {
            //��ȡ��Ҫ���ش浵���ļ���
            string path = "saveData/";
            string fileName = save.GetComponent<saveSystem1>().needLoadDataFileName;
            //ˢ���ļ�
            AssetDatabase.Refresh();
            //�������������
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
            //������
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



            //��д�ָ�Ԥ��������
            OverrideUiPrefab();
        }

    }
}
