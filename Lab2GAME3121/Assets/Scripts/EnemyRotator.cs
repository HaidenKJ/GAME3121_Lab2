using UnityEngine;
public class EnemyRotator : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    void Update() // apply delta time for update(), this is not a physics object btw
    {
        transform.Rotate(new Vector3(45, 70, 45) * Time.deltaTime);
    }
}
