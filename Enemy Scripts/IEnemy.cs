using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public int ID { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public string Name { get; set; }

    public void TakeDamage(int damageTaken);
    public void DoAttack();
    public void Die();
}
