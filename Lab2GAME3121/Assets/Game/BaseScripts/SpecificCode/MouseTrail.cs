using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TrailRenderer))]
public class MouseTrail : MonoBehaviour
{
    [Header("Look")]
    public Color startColor = new Color(1f, 0.9f, 0.3f, 1f);
    public Color endColor = new Color(1f, 0.4f, 0.1f, 0f);
    public float width = 0.05f;
    public float lifetime = 0.35f;

    [Header("Placement")]
    public float distanceFromCamera = 1f;

    private Camera cam;
    private TrailRenderer trail;

    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();

        trail.time = lifetime;
        trail.startWidth = width;
        trail.endWidth = 0f;
        trail.startColor = startColor;
        trail.endColor = endColor;
        trail.numCapVertices = 4;

        if (trail.sharedMaterial == null)
        {
            trail.material = new Material(Shader.Find("Sprites/Default"));
        }
    }

    void Update()
    {
        if (Mouse.current == null || cam == null) return;

        Vector2 pos = Mouse.current.position.ReadValue();
        transform.position = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, distanceFromCamera));
    }
}

// I added this because I thought it would be cool and good for a theme... but this doesn't exactly define a theme tho...