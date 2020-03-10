using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            GameObject.Find("Player").GetComponent<PlayerMovement>().velocity *=2;
            GameObject.Find("Player").GetComponent<PlayerMovement>().jump *=2;
            Destroy(GameObject.Find("Speed"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
