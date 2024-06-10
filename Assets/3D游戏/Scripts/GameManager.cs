using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;

    public Dictionary<ulong, PlayerInfo> AllPlayerInfos { get; private set; }
    public UnityEvent OnstartGame;
    public LobbyCtrl lobbyctrl;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
        AllPlayerInfos = new Dictionary<ulong, PlayerInfo>();


    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        NetworkManager.SceneManager.OnLoadEventCompleted += OnLoadEventComplete;
    }

    private void OnLoadEventComplete(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        if(sceneName == "game room")
        {
            OnstartGame.Invoke();
        }
    }
    

    public void StartGame(Dictionary<ulong,PlayerInfo> playerInfos)
    {
        AllPlayerInfos = playerInfos;

        UpdateAllPlayerInfos();
    }

    private void UpdateAllPlayerInfos()
    {
        foreach(var playerInfo in AllPlayerInfos)
        {
            UpdatePlayerInfoClientRpc(playerInfo.Value);
        }
    }

    [ClientRpc]
    void UpdatePlayerInfoClientRpc(PlayerInfo playerInfo)
    {
        if (!IsServer)
        {
            if (AllPlayerInfos.ContainsKey(playerInfo.id))
            {
                AllPlayerInfos[playerInfo.id] = playerInfo;
            }
            else
            {
                AllPlayerInfos.Add(playerInfo.id, playerInfo);
            }
        }
    }


    public void LoadScene(string sceneName)
    {
        NetworkManager.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    public AsyncOperation LoadSceneAsync1(string sceneName)
    {
        AsyncOperation operation1 = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        operation1.allowSceneActivation = false;
        return operation1;
    }
    // Update is called once per frame
    void Update()
    {
    
    }


}
