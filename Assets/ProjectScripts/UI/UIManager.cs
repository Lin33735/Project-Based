using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject PlayerUI;
    [SerializeField] GameObject CheckList;

    public bool gamePaused;
    public bool cursorToggled;

    void Awake()
    {   
        Time.timeScale = 1.0f;
        cursorToggled = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleCursor();
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            SetActivePanel(CheckList);
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        if (cursorToggled == false)
        {
            cursorToggled = true;
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            cursorToggled = false;
            Time.timeScale = 1.0f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Resume()
    {
        PauseMenu.SetActive(false);
        PlayerUI.SetActive(true);
        gamePaused = false;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        PlayerUI.SetActive(false);
        gamePaused = true;
    }

    void SetActivePanel(GameObject name)
    {
        if (!name.activeSelf)
        {
            name.SetActive(true);
        }
        else
        {
            name.SetActive(false);
        }

    }

    public void ChangeSceneByName(string name)
    {
        if (name != null)
        {
            SceneManager.LoadScene(name);
        }
    }

    public void ResumeButton()
    {
        Resume();
    }
}