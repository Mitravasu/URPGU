using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    public int velocity = 5;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        

        if(move!=Vector3.zero){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move) * Quaternion.Euler(0, 90, 0), 0.15F);
            transform.Translate(move * velocity * Time.deltaTime, Space.World);
        }
    }
}
