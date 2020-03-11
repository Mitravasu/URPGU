using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarm : MonoBehaviour
{
    public GameObject body_part;
    swarm clone;
    Vector3 follow_direction;
    Rigidbody rb;
    float move_speed = 100;
    Vector3 offset;
    bool isAlive = true;
    SwarmMovement swarm_mvmt_script;
    bool switchy =true;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        swarm_mvmt_script = GameObject.Find("Head").GetComponent<SwarmMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(Random.Range(-2,2),Random.Range(-2,2), Random.Range(-2,2));
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            isAlive = false;
            Destroy(swarm_mvmt_script);
        }
        if(switchy){
            CreateBodyPart();
        }
        Invoke("stuck",5f);
        
    }

    void CreateBodyPart()
    {
        follow_direction = Vector3.Normalize(body_part.transform.position+offset - transform.position) * move_speed;
        rb.AddForce(follow_direction);
    }

    void OnCollisionEnter(Collision collision) 
    {
        GameObject[] swarm;
        swarm = GameObject.FindGameObjectsWithTag("Swarm");

        

        if(collision.gameObject == body_part && swarm.Length < 300)
        {
            Instantiate(this, transform.position+offset, Quaternion.identity);
        }
    }
    
    void stuck(){
        switchy=!switchy;
        if(isAlive && body_part.GetComponent<Collider>().isTrigger==false){
            CreateBodyPart();

        }

    }


}
