using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject ControlesMenu;

    [Header ("buttons")]
    public Button StartB;
    public Button ControlesB;
    public Button CreditsB;
    public Button Credits_BackB;
    public Button Controles_BackB;
    public Button ExitB;

    // Start is called before the first frame update
    void Start()
    {
        StartB.onClick.AddListener(ButtonStart);
        ControlesB.onClick.AddListener(ButtonControles);
        CreditsB.onClick.AddListener(ButtonCredits);
        Credits_BackB.onClick.AddListener(CreditsButtonBack);
        Controles_BackB.onClick.AddListener(ControlesButtonBack);
        ExitB.onClick.AddListener(ButtonExit);
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    void ButtonStart ()
    {
        Debug.Log("you started the game!");
        MainMenu.SetActive(false);
    }

    void ButtonControles()
    {
        MainMenu.SetActive(false);
        ControlesMenu.SetActive(true);
    }

    void ButtonCredits()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    void CreditsButtonBack()
    {
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    void ControlesButtonBack()
    {
        MainMenu.SetActive(true);
        ControlesMenu.SetActive(false);
    }

    void ButtonExit()
    {
        Application.Quit();
    }
}
