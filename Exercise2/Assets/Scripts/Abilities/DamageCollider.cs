using System;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    Enemy enemy = collision.GetComponent<Enemy>();
    if (enemy != null)
    {
      enemy.TakeDamage(1);
    }
  }
}
