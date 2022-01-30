using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkTask : MonoBehaviour
{
    public bool isClean = true;
    //public GameObject sourceObject;

    public GameObject sinkWater;

    private void Start()
    {
        sinkWater.SetActive(false);
    }

    public void DrainSink(GameObject block)
    {
        sinkWater.SetActive(false);
        isClean = false;
        block.gameObject.GetComponent<GridBlock>().MakeClean(true);
    }

    public void FillSink(GameObject block)
    {
        sinkWater.SetActive(true);
        isClean = true;
        block.gameObject.GetComponent<GridBlock>().MakeClean(false);
    }
}
