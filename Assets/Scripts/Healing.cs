using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private float healAmount = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>();
            var healthComponent = collision.GetComponent<PlayerStats>();
            if (healthComponent != null)
            {
                healthComponent.Heal(healAmount);
                Debug.Log("Curremt player health: " + healthComponent.currentHealth);
                Destroy(gameObject);
            }
            Debug.Log("Player got healed for " + healAmount + " HP");
        }
    }
}
