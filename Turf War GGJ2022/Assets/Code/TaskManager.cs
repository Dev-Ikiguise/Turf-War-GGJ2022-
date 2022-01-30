using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TextMeshPro tableText;
    [SerializeField] TextMeshPro cofeeTableText;
    [SerializeField] TextMeshPro deskText;
    [SerializeField] TextMeshPro bedText;
    [SerializeField] TextMeshPro sinkText;
    [SerializeField] TextMeshPro filingCabinetText;
    [SerializeField] TextMeshPro lamp1Text;
    [SerializeField] TextMeshPro lamp2Text;
    [SerializeField] TextMeshPro lamp3Text;

    [SerializeField] GridBlock tableBlock;
    [SerializeField] GridBlock coffeeTableBlock;
    [SerializeField] GridBlock deskBlock;
    [SerializeField] GridBlock bedBlock;
    [SerializeField] GridBlock sinkBlock;
    [SerializeField] GridBlock filingCabinetBlock;
    [SerializeField] GridBlock lamp1Block;
    [SerializeField] GridBlock lamp2Block;
    [SerializeField] GridBlock lamp3Block;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetermineOwnership();
    }

    void DetermineOwnership()
    {
        if (tableBlock.isClean)
        {
            tableText.color = Color.blue;
        }
    }
}
