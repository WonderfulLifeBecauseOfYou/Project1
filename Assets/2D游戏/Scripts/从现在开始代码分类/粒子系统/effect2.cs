using Spine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class effect2 : MonoBehaviour
{
    private bool cooling = true;
    [Header("���ܳ���ʱ��")]
    public float time = 1f;

    [Header("��ȴʱ��")]
    public float CoolTime;
    [Header("������")]
    public float Attackharm;
    public GameObject Magic;
    private Vector3 mousePos;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && cooling == true)
        {
            mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;
            GameObject magic =  Instantiate(Magic);
            magic.transform.position = mousePos;
            cooling = false;
            Invoke("changeCooling", CoolTime);
            Destroy(magic, time);
        }
    }



    private void changeCooling()
    {
        cooling = true;
    }
}
