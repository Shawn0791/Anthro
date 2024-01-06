using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Material mate;
    public float speed;
    public bool isActived;

    private float threshold;
    private float edgeLength;
    private bool isFade;

    public void FadeBridge()
    {
        threshold = 0;
        edgeLength = 0.06f;
        isFade = true;
        isActived = true;
    }

    public void ShowBridge()
    {
        threshold = 0.5f;
        edgeLength = 0;
        isFade = false;
        isActived = true;
    }


    private void Update()
    {
        if (isActived)
        {
            mate.SetFloat("_Threshold", threshold);
            mate.SetFloat("_EdgeLength", edgeLength);
            if (isFade)
            {
                threshold += speed * Time.deltaTime;
            }
            else
            {
                threshold -= speed * Time.deltaTime;
            }

            Invoke("Deactivate", 15);
        }
    }

    private void Deactivate()
    {
        isActived = false;
    }
}
