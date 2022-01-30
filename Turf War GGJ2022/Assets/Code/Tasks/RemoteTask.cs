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
        gameObject.transform.position = block.transform.position + new Vector3(0f, 0.3f, 0f);
        block.gameObject.GetComponent<GridBlock>().MakeClean(true);
    }

    public void TakeRemote(GameObject player, GameObject block)
    {
        gameObject.transform.parent = player.transform;
        gameObject.transform.position = player.transform.position + new Vector3(0f, 1.4f, 0f);
        block.gameObject.GetComponent<GridBlock>().MakeClean(false);
    }
}
