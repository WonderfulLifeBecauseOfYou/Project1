using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class playerInit : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        GameManager.Instance.OnstartGame.AddListener(OnstartGame);

        base.OnNetworkSpawn();
    }

    public void OnstartGame()
    {
        PlayerInfo playerInfo = GameManager.Instance.AllPlayerInfos[OwnerClientId];
        Transform body = transform.GetChild(playerInfo.gender);
        body.GetComponent<Rigidbody>().isKinematic = false;
        //body.gameObject.SetActive(true);
        Transform other = transform.GetChild(1 - playerInfo.gender);
        other.gameObject.SetActive(false);
        PlayerSync playerSync = GetComponent<PlayerSync>();
        playerSync.SetTarget(playerInfo.gender);
        playerSync.enabled = true;

        if (IsLocalPlayer)
        {
            //gamectr.Instance.UpdateRotation();
            gamectr.Instance.SetFollowTarget(body);
            body.GetComponent<Playermoving>().enabled = true;
        }

        transform.position = gamectr.Instance.Getpos();
    }
}
