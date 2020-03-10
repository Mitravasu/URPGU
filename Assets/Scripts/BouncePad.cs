using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public int jumpForce = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            other.rigidbody.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    void Update()
    {
        
    }
}
