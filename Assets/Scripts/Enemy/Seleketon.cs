using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleketon : Enemy
{
    private float distance;

    private void Update()
    {
        CheckAttackF();
    }

    private void CheckAttackF()
    {

        if (!target.gameObject.activeInHierarchy || target == null)
        {
            return;
        }

        distance = Vector2.Distance(transform.position, target.position);

        if(distance <= rangeAttack)
        {
            Attack();
        }

    }
    public override void Attack()
    {
        base.Attack();

        if (!canAttack)
        {
            return;
        }


        //Logic Attack
        canAttack = false;

    }

    public void SetCanAttack()
    {
        canAttack = true;
    }

    public void DameF()
    {
        if (distance <= rangeAttack)
        {
            Debug.Log("Cắn trúng");
            target.GetComponent<Health>().TakeDamage(damage);
        }
        else
        {
            Debug.Log("Cắn xịt");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DamageZone" || collision.tag =="Bullet")
        {
            if(health != null)
            {
                health.TakeDamage(damage);
            }
            else
            {
                Debug.Log(health);
            }

            if(collision.tag == "Bullet")
            {
                collision.gameObject.SetActive(false);
            }
        }
    }

    public void InActive()
    {
        gameObject.SetActive(false);
    }
}