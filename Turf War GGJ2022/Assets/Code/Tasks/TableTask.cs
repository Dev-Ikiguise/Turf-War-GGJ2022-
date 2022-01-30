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

    public void PlacePlate(GameObject block, string blockType)
    {
        if (blockType == "counter")
        {
            gameObject.transform.parent.GetComponent<MoveObject>().heldObject1 = null;
            gameObject.transform.parent = block.transform;
            float stack = 0.41f + (0.03f * sinkPlates);
            gameObject.transform.position = block.transform.position + new Vector3(0f, stack, 0f);
        }
        else if (blockType == "table")
        {
            gameObject.transform.parent.GetComponent<MoveObject>().heldObject1 = null;
            gameObject.transform.parent = block.transform;
            gameObject.transform.position = block.transform.position + new Vector3(0f, 0.44f, 0f);
        }
    }

    public void TakePlate(GameObject player)
    {
        if (player.name == "Player 1")
        {
            GameObject plate = transform.GetChild(0).gameObject;
            gameObject.transform.parent = player.transform;
            gameObject.transform.position = player.transform.position + new Vector3(0f, .6f, 0f);
        }
        else if (player.name == "Player 2")
        {
            GameObject plate = transform.GetChild(transform.childCount - 1).gameObject;
            plate.transform.parent = player.transform;
            gameObject.transform.position = player.transform.position + new Vector3(0f, .6f, 0f);
        }
    }
}
