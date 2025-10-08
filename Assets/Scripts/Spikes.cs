using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerMovement>().OnSpike();
            Debug.Log("Player hit spikes!");
            // Here you can add logic to reduce player health or restart the level
        }
    }
}
