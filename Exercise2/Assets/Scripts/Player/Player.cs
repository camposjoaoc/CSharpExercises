using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform playerModel;
    
    [SerializeField] Transform spinningSword;

    [SerializeField] private float Spin_Radius;
    [SerializeField] private float Spin_RotationSpeed;
    [SerializeField] private float Spin_OrbitSpeed;
    
    float angle;
    void Update()
    {
        
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(x, y, 0);

        // Normalize the movement vector to ensure consistent speed in all directions
        transform.position += movement.normalized * moveSpeed * Time.deltaTime;

        SpinBlade();
    }

    private void SpinBlade()
    {
        angle += Time.deltaTime;
        Vector3 orbitPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * Spin_Radius;
        spinningSword.position = orbitPosition + transform.position;
        spinningSword.Rotate(Vector3.forward * Spin_RotationSpeed * Time.deltaTime);
        
    }
}
