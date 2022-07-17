using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Item ItemDrop { get; set; }

    private void Start()
    {
        gameObject.tag = "Item";
        ItemEventHandler.onItemPickup += ItemPickedUp;
    }


    private void ItemPickedUp(Item item, GameObject gameObject)
    {
        // Definitely a better way of doing this - this feels gross
        // Why do all "Item" objects need to know if one has been looted
        // TODO: FIX!
        if(gameObject == this.gameObject)
        {
            gameObject.tag = "LootedItem";
        }
    }


}
