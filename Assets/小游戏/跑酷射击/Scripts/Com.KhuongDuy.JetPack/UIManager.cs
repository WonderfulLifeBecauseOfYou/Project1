using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    public GameObject garden;
    public GameObject runandshot;
    public GameObject player;
    public GameObject UI;
    public GameObject smallGames;

    public GameObject 
        gameOverMenu;

    public RectTransform playerHPBar;

    public Text 
        coinText,
        distanceTraveledText,
        scoreText,
        bestScoreText;

    public Sprite
        soundOn,
        soundOff;

    // Behaviour messages
    private float coinAmount;
    void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("UI");
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    // Behaviour messages
    private void OnEnable()
    {
        coinAmount = 0;
        if (gameOverMenu.activeInHierarchy == true)
        {
            Time.timeScale = 0.0f;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            turnback();
        }
    }

    public void UpdateCoin(float coinAmout)
    {
        coinText.text = coinAmout + "";
        coinAmount = coinAmout / 100;
    }

    public void UpdateDistance(float distance)
    {
        distanceTraveledText.text = distance + "m";
    }

    public void UpdateScore(float distance)
    {
        scoreText.text = "Score: " + distance;
        float best = PlayerPrefs.GetFloat(Constants.BEST_SCORE, 0);

        if (distance > best)
        {
            PlayerPrefs.SetFloat(Constants.BEST_SCORE, distance);
            bestScoreText.text = "Best: " + distance;
        }
        else
        {
            bestScoreText.text = "Best: " + best;
        }
    }

    public void UpdatePlayerHP(int amount)
    {
        playerHPBar.localScale = new Vector3(Mathf.Clamp01(playerHPBar.localScale.x + (amount / 100.0f)), 1.0f, 1.0f);
    }

    // Restart button is clicked
    public void RestartBtn_Onclick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("王后花园");

        SoundManager.Instance.PlaySound(Constants.CLICK_SOUND);
    }

    // Menu button is clicked
    public void MenuBtn_Onlick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");

        SoundManager.Instance.PlaySound(Constants.CLICK_SOUND);
    }

    public void GameOverShow()
    {
        

        gameOverMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Sound button is clicked
    public void SoundBtn_Onclick()
    {
        if (PlayerPrefs.GetInt(Constants.SOUND_STATE, 1) == 1)
        {
            PlayerPrefs.SetInt(Constants.SOUND_STATE, 0);

            SoundManager.Instance.TurnOffSound();
        }
        else
        {
            PlayerPrefs.SetInt(Constants.SOUND_STATE, 1);

            SoundManager.Instance.PlaySound(Constants.CLICK_SOUND);
            SoundManager.Instance.TurnOnSound();
        }
    }

    public void turnback()
    {
        MovingT0 coinscript = player.GetComponent<MovingT0>();
        coinscript.Coins += coinAmount;
        Time.timeScale = 1.0f;
        runandshot.SetActive(false);
        smallGames.SetActive(false);
        player.SetActive(true);
        garden.SetActive(true);
        Invoke("openUI", 0.1f);
    }
    private void openUI()
    {
        UI.SetActive(true);
    }
}
