using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject menu, controls, premise;
    bool onControls, onPremise;

   
    public void MenuButton()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void ControlMenu()
    {
        menu.SetActive(false);
        controls.SetActive(true);
        onControls = true;
    }

    public void PremiseMenu()
    {
        menu.SetActive(false);
        premise.SetActive(true);
        onPremise = true;
    }

    public void Back()
    {
        if (onControls)
        {
            menu.SetActive(true);
            controls.SetActive(false);
            onControls = false;
        }
        if (onPremise)
        {
            menu.SetActive(true);
            premise.SetActive(false);
            onPremise = false;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuButton();
        }
    }
}
