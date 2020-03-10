﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int velocity = 5;
    public int jump = 1;
    public Rigidbody rb;
    public bool inAir = false;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Surface" || other.gameObject.tag == "PClones") {
            inAir = false;
        } else if(other.gameObject.tag == "Bullet") {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        transform.Translate(move * velocity * Time.deltaTime, Space.World);
        if(move!=Vector3.zero && this.gameObject.tag == "Player"){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15F);
        }

        

        if(Input.GetKeyDown(KeyCode.RightShift) && !inAir){
            rb.AddForce(new Vector3(0,jump,0));
            inAir = true;
        }
    }
}
