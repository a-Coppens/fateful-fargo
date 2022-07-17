using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    WEAPON,
    ARMOR
}

public interface IItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemType Type { get; set; }
    public int Value { get; set; }
    public int StatModifier { get; set; }
}
