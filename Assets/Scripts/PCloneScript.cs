using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCloneScript : MonoBehaviour
{
    public int velocity = 50;
    Vector3 follow_direction;
    public Rigidbody rb;
    public GameObject player;
    public bool isDormant = true;

    bool isShield = false;
    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void onCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            // gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
        } else if(collision.gameObject.tag == "Shield") {
            var joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.rigidbody;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 5, player.transform.position.z);
            isShield = true;
        }
    }

    void followPlayer()
    {
        follow_direction = Vector3.Normalize(player.transform.position - transform.position) * velocity;
        
        rb.AddForce(follow_direction);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShield && !isDormant) {
            followPlayer();
        }

    }
}
