using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    public bool tableIsClean;
    public bool deskIsClean;
    public bool bedIsClean;
    public bool sinkIsClean;
    public bool filingCabinetIsClean;
    public bool lamp1IsClean;
    public bool lamp2IsClean;
    public bool lamp3IsClean;
    public bool coffeeTableIsClean;

    void Awake()
    {
        Instance = this;
    }

    public void DetermineWinner()
    {

    }
}
