using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2 : MonoBehaviour
{
    public PlayerGetHit player;
    public GameObject[] icons;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        RefreshUI();
    }

    void Update()
    {
        slider.value = player.hp / player.maxHp;
    }

    public void RefreshUI()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(false);
        }

        for (int i = 0; i < player.plantNum; i++)
        {
            icons[i].SetActive(true);
        }
    }
}
