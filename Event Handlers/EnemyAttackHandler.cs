using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler
{
    public delegate void EnemyAttackedHandler(IEnemy attacker);
    public static event EnemyAttackedHandler onEnemyAttack;

    public static void EnemyAttackedPlayer(IEnemy attacker)
    {
        onEnemyAttack?.Invoke(attacker);
    }
}
