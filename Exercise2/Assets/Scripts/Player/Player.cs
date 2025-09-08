using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform playerModel;
    [SerializeField] Transform spinningSword;

    [SerializeField] private float Spin_Radius;
    [SerializeField] private float Spin_RotationSpeed;
    [SerializeField] private float Spin_OrbitSpeed;
    
    float angle; // Current angle for orbiting
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
        /* Professor solution
        // Increment angle based on orbit speed
        angle += Time.deltaTime * Spin_OrbitSpeed;
        // Calculate the new position of the spinning sword using polar coordinates
        Vector3 orbitPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * Spin_Radius;
        spinningSword.position = transform.position + orbitPosition ;
        spinningSword.Rotate(Vector3.forward * -Spin_RotationSpeed * Time.deltaTime);
        */
        
        // Increment angle based on orbit speed
        angle += Time.deltaTime * Spin_OrbitSpeed;

        // Calculate the new position of the spinning sword using polar coordinates
        Vector3 orbitPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * Spin_Radius;
        spinningSword.position = transform.position + orbitPos;

        // Tangent of the circle: derivative of (cos, sin) = (-sin, cos)
        Vector3 tangent = new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle), 0);

        // If the sword sprite points to +X, use .right
        spinningSword.right = -tangent; //Align the sword to the tangent
        
    }
}
