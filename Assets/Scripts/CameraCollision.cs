﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    
    float min_distance = 1.0f;
    float max_distance = 10.0f;
    float smooth = 10.0f;
    Vector3 dolly_direction;
    public float distance;

    void Awake()
    {
        dolly_direction = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desired_camera_position = transform.parent.TransformPoint(dolly_direction * max_distance);
        RaycastHit hit;
        
        if(Physics.Linecast(transform.parent.position, desired_camera_position, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.9f), min_distance, max_distance);

        } else {
            distance = max_distance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dolly_direction * distance, Time.deltaTime * smooth);
    }
}
