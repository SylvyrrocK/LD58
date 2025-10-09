using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerMovement>().OnSpike();
            var healthComponent = collision.collider.GetComponent<PlayerStats>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1f); // Assuming spikes deal 1 damage
                Debug.Log("Curremt player health: " + healthComponent.currentHealth);
            }
            Debug.Log("Player hit spikes!");
            // Here you can add logic to reduce player health or restart the level
        }
    }
}
