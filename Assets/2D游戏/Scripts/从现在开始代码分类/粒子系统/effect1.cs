using Spine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class effect1 : MonoBehaviour
{
    private bool cooling = true;
    private GameObject effect;
    [Header("���ܳ���ʱ��")]
    public float time = 1f;

    [Header("��ȴʱ��")]
    public float CoolTime;
    [Header("������")]
    public float Attackharm;
    // Start is called before the first frame update
    void Start()
    {
        effect = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooling == true)
        {
            effect.SetActive(true);
            cooling = false;
            Invoke("attackstop", time);
        }
    }

    public void attackstop()
    {
        effect.SetActive(false);
        Invoke("changeCooling", CoolTime);
    }



    private void changeCooling()
    {
        cooling = true;
    }
}
