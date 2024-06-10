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


    //复写预制体恢复原来状态
    public void OverrideUiPrefab()
    {
        GameObject save = GameObject.Find("存档").gameObject;
        GameObject.FindGameObjectWithTag("SAVE").transform.GetChild(1).GetChild(3).GetComponent<saveSystem1>().needLoadData = false;
        //重新获得修改后的物体
        GameObject OverideSAVE = GameObject.Find("存档").gameObject;
        //更新属性到预制体
        PrefabUtility.SaveAsPrefabAssetAndConnect(OverideSAVE, "Assets/2D游戏/prefabs/王后花园交互/存档.prefab", InteractionMode.AutomatedAction);
        AssetDatabase.Refresh();
    }

    public void loadGameData()
    {
        GameObject save = GameObject.Find("存档").transform.GetChild(0).GetChild(1).gameObject;
        if (save.transform.GetChild(3).GetComponent<saveSystem1>().needLoadData == true)
        {
            //获取需要加载存档的文件名
            string path = "saveData/";
            string fileName = save.transform.GetChild(3).GetComponent<saveSystem1>().needLoadDataFileName;
            //刷新文件
            AssetDatabase.Refresh();
            //定义变量并接收
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

            //复写恢复预制体数据
            OverrideUiPrefab();
        }

    }
}
*/