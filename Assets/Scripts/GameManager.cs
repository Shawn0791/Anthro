using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public O2 o2;
    public GameObject playerDeadUI;

    private int GiveNum;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void RefreshUI()
    {
        o2.RefreshUI();
    }

    public void PlayerDead()
    {
        playerDeadUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GivePlant()
    {
        GiveNum++;
    }
}
