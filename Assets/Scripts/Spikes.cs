using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float damageAmount = 1f; // Amount of damage spikes deal
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerMovement>().OnSpike();
            var healthComponent = collision.collider.GetComponent<PlayerStats>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(damageAmount);
                Debug.Log("Curremt player health: " + healthComponent.currentHealth);
            }
            Debug.Log("Player got damaged for " + damageAmount + " HP");
        }
    }
}
