using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int Damage;
    // Out of scope for now
    //public int Defense;
    public int Health;
    public RaycastHit hit;

    void Start()
    {
        Damage = 2;
        // Out of scope for now
        // Defense = 1;
        Health = 20;
        ItemEventHandler.onItemPickup += ModifyStatsByItem;
        EnemyAttackHandler.onEnemyAttack += TakeDamage;
    }

    private void Update()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 15);

        if(hit.collider != null)
        {
            if (hit.transform.tag == "Item" && Input.GetButtonDown("Interact"))
            {
                LootItem();
            }
            if(hit.transform.tag == "Enemy" && Input.GetButtonDown("LMouseButton"))
            {
                Debug.Log(hit.transform.gameObject);
                Attack(hit.transform.gameObject.GetComponent<IEnemy>());
            }
        }

        if(Health <= 0)
        {
            Die();
        }

        Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
    }

    private void LootItem()
    {
        Item item = ItemDB.Instance.GetRandomItem();
        Debug.Log(item.Name);
        ItemEventHandler.ItemPickedUp(item, hit.transform.gameObject);
    }

    private void Attack(IEnemy enemy)
    {
        enemy.TakeDamage(Damage);
    }

    private void TakeDamage(IEnemy enemy)
    {
        Health -= enemy.Damage;
    }

    private void ModifyStatsByItem(Item item, GameObject gameObject)
    {
        switch(item.Type)
        {
            case ItemType.WEAPON:
                this.Damage += item.StatModifier;
                Debug.Log(this.Damage);
                break;

            case ItemType.ARMOR:
                this.Health += item.StatModifier;
                Debug.Log(this.Health);
                break;
        }
    }
    
    private void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
