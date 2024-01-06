using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public O2 o2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerGetHit>().plantNum < 5) 
            {
                other.GetComponent<PlayerGetHit>().plantNum++;
                o2.RefreshUI();
                Destroy(gameObject);
            }
        }
    }
}
