using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squad : MonoBehaviour
{
    GameObject[] troops = new GameObject[8];
    GameObject leader;
    public GameObject troop;
    int offset = 5;
    Vector3 pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8;

    // Start is called before the first frame update
    void Start()
    {     
        leader = GameObject.Find("Leader");
        
        pos1 = leader.transform.position + new Vector3(0, 0, offset);
        pos2 = leader.transform.position + new Vector3(0, 0, -offset);
        pos3 = leader.transform.position + new Vector3(offset, 0, 0);
        pos4 = leader.transform.position + new Vector3(-offset, 0, 0);
        pos5 = leader.transform.position + new Vector3(offset, 0, offset);
        pos6 = leader.transform.position + new Vector3(-offset, 0, -offset);
        pos7 = leader.transform.position + new Vector3(offset, 0, -offset);
        pos8 = leader.transform.position + new Vector3(-offset, 0, offset);

        troops[0] = Instantiate(troop, pos1, Quaternion.identity);
        troops[1] = Instantiate(troop, pos2, Quaternion.identity);
        troops[2] = Instantiate(troop, pos3, Quaternion.identity);
        troops[3] = Instantiate(troop, pos4, Quaternion.identity);
        troops[4] = Instantiate(troop, pos5, Quaternion.identity);
        troops[5] = Instantiate(troop, pos6, Quaternion.identity);
        troops[6] = Instantiate(troop, pos7, Quaternion.identity);
        troops[7] = Instantiate(troop, pos8, Quaternion.identity);

        foreach(GameObject t in troops)
        {
            t.transform.parent = GameObject.Find("Squad").transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.01f,0,0);
    }
    
}
