using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class raycast : MonoBehaviour
{
    [SerializeField] private Material yellowMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            var selection = hit.transform;
            var selectionRender = selection.GetComponent<Renderer>();
            if(selectionRender!=null){
                selectionRender.material = yellowMaterial;
            }
        }
        
    }
}
