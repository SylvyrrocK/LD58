using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private float healAmount = 1f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("MedKitPickup", 0, 0f);

            collision.GetComponent<PlayerMovement>();
            var healthComponent = collision.GetComponent<PlayerStats>();
            if (healthComponent != null)
            {
                healthComponent.Heal(healAmount);
                Debug.Log("Curremt player health: " + healthComponent.currentHealth);
            }
            Debug.Log("Player got healed for " + healAmount + " HP");

            Destroy(gameObject, 0.7f);
        }
    }
}
