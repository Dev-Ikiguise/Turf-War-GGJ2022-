using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTask : MonoBehaviour
{
    public bool isClean = true;
    public Light lightObject;
    public void SwitchLight(GameObject player)
    {
        if (player.name == "Player 1")
        {
            isClean = true;
            lightObject.gameObject.SetActive(false);
        }
        else if (player.name == "Player 2")
        {
            isClean = false;
            lightObject.gameObject.SetActive(true);
        }
    }
}
