using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkTask : MonoBehaviour
{
    public bool isClean = true;
    //public GameObject sourceObject;

    public GameObject sinkWater;
    
    public void DrainSink()
    {
        sinkWater.SetActive(false);
    }

    public void FillSink()
    {
        sinkWater.SetActive(true);
    }
}
