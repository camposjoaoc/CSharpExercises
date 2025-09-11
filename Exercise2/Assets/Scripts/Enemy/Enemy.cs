using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float MovementSpeed; // Movement speed of the enemy
    [SerializeField] private float Health; // Health of the enemy
    private Transform target; //Temporary target position
    private Vector3 velocity;
    
    /*
    private void Start()
    {
        target = GameObject.FindAnyObjectByType<Player>().transform;
    }
    */

    public void Initialize(Transform aTarget)
    {
        target = aTarget;
    }

    public void UpdateEnemy()
    {
        // Move towards the target direction = to - from.normalized
        velocity = (target.position - transform.position).normalized;
        transform.position += velocity * MovementSpeed * Time.deltaTime;
    }

    public void TakeDamage(float someDamage)
    {
        Health -= someDamage;
    }

    public bool IsAlive()
    {
        return Health > 0; // Returns true if health is above zero
    }
}
