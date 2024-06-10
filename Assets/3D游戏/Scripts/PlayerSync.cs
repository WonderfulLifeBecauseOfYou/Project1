using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class PlayerSync : NetworkBehaviour
{
    NetworkVariable<Vector3> _syncPos = new NetworkVariable<Vector3>();
    NetworkVariable<Quaternion> _syncRot = new NetworkVariable<Quaternion>();

    Transform _syncTransform;

    
    public void SetTarget(int gender)
    {
        _syncTransform = transform.GetChild(gender);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            UploadTransform();
        }
    }

    private void FixedUpdate()
    {
        if (!IsLocalPlayer)
        {
            SyncTransform();
        }
    }

    private void SyncTransform()
    {
        _syncTransform.position = _syncPos.Value;
        _syncTransform.rotation = _syncRot.Value;
    }

    private void UploadTransform()
    {
        if (IsServer)
        {
            _syncPos.Value = _syncTransform.position;
            _syncRot.Value = _syncTransform.rotation;
        }
        else
        {
            UploadTransformServerRpc(_syncTransform.position, _syncTransform.rotation);
        }
    }

    [ServerRpc]
    private void UploadTransformServerRpc(Vector3 position, Quaternion rotation)
    {
        _syncPos.Value = position;
        _syncRot.Value = rotation;
    }
}
