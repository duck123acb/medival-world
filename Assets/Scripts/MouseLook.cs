using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseX, mouseY;
    float xRotation = 0;

    [SerializeField]
    float mouseSensitivity;

    Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.parent;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
