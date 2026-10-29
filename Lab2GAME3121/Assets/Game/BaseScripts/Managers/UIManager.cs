using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Game Objeccts")]
    public PlayerController playerController;
    public EnemyMovement enemyMovement; // enemy script from Lab 5

    [Header("Panels")]
    public GameObject mainMenuPanel;// title + menu buttons
    public GameObject instructionsPanel;
    public GameObject settingsPanel;

    [Header("Audio")]
    public AudioSource music;
    public Slider volumeSlider;
    public Toggle musicToggle;

    void Start()
    {
        // Game is frozen until Play is clicked
        playerController.enabled = false;
        enemyMovement.enabled = false;

        mainMenuPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);

        volumeSlider.value = music.volume;
    }
    public void PlayGame()
    {
        playerController.enabled = true;
        enemyMovement.enabled = true;
        mainMenuPanel.SetActive(false); // hides title + buttons
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
    public void BackToMenu() // Back button + X button
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
    public void SetVolume(float value) // In-game audio slider
    {
        music.volume = value;
    }

    public void ToggleMusic(bool isOn) // In-game Music toggle
    {
        music.mute = !isOn;
    }

    public void SetEnemySpeed(float speed) // Set speeds for enemy 
    {
        enemyMovement.SetSpeed(speed);
    }
}