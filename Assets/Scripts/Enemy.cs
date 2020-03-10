using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Vector3 follow_direction;
    Rigidbody rb;
    Collision collision;
    float move_speed = 100;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
        offset = new Vector3(Random.Range(0,4),Random.Range(0,1), Random.Range(0,4));
    }

    void followPlayer()
    {
        follow_direction = Vector3.Normalize(player.transform.position - transform.position) * move_speed;
        rb.AddForce(follow_direction);
    }

    void OnCollisionEnter(Collision collision) 
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        

        if(collision.gameObject.tag == "Player" && enemies.Length < 100)
        {
            Instantiate(this, transform.position + offset, Quaternion.identity);
            this.rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }

}
