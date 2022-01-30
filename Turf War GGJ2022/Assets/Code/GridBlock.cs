using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GridBlock : MonoBehaviour
{
    public enum Task
    {
        table,
        desk,
        bed,
        sink,
        filingCabinet,
        lamp,
        lamp2,
        lamp3,
        coffeeTable
    }

    public Task task;
    public bool isClean;

    public GameObject cleanVersion;
    public GameObject dirtyVersion;

    public TextMeshProUGUI text;

    public AudioSource audio;

    public void MakeClean(bool isClean)
    {
        this.isClean = isClean;
        audio.Play();

        if (isClean)
        {
            text.color = Color.blue;
            cleanVersion.SetActive(true);
            dirtyVersion.SetActive(false);
        }
        else
        {
            text.color = Color.red;
            cleanVersion.SetActive(false);
            dirtyVersion.SetActive(true);
        }
    }
}
