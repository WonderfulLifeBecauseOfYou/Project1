using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StorageBuilding : MonoBehaviour
{
    private StorageUI storageUI;

    private int currentTotal = 0;
    private int storageMax = 100;

    public string Name { get; private set; }

    [SerializeField] private GameObject windowPrefab;
    [SerializeField] private List<Tool> itemsToIncrease;

    private Dictionary<CollectibleItem, int> items;
    private Dictionary<CollectibleItem, int> tools;


    public void Initialize(Dictionary<CollectibleItem, int> itemAmounts, string name)
    {
        Name = name;

        GameObject window = Instantiate(windowPrefab, HomeManager.current.canvas.transform);
        window.SetActive(false);
        storageUI = window.GetComponent<StorageUI>();

        storageUI.SetNameText(name);

        items = itemAmounts;
        currentTotal = itemAmounts.Values.Sum();

        tools = new Dictionary<CollectibleItem, int>();
        foreach (var item in itemsToIncrease)
        {
            tools.Add(item, 1);
        }

        storageUI.Initialize(currentTotal, storageMax, items, tools, IncreaseStorage);
    }

    private void IncreaseStorage()
    {
        foreach (var toolPair in tools)
        {
            if (!StorageManager.current.IsEnoughOf(toolPair.Key, toolPair.Value))
            {
                Debug.Log("Not enough tools");
                return;
            }
        }

        storageMax += 50;

        storageUI.Initialize(currentTotal, storageMax, items, tools, IncreaseStorage);
    }

    public virtual void onClick()
    {
        storageUI.gameObject.SetActive(true);
    }

    private void OnMouseUpAsButton()
    {
        onClick();
    }

}
