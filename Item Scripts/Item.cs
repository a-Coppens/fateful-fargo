using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemType Type { get; set; }
    public int Value { get; set; }
    public int StatModifier { get; set; }

    [Newtonsoft.Json.JsonConstructor]
    public Item(string name, string desc, ItemType itemType, int value, int statModifier)
    {
        Name = name;   
        Description = desc;
        Type = itemType;
        Value = value;
        StatModifier = statModifier;
    }
}

