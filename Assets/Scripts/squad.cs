using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squad : MonoBehaviour
{
    GameObject initial_troop;
    GameObject[] troops = new GameObject[3];
    int offset = 5;

    // Start is called before the first frame update
    void Start()
    {     
        initial_troop = GameObject.Find("Troop");
        for(int i = 0; i < 3; i++)
        {
            troops[i] = Instantiate(initial_troop, initial_troop.transform.position + new Vector3(0, 0, offset), Quaternion.identity);
            troops[i].transform.parent = GameObject.Find("Squad").transform;
            offset += 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
