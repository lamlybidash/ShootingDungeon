using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string nameE;
    public float damage;
    public float timePerShot;
    public float rangeAttack;
    public string acName;
    protected string _attackACName;
    protected string _reloadACName;
    protected bool canAttack;

    public GameObject unitPfb;
    public Transform target;
    public Animator animator;
    public Health health;


    public EnemyData data;


    private void Awake()
    {
        InitData();
    }

    public void InitData()
    {
        nameE = data.nameE;
        damage = data.damage;
        unitPfb = data.unitPfb;
        timePerShot = data.timePerShot;
        rangeAttack = data.rangeAttack;
        acName = data.acName;
        _attackACName = acName + "_attack";
        _reloadACName = acName + "_reload";
        canAttack = true;
        Debug.Log("HEALTHHHH");
        Debug.Log(health);
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();

    }

    public virtual void Attack()
    {
        if (!canAttack && target != null)
        {
            return;
        }
        if (!string.IsNullOrEmpty(_attackACName))
        {
            SoundManager.Instance.PlaySFX(_attackACName);
        }

        //Set animation
        animator.SetTrigger("Attack");
    }
}

