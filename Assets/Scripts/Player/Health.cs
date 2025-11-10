using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float total_hp;
    private float current_hp;
    private float def;
    private bool isDie;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isDie = false;
    }

    private void Start()
    {
        Revive();
    }

    public void TakeDamage(float damage)
    {
        if(isDie == true)
        {
            return;
        }

        float real_dame;
        real_dame = damage - def;
        if (real_dame <= 0)
        {
            real_dame = 1;
        }
        current_hp = Mathf.Clamp(current_hp - real_dame, 0, total_hp);

        animator.SetTrigger("TakeDame");
        if(current_hp == 0)
        {
            Debug.Log(gameObject.name + "Die");
            animator.SetTrigger("Die");
            isDie = true;
        }
    }

    public void Revive()
    {
        total_hp = 100f;
        current_hp = total_hp;
        def = 1f;
    }    
}