using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update() // Used for rotating the pickup item
    {
        transform.Rotate(new Vector3(13, 30, 45) * Time.deltaTime);        
    }
}
