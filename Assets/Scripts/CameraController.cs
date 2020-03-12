using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    public Transform player, Target;
    float sensitivity = 3;
    float mouseX;
    float mouseY;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        handleCameraLook();
    }

    void handleCameraLook()
    {
        mouseX += Input.GetAxisRaw("Mouse X");
        mouseY -= Input.GetAxisRaw("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -15, 60);
        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(mouseY, mouseX * sensitivity, 0);
        player.rotation = Quaternion.Euler(0, mouseX * sensitivity, 0);
        
        
    }
}
