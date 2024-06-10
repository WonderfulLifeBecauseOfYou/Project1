using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public static StorageManager current;

    [SerializeField] private GameObject barnPrefab;
    //[SerializeField] private GameObject siloPrefab;
    private string itemsPath = "Storage";
    private Dictionary<AnimalProduct, int> animalProducts;
    private Dictionary<Crop, int> crops;
    private Dictionary<Feed, int> feeds;
    private Dictionary<Fruit, int> fruits;
    private Dictionary<Product, int> products;
    private Dictionary<Tool, int> tools;

    private Dictionary<CollectibleItem, int> barnItems;
    //private Dictionary<CollectibleItem, int> siloItems;

    private StorageBuilding Barn;
    //private StorageBuilding Silo;

    private void Awake()
    {
        current = this;
        Dictionary<CollectibleItem, int> itemsAmounts = LoadItems();
        Sort(itemsAmounts);

        Field.Initialize(crops);
    }


    private Dictionary<CollectibleItem, int> LoadItems()
    {
        Dictionary<CollectibleItem, int> itemAmounts = new Dictionary<CollectibleItem, int>();
        CollectibleItem[] allItems = Resources.LoadAll<CollectibleItem>(itemsPath);

        for (int i = 0; i < allItems.Length; i++)
        {
            if (allItems[i].Level >= LevelSystem.Level)
            {
                itemAmounts.Add(allItems[i], 2);
            }
        }

        return itemAmounts;
    }


    private void Sort(Dictionary<CollectibleItem, int> itemsAmounts)
    {
        animalProducts = new Dictionary<AnimalProduct, int>();
        crops = new Dictionary<Crop, int>();
        feeds = new Dictionary<Feed, int>();
        fruits = new Dictionary<Fruit, int>();
        products = new Dictionary<Product, int>();
        tools = new Dictionary<Tool, int>();

        //siloItems = new Dictionary<CollectibleItem, int>();
        barnItems = new Dictionary<CollectibleItem, int>();

        foreach (var itemPair in itemsAmounts)
        {
            if (itemPair.Key is AnimalProduct animalProduct)
            {
                animalProducts.Add(animalProduct, itemPair.Value);
                barnItems.Add(animalProduct, itemPair.Value);
            }
            else if (itemPair.Key is Crop crop)
            {
                crops.Add(crop, itemPair.Value);
                //siloItems.Add(crop, itemPair.Value);
            }
            else if (itemPair.Key is Feed feed)
            {
                feeds.Add(feed, itemPair.Value);
                barnItems.Add(feed, itemPair.Value);
            }
            else if (itemPair.Key is Fruit fruit)
            {
                fruits.Add(fruit, itemPair.Value);
                //siloItems.Add(fruit, itemPair.Value);
            }
            else if (itemPair.Key is Product product)
            {
                products.Add(product, itemPair.Value);
                barnItems.Add(product, itemPair.Value);
            }
            else if (itemPair.Key is Tool tool)
            {
                tools.Add(tool, itemPair.Value);
                barnItems.Add(tool, itemPair.Value);
            }
        }
    }

    private void Start()
    {
        //GameObject barnObject = GridBuildingSystem.current.InitializeWithBuilding(barnPrefab, new Vector3(6f, -0.25f));
        Barn = barnPrefab.GetComponent<StorageBuilding>();
        Barn.Initialize(barnItems, "Barn");
    }

    public int GetAmount(CollectibleItem item)
    {
        int amount = 0;
        if (item is AnimalProduct animalProduct)
        {
            animalProducts.TryGetValue(animalProduct, out amount);
        }
        else if (item is Crop crop)
        {
            crops.TryGetValue(crop, out amount);
        }
        else if (item is Feed feed)
        {
            feeds.TryGetValue(feed, out amount);
        }
        else if (item is Fruit fruit)
        {
            fruits.TryGetValue(fruit, out amount);
        }
        else if (item is Product product)
        {
            products.TryGetValue(product, out amount);
        }
        else if (item is Tool tool)
        {
            tools.TryGetValue(tool, out amount);
        }
        return amount;
    }

    public bool IsEnoughOf(CollectibleItem item, int amount)
    {
        return GetAmount(item) >= amount;
    }

    public void UpdateItems(Dictionary<CollectibleItem, int> items, bool add)
    {
        //go through each item in the dictionary
        foreach (var itemPair in items)
        {
            //get the item
            var item = itemPair.Key;
            //get its amount
            var amount = itemPair.Value;

            //if we're not adding
            if (!add)
            {
                //make the amount negative
                amount = -amount;
            }

            //determine the type of the item
            if (item is AnimalProduct animalProd)
            {
                //add thee item amount to the appropriate dictionaries
                animalProducts[animalProd] += amount;
                barnItems[item] += amount;
            }
            else if (item is Crop crop)
            {
                crops[crop] += amount;
                barnItems[item] += amount;
            }
            else if (item is Feed feed)
            {
                feeds[feed] += amount;
                barnItems[item] += amount;
            }
            else if (item is Fruit fruit)
            {
                fruits[fruit] += amount;
                barnItems[item] += amount;
            }
            else if (item is Product product)
            {
                products[product] += amount;
                barnItems[item] += amount;
            }
            else if (item is Tool tool)
            {
                tools[tool] += amount;
                barnItems[item] += amount;
            }
        }
    }
}
