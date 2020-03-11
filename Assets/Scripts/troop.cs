using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troop : MonoBehaviour
{
    float distance;
    GameObject[] troops;
    bool[] distance_check;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        troops = GameObject.FindGameObjectsWithTag("Troop");
        distance_check = new bool[troops.Length];
        for(int i = 0; i < troops.Length; i++)
        {
            if(Mathf.Abs(Vector3.Magnitude(troops[i].transform.position - transform.position) - 5) < 0.25)
            {
                distance_check[i] = true;
            }
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        for(int i = 0; i < troops.Length; i++)
        {
            if(distance_check[i])
            {
                MaintainDistance(troops[i]);
            }
        }
    }

    void MaintainDistance(GameObject troop)
    {
        distance = Vector3.Magnitude(troop.transform.position - transform.position);
        if(Mathf.Abs(distance - 5) > 0.25)
        {
            rb.AddForce(Vector3.Normalize(troop.transform.position - transform.position) * (distance - 5) * 10);
        }
    }
}
