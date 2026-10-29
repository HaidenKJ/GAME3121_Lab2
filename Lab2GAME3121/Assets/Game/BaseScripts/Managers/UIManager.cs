using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Game Objeccts")] 
    public PlayerController playerController;
    public EnemyMovement enemyMovement; // enemy script from Lab 5

    [Header("Panels")]
    public GameObject mainMenuPanel;// title + menu buttons
    public GameObject instructionsPanel;
    public GameObject settingsPanel;

    [Header("In-Game UI")] 
    public GameObject scoreText; // score TMP object
    public GameObject winText; // WinText object

    [Header("Audio UI")]
    public Slider volumeSlider;
    public Toggle musicToggle;


    void Start()
    {
        SetGameActive(false); 

        mainMenuPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);

        volumeSlider.value = AudioManager.Instance.MusicVolume;
    }

    // One place that controls whether the game is running
    void SetGameActive(bool active)
    {
        playerController.enabled = active;
        enemyMovement.enabled = active;
        scoreText.SetActive(active);

        if (!active)
        {
            winText.SetActive(false);
        }
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false); // hides title and buttons
        SetGameActive(true);
    }

    public void ShowInstructions()
    {
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMenu() // Back button or X button
    {
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit pressed");
        Application.Quit();
    }

    public void SetVolume(float value) // Volume slider
    {
        AudioManager.Instance.SetMusicVolume(value);
    }

    public void ToggleMusic(bool isOn) // Music toggle
    {
        AudioManager.Instance.SetMusicMuted(!isOn);
    }

    public void SetEnemySpeed(float speed) // Set speeds for enemy
    {
        enemyMovement.SetSpeed(speed);
        Debug.Log("Current Speed is set to " + speed);
    }
    public void SetCustomEnemySpeed(string input)
    {
        if (float.TryParse(input, out float speed))
        {
            speed = Mathf.Max(0f, speed); // no negitives
            enemyMovement.SetSpeed(speed);
        }
        else
        {
            Debug.Log("Invalid speed entered");
        }
    }
}