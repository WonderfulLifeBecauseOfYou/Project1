using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class moveToScene : MonoBehaviour
{
    public int a = 1;
    public static bool isChangeScene = false;

    private Slider slider;
    private Text text;
    private GameObject loadScene;
    private void Start()
    {
        loadScene = GameObject.FindGameObjectWithTag("UI").transform.GetChild(13).gameObject;
        slider = GameObject.FindGameObjectWithTag("UI").transform.GetChild(13).GetChild(0).GetComponent<Slider>();
        text = GameObject.FindGameObjectWithTag("UI").transform.GetChild(13).GetChild(1).GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            createFileAndJump();
            isChangeScene = true;
        }
    }


    //创建文件并跳转场景
    public void createFileAndJump()
    {
        string path = "Assets/Resources/moveScene/moveSceneData/";
        string name = "moveSceneDatas.txt";
        string info;
        //删除
        deleteFile(path + name);
        //获取玩家数据
        //玩家的脚本
        MovingT0 playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingT0>();
        PlayerData playerD = new PlayerData();
        playerD.Health = playerController.currentHealth;
        playerD.addr = playerController.currentSceneName;

        playerD.Coins = playerController.Coins;
        playerD.speed = playerController.speed;
        playerD.level = playerController.level;
        playerD.state = playerController.state;
        playerD.maxHealth = playerController.maxHealth;
        playerD.bulletTime = playerController.bulletTime;
        playerD.skillTime = playerController.skillTime;
        playerD.attackTime = playerController.attackTime;
        playerD.atk1 = playerController.atk1;
        playerD.atk2 = playerController.atk2;
        playerD.def1 = playerController.def1;
        playerD.def2 = playerController.def2;
        playerD.magicValues = playerController.magicValues;
        playerD.EnduranceValues = playerController.EnduranceValues;
        playerD.smart = playerController.smart;
        playerD.belief = playerController.belief;

        Transform player = playerController.playerposition;
        playerD.playerX = player.position.x;
        playerD.playerY = player.position.y;
        playerD.playerZ = player.position.z;
        info = JsonUtility.ToJson(playerD) + "\n\n";
        //创建文件
        CreateFile(path, name, info);
        //跳转
        
        StartCoroutine(Loadlevel(a));
    }
    //删除文件
    public void deleteFile(string path)
    {
        File.Delete(path);
    }
    public void CreateFile(string path, string name, string info)
    {
        StreamWriter sw;
        FileInfo fi = new FileInfo(path + "//" + name);
        sw = fi.CreateText();//重新写入文件
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();
    }

    IEnumerator Loadlevel(int a)
    {
        loadScene.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + a);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            if (operation.progress >= 0.9f)
            {
                slider.value = 1;
                text.text = "按下空格键继续";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

}




