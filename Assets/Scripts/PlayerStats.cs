using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 3f;
    public float currentHealth;

    [Header("UI Elements")]
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Sprite halfHeart;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        for(int i =0; i < hearts.Length; i++)
        {
            if (i < Mathf.FloorToInt(currentHealth))
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i < currentHealth)
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            hearts[i].enabled = i < Mathf.CeilToInt(maxHealth);

            if(i < Mathf.FloorToInt(maxHealth))
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
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
