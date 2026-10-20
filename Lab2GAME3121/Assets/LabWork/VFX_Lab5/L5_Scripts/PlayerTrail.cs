using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, -0.3f, 0f);

    void LateUpdate()
    {
        if (player == null) // Player was destroyed so stop emitting, but let existing particles fade
        {
            var ps = GetComponent<ParticleSystem>();
            if (ps != null && ps.isEmitting) ps.Stop();
            return;
        }

        transform.position = player.position + offset;
    }
}