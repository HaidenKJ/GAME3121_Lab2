using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        if (Player == null) return; // player was destroyed, so the camera stays where it is

        transform.position = offset + Player.transform.position;
    }
}