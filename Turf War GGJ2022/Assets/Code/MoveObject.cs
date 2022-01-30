using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject heldObject1 = null;
    public GameObject heldObject2 = null;
    public GameObject heldObject3 = null;
    
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
        if (other.gameObject.tag == "Paper")
        {
            if (heldObject1 == null && heldObject2 == null && heldObject3 == null)
            {
                heldObject1 = other.gameObject;
                heldObject1.gameObject.transform.parent = this.gameObject.transform;
                heldObject1.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0f, 1.4f, 0f);
            }
            else if (heldObject1.tag == "Paper" && heldObject2 == null && heldObject3 == null)
            {
                heldObject2 = other.gameObject;
                heldObject2.gameObject.transform.parent = this.gameObject.transform;
                heldObject2.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0f, 1.6f, 0f);
            }
            else if (heldObject1.tag == "Paper" && heldObject2.tag == "Paper" && heldObject3 == null)
            {
                heldObject3 = other.gameObject;
                heldObject3.gameObject.transform.parent = this.gameObject.transform;
                heldObject3.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0f, 1.8f, 0f);
            }
        }
        else if (other.gameObject.tag == "Remote")
        {
            if (heldObject1 == null)
            {
                heldObject1 = other.gameObject;
                heldObject1.gameObject.transform.parent = this.gameObject.transform;
                heldObject1.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0f, 1.4f, 0f);
            }
        }
    }
}
