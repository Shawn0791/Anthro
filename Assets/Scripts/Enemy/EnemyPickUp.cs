using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPickUp : MonoBehaviour
{
    public float moveSpeed;
    public bool canPick;

    private GameObject target;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canPick &&
            GetComponent<EnemyGetHit>().isDead == false &&
            target != null)
        {
            Vector3 dis = target.transform.position - transform.position;
            rb.AddForce(Vector3.Dot(dis, transform.forward) * transform.forward.normalized * moveSpeed);

            transform.forward = dis.normalized;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlantItem"))
        {
            GetComponent<EnemyMovement>().isChasing = false;
            GetComponent<EnemyMovement>().isAttacking = false;
            canPick = true;
            target = GameObject.FindGameObjectWithTag("PlantItem");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlantItem"))
        {
            canPick = false;
            target = null;
        }
    }
}
