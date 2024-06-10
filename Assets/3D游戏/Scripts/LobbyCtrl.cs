using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public struct PlayerInfo : INetworkSerializable
{
    public ulong id;
    public string name;
    public bool isready;
    public int gender;

    void INetworkSerializable.NetworkSerialize<T>(BufferSerializer<T> serializer)
    {
        serializer.SerializeValue(ref id);
        serializer.SerializeValue(ref name);
        serializer.SerializeValue(ref isready);
        serializer.SerializeValue(ref gender);
    }
}


public class LobbyCtrl : NetworkBehaviour
{
    [SerializeField]
    Transform _canvas;

    Transform _content;
    GameObject _Cell;
    Button _startBtn;
    Toggle _ready;
    Dictionary<ulong, PlayerListCell> _cellDictionary;
    Dictionary<ulong, PlayerInfo> _allPlayerInfos;
    TMP_InputField _name;
    public Slider slider;
    public GameObject loadscene;
    public Text text;
    playerInit playinit;

    private void OnStartClick()
    {
        GameManager.Instance.StartGame(_allPlayerInfos);
        GameManager.Instance.LoadScene("game room");
        //加载条
        //StartCoroutine(Loadlevel());
    }

    private void OnReadyToggle(bool arg0)
    {
        _cellDictionary[NetworkManager.LocalClientId].SetReady(arg0);
        UpdtePlayerInfo(NetworkManager.LocalClientId, arg0);

        if (IsServer)
        {
            UpdateAllPlayerInfos();
        }
        else
        {
            UpdateAllPlayerInfosServerRpc(_allPlayerInfos[NetworkManager.LocalClientId]);
        }
        
    }

    [ServerRpc(RequireOwnership = false)]
    void UpdateAllPlayerInfosServerRpc(PlayerInfo player)
    {
        _allPlayerInfos[player.id] = player;
        _cellDictionary[player.id].UpdateInfo(player);
        UpdateAllPlayerInfos();
    }


    void UpdtePlayerInfo(ulong id, bool isReady)
    {
        PlayerInfo info = _allPlayerInfos[id];
        info.isready = isReady;
        _allPlayerInfos[id] = info;
    }

    public void AddPlayer(PlayerInfo playerInfo)
    {
        _allPlayerInfos.Add(playerInfo.id, playerInfo);

        GameObject clone = Instantiate(_Cell);
        clone.transform.SetParent(_content, false);
        PlayerListCell cell = clone.GetComponent<PlayerListCell>();
        _cellDictionary.Add(playerInfo.id, cell);
        cell.Initial(playerInfo);
        clone.SetActive(true);
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            NetworkManager.OnClientConnectedCallback += OnClientConnect;
        }



        _allPlayerInfos = new Dictionary<ulong, PlayerInfo>();

        _content = _canvas.Find("Scroll View/Viewport/Content");
        _Cell = _content.Find("cell").gameObject;
        _startBtn = _canvas.Find("开始游戏").GetComponent<Button>();
        _ready = _canvas.Find("准备?").GetComponent<Toggle>();
        _startBtn.onClick.AddListener(OnStartClick);
        _ready.onValueChanged.AddListener(OnReadyToggle);
        _cellDictionary = new Dictionary<ulong, PlayerListCell>();
        _name = _canvas.Find("名字").GetComponent<TMP_InputField>();
        _name.onEndEdit.AddListener(OnEndEdit);

        PlayerInfo playerInfo = new PlayerInfo();
        playerInfo.id = NetworkManager.LocalClientId;
        playerInfo.name = "玩家" + playerInfo.id;
        _name.text = playerInfo.name;
        playerInfo.isready = false;
        playerInfo.gender = 0;

        AddPlayer(playerInfo);

        Toggle male = _canvas.Find("人物选择/男").GetComponent<Toggle>();
        Toggle female = _canvas.Find("人物选择/女").GetComponent<Toggle>();
        male.onValueChanged.AddListener(OnMaleToggle);
        female.onValueChanged.AddListener(OnFemaleToggle);

        base.OnNetworkSpawn();
    }

    private void OnEndEdit(string arg0)
    {
        if (string.IsNullOrEmpty(arg0))
        {
            return;
        }
        PlayerInfo playerInfo = _allPlayerInfos[NetworkManager.LocalClientId];
        playerInfo.name = arg0;
        _allPlayerInfos[NetworkManager.LocalClientId] = playerInfo;
        _cellDictionary[NetworkManager.LocalClientId].UpdateInfo(playerInfo);
        if (IsServer)
        {
            UpdateAllPlayerInfos();
        }
        else
        {
            UpdateAllPlayerInfosServerRpc(playerInfo);
        }
    }

    private void OnMaleToggle(bool arg0)
    {
        if (arg0)
        {
            PlayerInfo playerInfo = _allPlayerInfos[NetworkManager.LocalClientId];
            playerInfo.gender = 0;
            _allPlayerInfos[NetworkManager.LocalClientId] = playerInfo;
            _cellDictionary[NetworkManager.LocalClientId].UpdateInfo(playerInfo);
            if (IsServer)
            {
                UpdateAllPlayerInfos();
            }
            else
            {
                UpdateAllPlayerInfosServerRpc(playerInfo);
            }
            Role.Instance.SwitchGender(1);
        }
    }

    private void OnFemaleToggle(bool arg0)
    {
        if (arg0)
        {
            PlayerInfo playerInfo = _allPlayerInfos[NetworkManager.LocalClientId];
            playerInfo.gender = 1;
            _allPlayerInfos[NetworkManager.LocalClientId] = playerInfo;
            _cellDictionary[NetworkManager.LocalClientId].UpdateInfo(playerInfo);
            if (IsServer)
            {
                UpdateAllPlayerInfos();
            }
            else
            {
                UpdateAllPlayerInfosServerRpc(playerInfo);
            }

            Role.Instance.SwitchGender(0);
        }
    }

    private void OnClientConnect(ulong obj)
    {
        PlayerInfo playerInfo = new PlayerInfo();
        playerInfo.id = obj;
        playerInfo.name = "玩家" + obj;
        playerInfo.isready = false;
        AddPlayer(playerInfo);

        UpdateAllPlayerInfos();
    }
    void UpdateAllPlayerInfos()
    {
        bool canStart = true;
        foreach(var item in _allPlayerInfos)
        {
            if(!item.Value.isready)
            {
                canStart = false;
            }
            UpdatePlayerInfoClientRpc(item.Value);
        }

            _startBtn.gameObject.SetActive(canStart);
    }

    [ClientRpc]
    void UpdatePlayerInfoClientRpc(PlayerInfo playerInfo)
    {
        if (!IsServer)
        {
            if (_allPlayerInfos.ContainsKey(playerInfo.id))
            {
                _allPlayerInfos[playerInfo.id] = playerInfo;
            }
            else
            {
                AddPlayer(playerInfo);
            }
            UpdatePlayerCells();
        }
    }

    private void UpdatePlayerCells()
    {
        foreach(var item in _allPlayerInfos)
        {
            _cellDictionary[item.Key].UpdateInfo(item.Value);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Loadlevel()
    {
        loadscene.SetActive(true);
        AsyncOperation operation = GameManager.Instance.LoadSceneAsync1("game room");
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            if(operation.progress >= 0.9f)
            {
                slider.value = 1;
                text.text = "按下空格键继续";
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                    playinit.OnstartGame();
                }
            }
            yield return null;
        }
    }

}
