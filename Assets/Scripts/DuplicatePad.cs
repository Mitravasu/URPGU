using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatePad : MonoBehaviour
{
    // Start is called before the first frame update
    public int duplicateCount = 0;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" && duplicateCount < 10) {
            Instantiate(other.gameObject, other.transform.position, other.transform.rotation);
            duplicateCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
