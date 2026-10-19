using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public float movementSpeed = 5.0f;
    private float movementX;
    private float movementZ;

    private int count;
    public TextMeshProUGUI countText;
    public GameObject WinText;

    private bool gameEnded = false;
    private float lastWallSound = -1f;

    public GameObject explosionPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        WinText.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 movemement = new Vector3(movementX, 0.0f, movementZ);
        rb.AddForce(movemement * movementSpeed);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameEnded) return;

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            if (count >= 15)
            {
                gameEnded = true;
                WinText.SetActive(true);
                AudioManager.Instance.StopMusic();
                AudioManager.Instance.PlaySFX(AudioManager.Instance.winSound);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameEnded) return;

        if (collision.gameObject.CompareTag("Wall"))
        {
            // Cooldown so rolling along a wall doesn't spam the sound
            if (Time.time - lastWallSound > 0.2f)
            {
                lastWallSound = Time.time;
                AudioManager.Instance.PlayWallHit(); // <-- changed: random clip from the pool
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameEnded = true;
            WinText.SetActive(true);
            WinText.GetComponent<TextMeshProUGUI>().text = "YOU LOST!";

            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayAtPoint(AudioManager.Instance.deathSound, transform.position); // PlayClipAtPoint survives the player being destroyed

            VFXManager.Instance.PlayExplosion(transform.position); // The explosion 

            Destroy(gameObject);
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString() + "/15";
    }
}