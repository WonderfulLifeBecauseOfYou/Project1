using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public HSaveData saveData;
    public static HomeManager current;
    public GameObject canvas;

    [SerializeField] private string shopItemsPath = "HomeShop";
    private void Awake()
    {
        current = this;

        ShopItemDrag.canvas = canvas.GetComponent<Canvas>();
        UIDrag.canvas = canvas.GetComponent<Canvas>();

        HSaveSystem.Initialize();
    }

    private void Start()
    {
        saveData = HSaveSystem.Load();
        LoadGame();
    }

    private void LoadGame()
    {
        LoadPlaceableObjects();
    }

    private void LoadPlaceableObjects()
    {
        foreach(var plObjData in saveData.placeableObjectDatas.Values)
        {
            try
            {
                for (int i = 0; i < plObjData .Count ; i++)
                {
                    Debug.Log(plObjData[i].position);
                    ShopItem item = Resources.Load<ShopItem>(shopItemsPath + "/" + plObjData[i].assetName);
                    GameObject obj = GridBuildingSystem.current.InitializeWithBuilding(item.Prefab, plObjData[i].position, true);
                    Building plObj = obj.GetComponent<Building>();
                    plObj.Initialize(item, plObjData[i]);
                    plObj.Load();
                }
               

            }
            catch(Exception e)
            {

            }
        }
    }

    private void OnDisable()
    {
        HSaveSystem.Save(saveData);
    }
    private void OnApplicationQuit()
    {
       
    }

}
    

