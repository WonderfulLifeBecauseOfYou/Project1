using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class StartCtrl : MonoBehaviour
{
    [SerializeField]
    Transform _canvas;

    TMP_InputField _ip;
    // Start is called before the first frame update
    void Start()
    {
        Button creatBtn = _canvas.Find("CreatBtn").GetComponent<Button>();
        Button joinBtn = _canvas.Find("JoinBtn").GetComponent<Button>();
        creatBtn.onClick.AddListener(OnCreatClick);
        joinBtn.onClick.AddListener(OnJoinClick);

        _ip = _canvas.Find("ip").GetComponent<TMP_InputField>();
    }

    private void OnJoinClick()
    {
        var transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport as UnityTransport;
        transport.SetConnectionData(_ip.text, 7777);
        NetworkManager.Singleton.StartClient();
    }
    private void OnCreatClick()
    {
        var transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport as UnityTransport;
        transport.SetConnectionData(_ip.text, 7777);

        NetworkManager.Singleton.StartHost();
        GameManager.Instance.LoadScene("room");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
