using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEventHandler : MonoBehaviour
{
    public delegate void EnemyEventHandler(IEnemy enemy);
    public static event EnemyEventHandler onEnemyDeath;

    public static void EnemyDeath(IEnemy enemy)
    {
        onEnemyDeath?.Invoke(enemy);
    }
}
