using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyO2 : MonoBehaviour
{
    public float burstF;
    public float o2Amount;

    private Rigidbody rb;
    private GameObject earth;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        earth = GameObject.FindGameObjectWithTag("Earth");
        Burst();
    }

    private void Update()
    {
        //gravity
        rb.AddForce((earth.transform.position - transform.position).normalized * 1);

    }

    private void Burst()
    {
        Vector3 pos = Random.onUnitSphere;
        rb.AddForce((pos - transform.position) * burstF);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerGetHit>().AddO2(o2Amount);
            Destroy(gameObject);
        }
    }
}
