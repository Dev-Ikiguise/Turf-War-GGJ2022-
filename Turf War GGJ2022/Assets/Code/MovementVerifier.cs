using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVerifier : MonoBehaviour
{
    Movement2 player;

    void Start()
    {
        player = GetComponentInParent<Movement2>();
        print(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GridBlock>())
        {
            print("TEST");
            player.canMoveForward = other.GetComponent<GridBlock>().canMoveInto;
        }
    }
}
