using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GridBlock : MonoBehaviour
{
    public enum Task
    {
        none,
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

    public AudioSource audioSource;

    public void MakeClean(bool isClean)
    {
        this.isClean = isClean;
        audioSource.Play();

        if (isClean)
        {
            text.color = Color.blue;
            if (cleanVersion != null)
            {
                cleanVersion.SetActive(true);   
                dirtyVersion.SetActive(false);
            }
        }
        else
        {
            text.color = Color.red;
            if (cleanVersion != null)
            {
                cleanVersion.SetActive(false);
                dirtyVersion.SetActive(true);
            }
        }
    }
}
