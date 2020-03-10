using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class raycast : MonoBehaviour
{
    public Material yellowMaterial;
    public float range=5;
    GameObject hand;
    bool isholding=false;
    Transform selectedOb;
    Rigidbody selectedObRb;
    float speed =10f;
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("hand");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit,range)){
                var selection = hit.transform;
                var selectionRender = selection.GetComponent<Renderer>();
                if(selectionRender!=null && selection.CompareTag("selectable")){
                    selectionRender.material = yellowMaterial;
                    isholding=!isholding;
                                        selectedObRb=hit.rigidbody;

                    selectedObRb.useGravity=!selectedObRb.useGravity;

                    selectedOb=selection;
                }
            }
            
        }
        if(isholding){
            float step =  speed * Time.deltaTime;
            selectedOb.position = Vector3.MoveTowards(selectedOb.position, hand.transform.position, step);
            


        }
    }
}
