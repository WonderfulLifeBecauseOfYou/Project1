using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;


public class GridBuildingSystem : MonoBehaviour
{

    public static GridBuildingSystem current;

    public GridLayout gridLayout;
    public Tilemap MainTilemap;
    public TileBase takenTile;
    //unity方法
    #region Unity Methods

    private void Awake()
    {
        current = this;
    }



    #endregion


    //瓦片地图管理，用于在瓦片地图上获取和设置瓦片
    #region Tiilmap Managermant

    public static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y];
        int counter = 0;

        foreach(var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileBase type, Tilemap tilemap)
    {
        int size = area.size.x * area.size.y;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);
        tilemap.SetTilesBlock(area, tileArray);
    }


    private static void FillTiles(TileBase[] arr, TileBase tileBase)
    {
        for(int i = 0; i <arr.Length; i++)
        {
            arr[i] = tileBase;
        }
    }


    public void ClearArea(BoundsInt area, Tilemap tilemap)
    {
        SetTilesBlock(area, null, tilemap);
    }


    #endregion




    //建筑物放置
    #region Building Placement

    public GameObject InitializeWithBuilding(GameObject building, Vector3 pos, bool rawPos = false)
    {
        if (!rawPos)
        {
            pos.z = 0;
            Debug.Log(pos);
            pos.y -= building.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
            Debug.Log(pos);
            Vector3Int cellPos = gridLayout.WorldToCell(pos);
            pos = gridLayout.CellToLocalInterpolated(cellPos);
        }

        Debug.Log(pos);
        GameObject obj = Instantiate(building, pos, Quaternion.identity);
        Building temp = obj.transform.GetComponent<Building>();
        temp.gameObject.AddComponent<ObjectDrag>();


        return obj;
    }


    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);
        foreach (var b in baseArray)
        {
            if (b == takenTile)
            {
                return false;
            }
        }

        return true;
    }


    public void TakeArea(BoundsInt area)
    {
        SetTilesBlock(area, takenTile, MainTilemap);
    }
    #endregion
}
