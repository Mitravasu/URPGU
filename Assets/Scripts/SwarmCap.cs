using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmCap : MonoBehaviour
{   
    int counter = 0;
    swarm swarm_script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) 
    {   
        swarm_script = other.gameObject.GetComponent<swarm>();

        other.gameObject.transform.parent = gameObject.transform;

        if(other.gameObject.tag == "Swarm" && swarm_script.body_part.name == name)
        {
            counter++;
            other.gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
        }
        if(counter > 30)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }    
    }

}
