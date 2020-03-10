using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            Instantiate(other.gameObject, other.transform.position + new Vector3(100, 100, 100), other.transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
