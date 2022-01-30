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
            this.gameObject.GetComponent<GridBlock>().MakeClean(true);
        }
        else if (player.name == "Player 2")
        {
            isClean = false;
            lightObject.gameObject.SetActive(true);
            this.gameObject.GetComponent<GridBlock>().MakeClean(false);
        }
    }
}
