using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health =
                collision.gameObject.GetComponent<PlayerHealth>();

            health.TakeDamage();
        }
    }
}
