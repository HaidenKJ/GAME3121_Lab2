using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance;

    public GameObject explosionPrefab;
    public GameObject pickupPrefab; // for da sparkle later

    void Awake() { Instance = this; }

    public void PlayExplosion(Vector3 pos)
    {
        if (explosionPrefab != null) Instantiate(explosionPrefab, pos, Quaternion.identity);
    }
}