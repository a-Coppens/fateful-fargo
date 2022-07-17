using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static GameObject item { get; set; }
    public static ItemSpawner Instance { get; set; }   

    private void Awake()
    {
        item = GameObject.Find("SM_Prop_Chest_01");
        Instance = this;
    }

    public static void SpawnItem(Transform pos)
    {
        GameObject a = Instantiate(item, pos.position, pos.rotation);
        Debug.Log("Item Spawned at" + pos.ToString());
    }
}
