using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCloneScript : MonoBehaviour
{
    public int velocity = 10;
    Vector3 follow_direction;
    public Rigidbody rb;
    public GameObject attachTo;
    // Start is called before the first frame update
    void Start()
    {
        attachTo = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void onCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }
    }

    void followPlayer()
    {
        follow_direction = Vector3.Normalize(attachTo.transform.position - transform.position) * velocity;
        rb.AddForce(follow_direction);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameObject.GetComponent<Rigidbody>().isKinematic) {
            followPlayer();
        }

    }
}
