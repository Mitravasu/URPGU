using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float speed = 10;
    private float yaw = 0;
    private float pitch = -90;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        handleCameraMovement();
        handleCameraLook();
    }

    void handleCameraMovement()
    {
        if (horizontalInput < 0) {
            Vector3 newPosition = new Vector3(horizontalInput, 0, 0) * speed + transform.position;
            transform.position = transform.position - Camera.main.transform.right * speed * Time.fixedDeltaTime;
        }
        if (horizontalInput > 0) {
            Vector3 newPosition = new Vector3(horizontalInput, 0, 0) * speed + transform.position;
            transform.position = transform.position + Camera.main.transform.right * speed * Time.fixedDeltaTime;
        }
        if (verticalInput < 0) {
            Vector3 newPosition = new Vector3(0, 0, verticalInput) * speed + transform.position;
            transform.position = transform.position - Camera.main.transform.forward * speed * Time.fixedDeltaTime;
        }
        if (verticalInput > 0) {
            Vector3 newPosition = new Vector3(0, 0, verticalInput) * speed + transform.position;
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.fixedDeltaTime;        
        }
    }

    void handleCameraLook()
    {
        Cursor.visible = false;
        yaw += speed * Input.GetAxis("Mouse X");
        pitch -= speed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
