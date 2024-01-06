using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject plantPrefab;
    public Transform throwPos;
    public float throwF;

    private void Update()
    {
        ThrowPlant();
    }
    private void ThrowPlant()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GetComponent<PlayerGetHit>().plantNum > 0)
            {
                GetComponent<PlayerGetHit>().plantNum--;
                GameManager.instance.RefreshUI();

                GameObject plant=Instantiate(plantPrefab, throwPos.position, transform.rotation);
                plant.GetComponent<Rigidbody>().AddForce((throwPos.position - transform.position) * throwF);
            }
        }
    }
}
