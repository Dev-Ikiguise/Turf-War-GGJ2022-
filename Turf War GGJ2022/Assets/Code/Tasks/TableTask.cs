using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTask : MonoBehaviour
{
    public bool isClean = true;
    public int sinkPlates = 4;


    private void Update()
    {
        if (sinkPlates <= 1)
        {
            isClean = false;
        }
        else if (sinkPlates >= 3)
        {
            isClean = true;
        }
    }

    public void PlacePlate(GameObject block, string blockType, GameObject player)
    {
        GameObject plateSpace = this.gameObject;
        foreach (Transform t in player.gameObject.GetComponentsInChildren<Transform>())
        {
            if (t.CompareTag("Plate")) plateSpace = t.gameObject;
        }
        if (blockType == "counter" && plateSpace.tag == "Plate")
        {
            GameObject plate = this.gameObject;
            foreach (Transform t in player.gameObject.GetComponentsInChildren<Transform>())
            {
                if (t.CompareTag("Plate")) plate = t.gameObject;
            }
            plate.gameObject.transform.parent = block.transform;
            float stack = 0.41f + (0.03f * sinkPlates);
            plate.gameObject.transform.position = block.transform.position + new Vector3(0f, stack, 0f);
            sinkPlates++;
        }
        else if (blockType == "table" && plateSpace.tag == "Plate")
        {
            GameObject plate = this.gameObject;
            foreach (Transform t in player.gameObject.GetComponentsInChildren<Transform>())
            {
                if (t.CompareTag("Plate")) plate = t.gameObject;
            }
            plate.gameObject.transform.parent = block.transform;
            plate.gameObject.transform.position = block.transform.position + new Vector3(0f, 0.44f, 0f);
            sinkPlates--;
        }
    }

    public void TakePlate(GameObject player, GameObject block)
    {
        GameObject plateSpace = this.gameObject;
        foreach (Transform t in player.gameObject.GetComponentsInChildren<Transform>())
        {
            if (t.CompareTag("Plate")) plateSpace = t.gameObject;
        }
        if (player.name == "Player 1" && plateSpace.tag != "Plate")
        {
            GameObject plate = this.gameObject;
            foreach (Transform t in block.gameObject.GetComponentsInChildren<Transform>())
            {
                if (t.CompareTag("Plate")) plate = t.gameObject;
            }
            plate.gameObject.transform.parent = player.transform;
            plate.gameObject.transform.position = player.transform.position + new Vector3(0f, .6f, 0f);
        }
        else if (player.name == "Player 2" && plateSpace.tag != "Plate")
        {
            GameObject plate = this.gameObject;
            foreach (Transform t in block.gameObject.GetComponentsInChildren<Transform>())
            {
                if (t.CompareTag("Plate")) plate = t.gameObject;
            }
            plate.transform.parent = player.transform;
            plate.gameObject.transform.position = player.transform.position + new Vector3(0f, .6f, 0f);
        }
    }
}
