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
                    selectedOb=selection;
                }
            }
            
        }
        if(isholding){
            selectedOb.position=hand.transform.position;

        }
    }
}
