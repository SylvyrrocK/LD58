using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 3f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // Here you can add logic to restart the level or show game over screen
    }
}
