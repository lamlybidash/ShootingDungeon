using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speedMove;
    private Enemy enemyCpn; //EnemyComponent
    private Animator animator;
    private Transform target;

    private float rangeAttack;
    private void Awake()
    {
        enemyCpn = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        target = enemyCpn.target;
        rangeAttack = enemyCpn.rangeAttack;
    }

    private void Update()
    {
        LogicMove();
    }

    private void LogicMove()
    {
        if (!target.gameObject.activeInHierarchy || target == null)
        {
            animator.SetBool("Run", false);
            return;
        }

        float distance;
        distance = Vector2.Distance(transform.position, target.position);

        if (distance < rangeAttack - 0.01f)
        {
            animator.SetBool("Run", false);
            return;
        }
        
        animator.SetBool("Run", true);

        Vector3 direct = (target.position - transform.position).normalized;
        transform.position += new Vector3(direct.x, direct.y, transform.position.z) * Time.deltaTime * speedMove;
        Flip(direct);
    }

    private void Flip(Vector3 direct)
    {
        int i = 0;
        if (direct.x < 0)
        {
            i = 1;
        }

        transform.rotation = Quaternion.Euler(0, i * 180, 0);
    } 
}
