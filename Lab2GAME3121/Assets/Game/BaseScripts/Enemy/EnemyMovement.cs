using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Player != null)
        {
            agent.SetDestination(Player.position);
        }
    }

    public void SetSpeed(float s)
    {
        agent.speed = s;
    }
}