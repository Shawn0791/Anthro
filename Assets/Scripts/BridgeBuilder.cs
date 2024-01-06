using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBuilder : MonoBehaviour
{
    public GameObject[] bridges;
    private bool isBuilt;
    private bool isPlant;
    private bool canBuilt;
    private PlayerGetHit player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerGetHit>();
            canBuilt = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canBuilt = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (player.plantNum >= 1 && !isBuilt && canBuilt) 
            {
                player.plantNum--;
                isBuilt = true;
                GameManager.instance.RefreshUI();

                for (int i = 0; i < bridges.Length; i++)
                {
                    if (!isPlant)
                    {
                        //bridges[i].GetComponent<Bridge>().ShowBridge();
                        bridges[i].SetActive(true);
                    }
                    else
                    {
                        //bridges[i].GetComponent<Bridge>().FadeBridge();
                    }
                }
            }
        }
    }
}
