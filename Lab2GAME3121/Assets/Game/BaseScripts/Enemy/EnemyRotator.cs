using UnityEngine;
public class EnemyRotator : MonoBehaviour
{
    void Update() 
    {
        transform.Rotate(new Vector3(45, 70, 45) * Time.deltaTime);
    }
}
