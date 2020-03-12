using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    Transform t;
    float speed=20f;
    public Vector3 move;
    public GameObject hand;
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
        rb.AddForce(move*speed);
        transform.rotation=hand.transform.rotation;
        rb.constraints =RigidbodyConstraints.FreezeRotation;
        transform.eulerAngles= new Vector3(0,transform.eulerAngles.y,0);
        
        

        
    }
}
