using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour, IEnemy
{
    public int ID { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Move these to EnemyAIController
    /// </summary>
    [SerializeField]
    private float attackCooldown;
    private float attackRadius;

    Transform target;

    private void Start()
    {
        // Hardcoded for now Sadge
        ID = 2;
        Health = 500;
        Damage = 10;
        Name = "Golem";
        gameObject.tag = "Enemy";

        attackCooldown = 0f;
        attackRadius = 12.5f;

        target = PlayerManager.instance.player.transform;
    }

    private void Update()
    {
        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }
        DoAttack();
    }


    public void TakeDamage(int damageTaken)
    {
        Health -= damageTaken;
        if (Health <= 0)
        {
            Die();
        }
        Debug.Log($"{this.Name} took {damageTaken} damage!");
    }


    // TODO: Put this in EnemyAIController
    public void DoAttack()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= attackRadius)
        {
            if (attackCooldown <= 0f)
            {
                attackCooldown = 2f;
                EnemyAttackHandler.EnemyAttackedPlayer(this);
            }
        }

    }

    // Maybe Make IEnemy Abstract instead? Saves us writing the same over and over
    public void Die()
    {
        CombatEventHandler.EnemyDeath(this);
        ItemSpawner.SpawnItem(gameObject.transform);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }


}
