using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float Health;
    private Transform target;
    private Vector3 velocity;
    
    private void Start()
    {
        target = GameObject.FindAnyObjectByType<Player>().transform;
    }

    private void Update()
    {
        velocity = (target.position - transform.position).normalized;
        transform.position += velocity * MovementSpeed * Time.deltaTime;
    }

    public void TakeDamage(float someDamage)
    {
        Health -= someDamage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
