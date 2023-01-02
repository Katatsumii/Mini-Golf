using UnityEngine;
using System;

public class HoleScript : MonoBehaviour
{
    public static event Action BallInTheHole;
    [SerializeField] private Vector2 minVelocity;
    [SerializeField] private Vector2 maxVelocity;

    private void Start()
    {
        BallInTheHole += () => { this.gameObject.GetComponent<SpriteRenderer>().enabled=false; };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            var rb=other.GetComponent<Rigidbody2D>();
            if(rb.velocity.x < maxVelocity.x && rb.velocity.x > minVelocity.x && rb.velocity.y < maxVelocity.y && rb.velocity.y > minVelocity.y)
            {
                BallInTheHole?.Invoke();
            }
            
        }
    }
}
