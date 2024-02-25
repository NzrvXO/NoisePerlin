using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float fastMovementSpeed = 10f;
    public float sensitivity = 2f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;

    void Update()
    {
        // Перемещение
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), (Input.GetKey(KeyCode.Space) ? 1 : 0) - (Input.GetKey(KeyCode.LeftShift) ? 1 : 0), Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += (transform.up * movement.y + transform.forward * movement.z + transform.right * movement.x) * fastMovementSpeed * Time.deltaTime;
        else
            transform.position += (transform.up * movement.y + transform.forward * movement.z + transform.right * movement.x) * movementSpeed * Time.deltaTime;

        // Вращение
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    }
}
