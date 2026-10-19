using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance;

    public GameObject explosionPrefab;
    public GameObject pickupPrefab;
    public GameObject confetti; // Not insatntiated, just setting active on win 

    void Awake()
    {
        Instance = this; // Singleton pattern to ensure only one instance of VFXManager exists
        if (confetti != null) confetti.SetActive(false); // This is to make the confetti gameobject inactive.
    }

    public void PlayExplosion(Vector3 pos)
    {
        Spawn(explosionPrefab, pos);
    }

    public void PlayPickup(Vector3 pos)
    {
        Spawn(pickupPrefab, pos);
    }

    public void PlayConfetti()
    {
        if (confetti != null) confetti.SetActive(true);
    }

    private void Spawn(GameObject prefab, Vector3 pos)
    {
        if (prefab != null) Instantiate(prefab, pos, Quaternion.identity);
    }
}