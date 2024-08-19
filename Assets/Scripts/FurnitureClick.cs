using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if (Physics.Raycast(ray, out RaycastHit hit)) {
                // Use the hit variable to determine what was clicked on.
                if (hit.transform == this.transform) {
                    Debug.Log("I've been hit!!");
                    if (GetComponentInParent<ShelfOrganize>()) {
                        //we're a shelf item, delete and spawn a place item
                    } else if (GetComponentInParent<PlacedFurniture>()) {
                        //we're a placed item, put us into move mode
                    }
                }
           }
        }
    }
}
