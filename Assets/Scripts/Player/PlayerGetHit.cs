using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
    public float maxHp;
    public float getHitF;
    public float ContinuouBloodLoss;

    public float hp;
    public int plantNum;
    private Rigidbody rb;
    private Animator anim;
    private bool isDead;
    void Start()
    {
        hp = maxHp;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        hp -= ContinuouBloodLoss * Time.deltaTime;
        if (hp <= 0)
            CheckPlants();
    }

    public void GetHit(float damage, Vector3 vec)
    {
        hp -= damage;
        rb.AddForce(vec.normalized * getHitF);
    }

    public void Dead()
    {
        isDead = true;
        Debug.Log("You Dead");
        GameManager.instance.PlayerDead();
    }

    private void CheckPlants()
    {
        if (plantNum <= 0)
        {
            Dead();
        }
        else
        {
            plantNum--;
            hp = maxHp;
            GameManager.instance.RefreshUI();
        }
    }

    public void AddO2(float amount)
    {
        hp += amount;
        if (hp > 100)
            hp = 100;
    }

}
