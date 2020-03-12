using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatePad : MonoBehaviour
{
    // Start is called before the first frame update
    public int duplicateCount = 0;
    public Material clonesMat;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Player" && duplicateCount < 50) {
            GameObject PClone = Instantiate(other.gameObject, other.transform.position + new Vector3(0,50,0), other.transform.rotation);
            PClone.tag = "PClones";
            PClone.GetComponent<MeshRenderer>().material = clonesMat;
            PClone.AddComponent<PCloneScript>();
            
            Destroy(PClone.GetComponent<PlayerMovement>());
            duplicateCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
