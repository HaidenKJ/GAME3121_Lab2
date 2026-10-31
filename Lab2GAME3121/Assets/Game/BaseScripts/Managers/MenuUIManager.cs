using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject instructionsPanel;
    public GameObject settingsPanel;

    [Header("Audio UI")]
    public Slider volumeSlider;
    public Toggle musicToggle;

    private PlayerController playerController;
    private EnemyMovement enemyMovement;

    void Awake()
    {
        GameSettings.ResetToDefaults(); // Setting music, enemy speed and otehr changes back to defaults since I don't want changes to carry over
        playerController = FindAnyObjectByType<PlayerController>();
        enemyMovement = FindAnyObjectByType<EnemyMovement>();

        SetGameActive(false);  
    }
    void Start()
    {
        mainMenuPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);

        AudioManager.Instance.SetMusicVolume(GameSettings.MusicVolume);
        AudioManager.Instance.SetMusicMuted(!GameSettings.MusicOn);
        enemyMovement.SetSpeed(GameSettings.EnemySpeed);

        volumeSlider.onValueChanged.AddListener(SetVolume);
        musicToggle.onValueChanged.AddListener(ToggleMusic);
    }

    void SetGameActive(bool active)
    {
        playerController.enabled = active;
        enemyMovement.enabled = active;

        if (active)
        {
            Debug.Log("Game is now ACTIVE! Player and enemies can move now.");
        }
        else
        {
            Debug.Log("Game is now INACTIVE! Player and enemy movement are disabled.");
        }
    }
    public void PlayGame()          
    { 
        mainMenuPanel.SetActive(false);
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

    public void BackToMenu()
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

    public void SetVolume(float value)
    {
        Debug.Log("SetVolume called: " + value);
        GameSettings.MusicVolume = value;
        AudioManager.Instance.SetMusicVolume(value);
    }

    public void ToggleMusic(bool isOn)
    {
        Debug.Log("ToggleMusic called: " + isOn);
        GameSettings.MusicOn = isOn;
        AudioManager.Instance.SetMusicMuted(!isOn);
    }
    public void SetEnemySpeed(float s)
    {
        GameSettings.EnemySpeed = s;
        enemyMovement.SetSpeed(s);
    }

    public void SetCustomEnemySpeed(string input)
    {
        if (float.TryParse(input, out float speed))
        {
            speed = Mathf.Max(0f, speed);
            GameSettings.EnemySpeed = speed;
            enemyMovement.SetSpeed(speed);
        }
    }
}