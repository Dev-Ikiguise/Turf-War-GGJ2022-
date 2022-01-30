using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilingCabinetTask : MonoBehaviour
{
    public bool isClean = true;
    public GameObject sourceObject;

    public GameObject paper1;
    public GameObject paper2;
    public GameObject paper3;

    public int presses = 0;

    private List<Vector3> spawnList = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (paper1 == null && paper2 == null && paper3 == null)
        {
            isClean = true;
        }

        if (isClean)
        {
            this.gameObject.GetComponent<GridBlock>().MakeClean(true);
        }
        else if (!isClean)
        {
            this.gameObject.GetComponent<GridBlock>().MakeClean(false);
        }
    }

    public void OrganizePapers(GameObject player)
    {
        if (player.name == "Player 1" && isClean == false)
        {
            if (player.GetComponent<MoveObject>().heldObject1.gameObject != null && player.GetComponent<MoveObject>().heldObject1.tag == "Paper") Destroy(player.GetComponent<MoveObject>().heldObject1.gameObject);
            if (player.GetComponent<MoveObject>().heldObject2.gameObject != null && player.GetComponent<MoveObject>().heldObject2.tag == "Paper") Destroy(player.GetComponent<MoveObject>().heldObject2.gameObject);
            if (player.GetComponent<MoveObject>().heldObject3.gameObject != null && player.GetComponent<MoveObject>().heldObject3.tag == "Paper") Destroy(player.GetComponent<MoveObject>().heldObject3.gameObject);
        }
    }

    public void TossPapers(GameObject player)
    {
        if (isClean)
        {
            spawnList.Clear();
            spawnList.Insert(0, new Vector3(-5f, -0.2f, 2f));
            spawnList.Insert(0, new Vector3(-2f, -0.2f, 1f));
            spawnList.Insert(0, new Vector3(-2f, -0.2f, -2f));
            spawnList.Insert(0, new Vector3(4f, -0.2f, 4f));
            spawnList.Insert(0, new Vector3(4f, -0.2f, -4f));
            spawnList.Insert(0, new Vector3(-4f, -0.2f, -4f));
        }
        if (presses < 2 && (paper1 == null || paper2 == null || paper3 ==null))
        {
            presses++;
        }
        else if (presses == 2 && (paper1 == null || paper2 == null || paper3 == null))
        {
            if (paper1 == null)
            {
                int num = Random.Range(0, spawnList.Count);
                paper1 = Instantiate(sourceObject, spawnList[num], transform.rotation);
                paper1.transform.parent = null;
                spawnList.RemoveAt(num);
                presses = 0;
                isClean = false;
            }
            else if (paper2 == null)
            {
                int num = Random.Range(0, spawnList.Count);
                paper2 = Instantiate(sourceObject, spawnList[num], transform.rotation);
                spawnList.RemoveAt(num);
                presses = 0;
            }
            else if (paper3 == null)
            {
                int num = Random.Range(0, spawnList.Count);
                paper3 = Instantiate(sourceObject, spawnList[num], transform.rotation);
                spawnList.RemoveAt(num);
                presses = 0;
            }
        }

    }
}
