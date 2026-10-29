using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent JimmothyRectangle;

    void Awake()
    {
        JimmothyRectangle = GetComponent<NavMeshAgent>();
        JimmothyRectangle.speed = GameSettings.EnemySpeed;
    }

    void Update()
    {
        if (Player != null)
        {
            JimmothyRectangle.SetDestination(Player.position);
        }
    }

    public void SetSpeed(float s)
    {
        JimmothyRectangle.speed = s;
    }
}