using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteTask : MonoBehaviour
{
    public bool isClean = true;

    private void Update()
    {
        if (gameObject.transform.parent == null || gameObject.transform.parent.GetComponent<GridBlock>() == null)
        {
            isClean = false;
        }
        else
        {
            isClean = true;
        }
    }

    public void PlaceRemote(GameObject block)
    {
        gameObject.transform.parent.GetComponent<MoveObject>().heldObject1 = null;
        gameObject.transform.parent = block.transform;
        gameObject.transform.position = block.transform.position + new Vector3(0f, 0.5f, 0f);
    }

    public void TakeRemote(GameObject player)
    {
        gameObject.transform.parent = player.transform;
        gameObject.transform.position = player.transform.position + new Vector3(0f, .6f, 0f);
    }
}
