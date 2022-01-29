using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject table;
    public GameObject desk;
    public GameObject bed;
    public GameObject sink;
    public GameObject filingcab;
    public GameObject cable;
    public GameObject lamp;
    public GameObject lamp2;
    public GameObject lamp3;
    public GameObject CoffTable;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact1();
        }

    }

    // Start is called before the first frame update
    public void Interact1()
    {
        
    }

    // Update is called once per frame
    public void Interact2()
    {
        
    }
}
