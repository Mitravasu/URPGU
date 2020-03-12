using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    Transform t;
    float speed=6f;
    public Vector3 move;
    public GameObject hand;

    float cameraSpeed = 10;
    private float yaw = 0;
    private float pitch = -90;
    public bool inAir=false;
    void Start()
    {
        rb=GameObject.Find("Player").GetComponent<Rigidbody>();
        t =GameObject.Find("Player").transform;

            
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        move = hand.transform.right*x + hand.transform.forward * z;
        if(!inAir){
            rb.velocity=move*speed;
        }
        
        if(rb.velocity.y!=0 && !inAir){
            rb.velocity=new Vector3(rb.velocity.x,0,rb.velocity.z);
        }
        if(Input.GetKeyDown(KeyCode.RightShift) && !inAir){
            rb.AddForce(new Vector3(0,300,0));
            inAir=!inAir;
        }
        transform.rotation=hand.transform.rotation;
        rb.constraints =RigidbodyConstraints.FreezeRotation;
        transform.eulerAngles= new Vector3(0,transform.eulerAngles.y,0);
        handleCameraLook();
                
    }

    void handleCameraLook()
    {
        Cursor.visible = false;
        yaw += cameraSpeed * Input.GetAxis("Mouse X");
        pitch -= cameraSpeed * Input.GetAxis("Mouse Y");
        Camera.main.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    private void OnCollisionEnter(Collision other) {
        if(inAir){
            inAir=!inAir;
        }
    }
}
