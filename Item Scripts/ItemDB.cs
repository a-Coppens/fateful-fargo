using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDB : MonoBehaviour 
{
    public static ItemDB Instance { get; set; }
    private List<Item> items { get; set; }

    // Singleton Class
    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            BuildItemDataStore();
        }
     
    }

    private void BuildItemDataStore()
    {
        items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/items").ToString());
        Debug.Log(items[0].Name + items[0].Description);
    }

    public Item GetRandomItem()
    {
        System.Random r = new System.Random();
        return Instance.items[r.Next(items.Count)];
    }
}
