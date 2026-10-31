using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSFX : MonoBehaviour
{
    void Start()
    {
        foreach (Button b in FindObjectsByType<Button>(FindObjectsInactive.Include)) // true = also include buttons on inactive panels (Settings, Instructions)
        {
            b.onClick.AddListener(() => AudioManager.Instance.PlayButtonClick());
        }
    }
}