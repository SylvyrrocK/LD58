using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    [SerializeField] float animationSpeed = 1f;
    [SerializeField] float amplitude = 0.5f;

    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * animationSpeed) * amplitude;
        transform.position = new Vector2(startPosition.x, newY);
    }
}
