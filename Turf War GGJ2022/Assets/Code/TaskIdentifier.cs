using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskIdentifier : MonoBehaviour
{
    Movement2 player;

    void Start()
    {
        player = GetComponentInParent<Movement2>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<GridBlock>())
        {
            player.activeGridBlock = other.GetComponent<GridBlock>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GridBlock>())
        {
            player.activeGridBlock = null;
        }
    }
}
