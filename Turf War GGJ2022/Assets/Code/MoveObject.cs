using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private GameObject heldObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (heldObject == null && (other.gameObject.tag == "Paper" || other.gameObject.tag == "Remote"))
        {
            heldObject = other.gameObject;
            heldObject.gameObject.transform.parent = this.gameObject.transform;
            heldObject.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0f,.6f,0f);
        }
    }
}
