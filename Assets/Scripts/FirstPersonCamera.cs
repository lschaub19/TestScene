using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float cmRotationSpeed = 10f;
    public Camera main;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Player rotation based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * cmRotationSpeed * Time.deltaTime);
        main.transform.Rotate(Vector3.up * mouseX * cmRotationSpeed * Time.deltaTime);


        // Update camera position to follow the player with an offset
        main.transform.position = transform.position + Vector3.up * 1.5f; // Adjust the height offset as needed

        // Adjust the LookAt position to consider the offset
        Vector3 lookAtPosition = transform.position;
        lookAtPosition.y += 1.5f; // Adjust the height offset here as well
        main.transform.LookAt(lookAtPosition);
    }
}
