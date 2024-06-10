using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class gamectr : NetworkBehaviour
{
    [SerializeField]
    Transform _canvas;

    TMP_InputField _input;
    RectTransform _content;
    GameObject _dialogCell;
    public GameObject chatbox;
   
    

    private bool open = true;

    public float Pitch { get; private set; }
    public float Yaw { get; private set; }
    public float mouseSensitivity = 3f;
    public Transform cameraTransform;
    [SerializeField]
    CinemachineVirtualCamera _camera;


    public static gamectr Instance;

    public override void OnNetworkSpawn()
    {
        Instance = this;

        _input = _canvas.Find("聊天窗口/input").GetComponent<TMP_InputField>();
        _content = _canvas.Find("聊天窗口/Scroll View/Viewport/Content") as RectTransform;
        _dialogCell = _content.Find("cell").gameObject;
        Button sendBtn = _canvas.Find("聊天窗口/send").GetComponent<Button>();
        sendBtn.onClick.AddListener(OnSendClick);



        base.OnNetworkSpawn();
    }


    private void OnSendClick()
    {
        if (string.IsNullOrEmpty(_input.text))
        {
            return;
        }
        PlayerInfo playerInfo = GameManager.Instance.AllPlayerInfos[NetworkManager.Singleton.LocalClientId];

        AddCell(playerInfo.name, _input.text);

        if (IsServer)
        {
            SendMsgToOthersClientRpc(playerInfo, _input.text);
        }
        else
        {
            SendMsgToOthersServerRpc(playerInfo, _input.text);
        }


    }

    [ClientRpc]
    void SendMsgToOthersClientRpc(PlayerInfo playerInfo, string content)
    {
        if (!IsServer && NetworkManager.LocalClientId != playerInfo.id)
        {
            AddCell(playerInfo.name, content);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void SendMsgToOthersServerRpc(PlayerInfo playerInfo, string content)
    {
        AddCell(playerInfo.name, content);
        SendMsgToOthersClientRpc(playerInfo, content);
    }

    void AddCell(String playername, string content)
    {
        GameObject clone = Instantiate(_dialogCell);
        clone.transform.SetParent(_content, false);
        clone.AddComponent<DialogCell>().Initial(playername, content);
        clone.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        //UpdateRotation();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            chatbox.SetActive(open);
            open = !open;
        }
    }


    public Vector3 Getpos()
    {
        Vector3 pos = new Vector3();
        Vector3 offset = transform.forward * Random.Range(-1, 1f) + transform.right * Random.Range(-1, 1f);
        pos = transform.position + offset;
        return pos;
    }

    /*
    public void UpdateRotation()
    {
        Yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        Pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
        Pitch = Mathf.Clamp(value: Pitch, min: 0, max: 90);

        transform.rotation = Quaternion.Euler(x: Pitch, y: Yaw, z: 0);
    }
    */
     public void SetFollowTarget(Transform body)
    {
        _camera.Follow = body;
    }



}