using UnityEngine;

public class HuskyController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Movement speed
    public float turnSpeed = 100.0f; // Turning speed

    void Update()
    {
        // Get input from the keyboard
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // W,S / Up,Down Arrow keys
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // A,D / Left,Right Arrow keys

        // Move the Husky forward or backward
        transform.Translate(Vector3.right * -move);

        // Turn the Husky
        transform.Rotate(Vector3.up, turn);
    }
}

