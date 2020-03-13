﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontal, vertical;
    float rotation_base;
    Vector3 move_direction;

    void Update()
    {
        MovePlayer();
    }
    
    void LateUpdate() 
    {
        PlayerLook();
    }
    
    void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical) * 10 * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }

    void PlayerLook()
    {
        rotation_base = GameObject.Find("Camera Base").transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, rotation_base, 0);    
    }
    
         
}
