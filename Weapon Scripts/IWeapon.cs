using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public int AttackDamage { get; set; }
    public void PerformAttack();
}
