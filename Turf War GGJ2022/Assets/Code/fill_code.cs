using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill_code : MonoBehaviour
{
    public KeyCode interact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interact))
        {
            transform.position = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
