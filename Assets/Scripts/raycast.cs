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
    int weapon=0;
    void Start()
    {
        hand = GameObject.Find("hand");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            weapon=1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            weapon=0;
        }
        if(Input.GetMouseButtonDown(0)){
            
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit,range)){
                var selection = hit.transform;
                var selectionRender = selection.GetComponent<Renderer>();
                if(selectionRender!=null){
                    if(weapon==0 && selection.CompareTag("selectable")){
                        selectionRender.material = yellowMaterial;
                        isholding=!isholding;
                        selectedObRb=hit.rigidbody;
                        selectedObRb.useGravity=!selectedObRb.useGravity;
                        selectedOb=selection;
                    }
                    else if(weapon==1  && selection.CompareTag("Enemy")){
                        hit.collider.gameObject.SendMessage("ApplyDamage",10.0f);
                    }
                }
            }
            
        }
        if(isholding){
            float step =  speed * Time.deltaTime;
            selectedOb.position = Vector3.MoveTowards(selectedOb.position, hand.transform.position, step);
            


        }
    }
}
