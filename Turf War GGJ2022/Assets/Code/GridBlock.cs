using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
