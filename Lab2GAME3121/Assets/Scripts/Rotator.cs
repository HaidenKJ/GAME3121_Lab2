using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // apply delta time for update(), this is not a physics object btw
    {
        transform.Rotate(new Vector3(13, 30, 45) * Time.deltaTime);        
    }
}
