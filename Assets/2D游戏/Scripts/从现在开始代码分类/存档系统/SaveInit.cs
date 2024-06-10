using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
public class SaveInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        loadGameData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //��дԤ����ָ�ԭ��״̬
    public void OverrideUiPrefab()
    {
        GameObject save = GameObject.Find("�浵").gameObject;
        GameObject.FindGameObjectWithTag("SAVE").transform.GetChild(1).GetChild(3).GetComponent<saveSystem1>().needLoadData = false;
        //���»���޸ĺ������
        GameObject OverideSAVE = GameObject.Find("�浵").gameObject;
        //�������Ե�Ԥ����
        PrefabUtility.SaveAsPrefabAssetAndConnect(OverideSAVE, "Assets/2D��Ϸ/prefabs/����԰����/�浵.prefab", InteractionMode.AutomatedAction);
        AssetDatabase.Refresh();
    }

    public void loadGameData()
    {
        GameObject save = GameObject.Find("�浵").transform.GetChild(0).GetChild(1).gameObject;
        if (save.transform.GetChild(3).GetComponent<saveSystem1>().needLoadData == true)
        {
            //��ȡ��Ҫ���ش浵���ļ���
            string path = "saveData/";
            string fileName = save.transform.GetChild(3).GetComponent<saveSystem1>().needLoadDataFileName;
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

            //��д�ָ�Ԥ��������
            OverrideUiPrefab();
        }

    }
}
*/