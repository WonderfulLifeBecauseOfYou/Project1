using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class HSaveData
{
    public static int IdCount;

    public Dictionary<string,List < HPlaceableObjectData>> placeableObjectDatas = new Dictionary<string, List<HPlaceableObjectData>>();


    public static string GenerateId()
    {
        IdCount++;
        return IdCount.ToString();
    }

    public void AddData(HData data)
    {
        if(data is HPlaceableObjectData plObjdata)
        {
            List<HPlaceableObjectData> list;
            if (placeableObjectDatas.TryGetValue (plObjdata.ID,out list ))
            {
                if (!list.Contains(plObjdata))
                    list.Add(plObjdata);
            }
            else
            {
                list = new List<HPlaceableObjectData>();
                list.Add(plObjdata);
                placeableObjectDatas.Add(plObjdata.ID, list);
            }
        }
    }



    public void RemoveData(HData data)
    {
        if(data is HPlaceableObjectData plObjData)
        {
            List<HPlaceableObjectData> list;
            if (placeableObjectDatas.TryGetValue (plObjData.ID,out list))
            {
                list.Remove(plObjData);
                if(list .Count == 0)
                {
                    placeableObjectDatas.Remove(plObjData.ID);
                }
            }
        }
    }

    [OnDeserialized]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        placeableObjectDatas ??= new Dictionary<string, List<HPlaceableObjectData>>();
    }

}
