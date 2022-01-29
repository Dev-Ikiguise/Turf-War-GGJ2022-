using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVerifier : MonoBehaviour
{
    Movement2 player;

    public enum Direction
    {
        up,
        down,
        left,
        right
    }

    public Direction currentDirection;

    void Start()
    {
        player = GetComponentInParent<Movement2>();
        print(player);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<GridBlock>())
        {
            if (currentDirection == Direction.up)
            {
                player.canMoveUp = false;
            }
            else if (currentDirection == Direction.down)
            {
                player.canMoveDown = false;
            }
            else if (currentDirection == Direction.left)
            {
                player.canMoveLeft = false;
            }
            else if (currentDirection == Direction.right)
            {
                player.canMoveRight = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GridBlock>())
        {
            if (currentDirection == Direction.up)
            {
                player.canMoveUp = true;
            }
            else if (currentDirection == Direction.down)
            {
                player.canMoveDown = true;
            }
            else if (currentDirection == Direction.left)
            {
                player.canMoveLeft = true;
            }
            else if (currentDirection == Direction.right)
            {
                player.canMoveRight = true;
            }
        }
    }
}
