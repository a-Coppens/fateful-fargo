using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEventHandler : MonoBehaviour
{
    public delegate void ItemPickedUpHandler(Item item, GameObject gameObject);
    public static event ItemPickedUpHandler onItemPickup;

    public static void ItemPickedUp(Item item, GameObject gameObject)
    {
        onItemPickup?.Invoke(item, gameObject);
    }
}
