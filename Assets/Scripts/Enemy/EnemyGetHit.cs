using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetHit : MonoBehaviour
{
    public float maxHp;
    public float getHitF;
    public GameObject o2Prefab;
    public float minO2;
    public float maxO2;

    private float hp;
    private Rigidbody rb;
    public bool isDead;
    void Start()
    {
        hp = maxHp;
        rb = GetComponent<Rigidbody>();
    }

    public void GetHit(float damage, Vector3 vec)
    {
        hp -= damage;
        rb.AddForce(vec.normalized * getHitF);
        CheckHp();
    }

    private void CheckHp()
    {
        if (hp <= 0)
            Dead();
    }

    private void Dead()
    {
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<OnSphere>().isDead = true;

        float num = Random.Range(minO2, maxO2);
        for (int i = 0; i < num; i++)
        {
            Instantiate(o2Prefab, transform.position+transform.up, transform.rotation);
        }

        Debug.Log("enemy dead");
    }
}
