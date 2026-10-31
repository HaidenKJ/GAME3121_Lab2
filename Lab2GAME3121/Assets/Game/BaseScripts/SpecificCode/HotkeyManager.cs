using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HotkeyManager : MonoBehaviour // Adding Quit & Restart Buttons for users and for my convience while testing
{
    void Update() // This only works in builds
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("Esc pressed, quitting");
            Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}