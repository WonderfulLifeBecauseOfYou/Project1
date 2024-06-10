using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListCell : MonoBehaviour
{
    TMP_Text _name;
    TMP_Text _ready;
    TMP_Text _gender;
    public PlayerInfo PlayerInfo { get; private set; }
    public void Initial(PlayerInfo playerInfo)
    {
        PlayerInfo = playerInfo;
        _name = transform.Find("name").GetComponent<TMP_Text>();
        _ready = transform.Find("ready").GetComponent<TMP_Text>();
        _name.text = playerInfo.name;
        _ready.text = playerInfo.isready ? "׼��" : "δ׼��";
        _gender = transform.Find("gender").GetComponent<TMP_Text>();
        _gender.text = playerInfo.gender == 0 ? "��" : "Ů";

    }

    public void UpdateInfo(PlayerInfo playerInfo)
    {
        PlayerInfo = playerInfo;
        _name.text = playerInfo.name;
        _ready.text = PlayerInfo.isready ? "׼��" : "δ׼��";
        _gender.text = PlayerInfo.gender ==0 ? "��" : "Ů";
    }


    internal void SetReady(bool arg0)
    {
        _ready.text = arg0 ? "׼��" : "δ׼��";
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
