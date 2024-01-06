using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantItem : MonoBehaviour
{
    public GameObject earth;
    private void Start()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
    }
    private void Update()
    {
        //gravity
        GetComponent<Rigidbody>().AddForce((earth.transform.position - transform.position).normalized * 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            if (other.GetComponent<PlayerGetHit>().plantNum < 5)
            {
                other.GetComponent<PlayerGetHit>().plantNum++;
                GameManager.instance.RefreshUI();
                Destroy(gameObject);
            }

        }
        else if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyPickUp>().canPick = false;
            Destroy(gameObject);
        }
    }
}
