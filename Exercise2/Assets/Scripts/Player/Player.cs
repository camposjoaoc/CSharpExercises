using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform playerModel;

    // Update is called once per frame
    void Update()
    {
        //One option to move the player
        /*
        if (Input.GetKey(KeyCode.W))
        { 
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
        }
        */

        
        //Another option to move the player
        float y = Input.GetAxisRaw("Vertical");
        float x= Input.GetAxisRaw("Horizontal");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(x, y, 0);

        // Normalize the movement vector to ensure consistent speed in all directions
        transform.position += movement.normalized * moveSpeed * Time.deltaTime;
        

        /*
        //Another option to move the player
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        // Create a movement vector based on input
        Vector3 movement = new Vector3(x, y, 0);

        float cosine = Mathf.Cos(Time.time * 45.0f) * 0.1f;

        if (movement.magnitude > 0)
        {
            playerModel.transform.localPosition = new Vector3(0, cosine, 0);
        }
        // Normalize the movement vector to ensure consistent speed in all directions
        transform.position += movement.normalized * moveSpeed * Time.deltaTime;
        */
    }
}
