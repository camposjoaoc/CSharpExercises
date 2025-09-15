using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform playerModel;

    [SerializeField] GameObject projectile_Prefab;

    [SerializeField] Transform spinningSword;

    [SerializeField] float projectile_Speed;

    [SerializeField] private float Spin_Radius;
    [SerializeField] private float Spin_RotationSpeed;
    [SerializeField] private float Spin_OrbitSpeed;

    [SerializeField] float Health;
    [SerializeField] float MaxHealth;
    [SerializeField] Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    float angle; // Current angle for orbiting

    void Update()
    {
        healthText.text = Health.ToString("F0") + "/" + MaxHealth.ToString();
        healthBar.fillAmount = Health / MaxHealth;
        
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(x, y, 0);

        // Normalize the movement vector to ensure consistent speed in all directions
        transform.position += movement.normalized * moveSpeed * Time.deltaTime;

        SpinBlade();
        Shooting();
    }

    private void SpinBlade()
    {
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

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(projectile_Prefab, transform.position, Quaternion.identity);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Ensure the z-coordinate is zero for 2D

            Vector3 direction = (mousePosition - transform.position).normalized;

            projectile.GetComponent<Projectile>().Initialize(direction, 4);
        }
    }
}