using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject save;
    public GameObject ShopTip;
    public GameObject PlayerProperty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }
    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
    public void OpenSave()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        save.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void openPauseMenu()
    {
        
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    //打开商店提示面板
    public void openShopTip()
    {
        ShopTip.SetActive(true);
    }

    public void shutShopTip()
    {
        ShopTip.SetActive(false);
    }

    //打开角色面板
    public void openPlayerProperty()
    {
        PlayerProperty.SetActive(true);
    }

    public void shutPlayerProperty()
    {
        PlayerProperty.SetActive(false);
    }
}
