using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
/*    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
            MovePlayer(Vector3.up);

        if (Input.GetKey(KeyCode.S) && !isMoving))
            MovePlayer(Vector3.down);

        if (Input.GetKey(KeyCode.A) && !isMoving))
            MovePlayer(Vector3.left);

        if (Input.GetKey(KeyCode.D) && !isMoving))
            MovePlayer(Vector3.right);

    }
    
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
 
*/
    
}
