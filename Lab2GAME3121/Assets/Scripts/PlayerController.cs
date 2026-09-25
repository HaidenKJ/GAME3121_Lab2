using System.Reflection.Metadata.Ecma335;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] public float movementSpeed = 5.0f;
    private float movementX;
    private float movementZ; // We're not moving along y-axis

    private int count;
    public TextMeshProUGUI countText;
    public GameObject WinText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        WinText.SetActive(false);
    }

    void FixedUpdate() // Don't use Update() for physics stuff
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
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        
        if (count >= 15)
        {
            WinText.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            WinText.SetActive(true);
            WinText.GetComponent<TextMeshProUGUI>().text = "YOU LOST!";
            Destroy(gameObject);
        }

    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString() + "/15";
    }

}
