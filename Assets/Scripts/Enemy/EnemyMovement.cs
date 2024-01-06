using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float chaseSpeed;
    public float attackDis;
    public float viewDis;
    public float damage;
    public bool isChasing;
    public bool isAttacking;

    private GameObject player;
    private Rigidbody rb;
    private Animator anim;
    private Vector3 moveAmount, smoothMoveVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float dis = Vector3.Distance(player.transform.position, transform.position);
        if (isChasing && dis < viewDis && dis >= attackDis) 
        {
            Chasing();
        }
        else if (isAttacking)
        {
            Attack();
        }

        if (Vector3.Distance(player.transform.position, transform.position) < attackDis&&isChasing)
        {
            Debug.Log("canAttack");
            isChasing = false;
            isAttacking = true;
        }
    }

    private void Chasing()
    {
        Vector3 dis = player.transform.position - transform.position;
        rb.AddForce(Vector3.Dot(dis, transform.forward) * transform.forward.normalized * chaseSpeed);

        transform.forward = dis.normalized;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");// isChacing=true when animation finished
        isAttacking = false;
    }

    public void AttackFinished()
    {
        isChasing = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerGetHit>().GetHit(damage, other.transform.position - transform.position);
        }
    }

}
