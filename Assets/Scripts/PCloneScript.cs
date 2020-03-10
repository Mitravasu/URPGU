using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCloneScript : MonoBehaviour
{
    public int velocity = 10;
    Vector3 follow_direction;
    public Rigidbody rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void followPlayer()
    {
        follow_direction = Vector3.Normalize(player.transform.position - transform.position) * velocity;
        rb.AddForce(follow_direction);
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }
}
