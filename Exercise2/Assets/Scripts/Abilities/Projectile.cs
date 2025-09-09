using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 velocity = new();
    private float speed = 0;

    public void Initialize(Vector3 aVelocity, float aSpeed)
    {
        Destroy(gameObject, 5.0f);
        transform.up = aVelocity;
        velocity = aVelocity * aSpeed;
    }

    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
        
    }
}