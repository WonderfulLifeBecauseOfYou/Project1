using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using System;
public class Building : MonoBehaviour
{
    private ShopItem item;
    public bool Placed { get; private set; }
    public BoundsInt area;
    private Vector3 origin;

    [ReadOnly] public HPlaceableObjectData data = new HPlaceableObjectData();

 
    public void Initialize(ShopItem shopItem)
    {
        item = shopItem;
        data.assetName = item.Name;
        data.ID = HSaveData.GenerateId();
    }
    public void Initialize(ShopItem shopItem, HPlaceableObjectData objectData)
    {
        item = shopItem;
        data = objectData;
    }

    public void Load()
    {
        Destroy(GetComponent<ObjectDrag>());
        Place();
    }
    #region Build Methods

    public bool CanBePlaced()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        return GridBuildingSystem.current.CanTakeArea(areaTemp);
    }

    public virtual void Place()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        origin = transform.position;
        GridBuildingSystem.current.TakeArea(areaTemp);
    }

    public void CheckPlacement()
    {
        if (!Placed)
        {
            if (CanBePlaced())
            {
                Place();
            }
            else
            {
                Destroy(transform.gameObject);
            }

            HomeShopManager.current.ShopButton_Click();
        }
        else
        {
            if (!CanBePlaced())
            {
                transform.position = origin;
            }

            Place();
        }

    }

    private float time = 0f;
    private  bool moving;
    private bool canDes = false;
    ObjectDrag current;
    private void Update()
    {
        if (mousein && !moving && Input.GetMouseButton(0))
        {
            //increase time elapsed
            time += Time.deltaTime;
            //Debug.Log(time);
            //time limit exceeded
            if (time > 3f)
            {
                time = 0;
                canDes = true;
                moving = true;
                //add component to drag
                current = gameObject.AddComponent<ObjectDrag>();
                //prepare area
                Vector3Int positionInt = GridBuildingSystem.current.gridLayout.WorldToCell(transform.position);
                BoundsInt areaTemp = area;
                areaTemp.position = positionInt;

                //clear area on which the object was standing on
                GridBuildingSystem.current.ClearArea(areaTemp, GridBuildingSystem.current.MainTilemap);

                startPos = Input.mousePosition;
                startPos = Camera.main.ScreenToWorldPoint(startPos);
                deltaX = startPos.x - transform.position.x;
                deltaY = startPos.y - transform.position.y;

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)&&canDes == true)
        {
            Destroy(gameObject);
            HomeManager.current.saveData.RemoveData(data);
        }
        if(moving  )
        {
            /*
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = new Vector3(mousePos.x - deltaX, mousePos.y - deltaY);

            Vector3Int cellPos = GridBuildingSystem.current.gridLayout.WorldToCell(pos);
            transform .position = GridBuildingSystem.current.gridLayout.CellToLocalInterpolated(cellPos);
            */
            if(Input.GetMouseButtonUp(0))
            {
                canDes = false;
                time = 0;
                mousein = false;
            }
        }
    }
    #endregion
    private Vector3 startPos;
    public float deltaX, deltaY;

    protected virtual void OnClick() { }

    private void OnMouseUpAsButton()
    {
        if (moving)
        {
            moving = false;
            return;
        }
        OnClick();
    }

    private void OnApplicationQuit()
    {
        data.position = transform.position;
        //Debug.Log(data.position);
        HomeManager.current.saveData.AddData(data);
    }

    public bool mousein = false;
    private void OnMouseEnter()
    {
        mousein = true;
    }
    private void OnMouseExit()
    {
        mousein = false;
    }
}
