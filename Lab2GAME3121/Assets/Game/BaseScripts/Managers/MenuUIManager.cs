using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject instructionsPanel;
    public GameObject settingsPanel;

    [Header("Audio UI")]
    public Slider volumeSlider;
    public Toggle musicToggle;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        settingsPanel.SetActive(false);

        volumeSlider.value = GameSettings.MusicVolume;
        musicToggle.isOn = GameSettings.MusicOn;
    }

    public void PlayGame()          
    { 
        SceneManager.LoadScene("GameScene"); 
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
        GameSettings.MusicVolume = value; 
    }
    public void ToggleMusic(bool isOn)   
    { 
        GameSettings.MusicOn = isOn; 
    }
    public void SetEnemySpeed(float s)   
    { 
        GameSettings.EnemySpeed = s; 
    }

    public void SetCustomEnemySpeed(string input)
    {
        if (float.TryParse(input, out float speed))
        {
            GameSettings.EnemySpeed = Mathf.Max(0f, speed);
        }
    }
}