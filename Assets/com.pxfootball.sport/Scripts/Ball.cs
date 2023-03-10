using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float force = 6;
    private Vector2 LastVelocity { get; set; }
    private Rigidbody2D Rigidbody { get; set; }

    public static Action OnCollided { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = new Vector2(0, -0.317f);
        Rigidbody.velocity = Vector2.down * force;
    }

    private void Update()
    {
        LastVelocity = Rigidbody.velocity;

        if(LastVelocity.magnitude < 1)
        {
            GameManager.Instance.RespawnBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(SettingsManager.VibraEnable)
        {
            Handheld.Vibrate();
        }

        OnCollided?.Invoke();
        float speed = LastVelocity.magnitude;

        Vector2 direction = Vector2.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        Rigidbody.velocity = direction * Mathf.Max(force, force);
    }
}
