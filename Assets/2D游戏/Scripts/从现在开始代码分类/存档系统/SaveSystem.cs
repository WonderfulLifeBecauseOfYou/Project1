using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
public class SaveSystem : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveDataButton()
    {
        //���״̬
        saveSystem1 dataPanelTest = GameObject.Find("�浵/Canvas/save").GetComponent<saveSystem1>();
        dataPanelTest.dataType = 1;




        a.SetActive(true);
        b.SetActive(false);

    }
    public void LoadDataButton()
    {
        //���״̬
        saveSystem1 dataPanelTest = GameObject.Find("�浵/Canvas/save").GetComponent<saveSystem1>();
        dataPanelTest.dataType = 2;





        a.SetActive(true);
        b.SetActive(false);

    }
    public void BackButton()
    {
        SceneManager.LoadScene("�ֻ���Ϸ��-������", LoadSceneMode.Single);
    }
    public void Out()
    {
        b.SetActive(false);
    }



}
