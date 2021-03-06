using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public static Movement2 Instance;
    public Transform child;
    public GameObject plateManager;

    [HideInInspector] public bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.13f;
    private float elapsedTime = 0;

    //public SpriteRenderer playerSprite;
    //public Sprite walkLeft;
    //public Sprite walkRight;
    //public Sprite stand;

    private bool isWalkLeft = false;

    [HideInInspector] public bool isOnGrass;
    [HideInInspector] public bool isOnBoard;

    public float maxXPos;
    public float maxZPos;

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode interact;

    public bool canMoveUp;
    public bool canMoveDown;
    public bool canMoveLeft;
    public bool canMoveRight;

    public GridBlock activeGridBlock;
    private void Awake()
    {
        Instance = this;
        isOnGrass = false;
        isOnBoard = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(up) && !isMoving && transform.position.z < maxZPos)
        {
            child.transform.eulerAngles = new Vector3(0, 0, 0);
            if (canMoveUp)
            {
                StartCoroutine(MovePlayer(new Vector3(0, 0, 1)));
            }
        }

        if (Input.GetKeyDown(left) && !isMoving && transform.position.x > -maxXPos)
        {
            child.transform.eulerAngles = new Vector3(0, 270, 0);
            if (canMoveLeft)
            {
                StartCoroutine(MovePlayer(Vector3.left));
            }
        }

        if (Input.GetKeyDown(down) && !isMoving && transform.position.z > -maxZPos)
        {
            child.transform.eulerAngles = new Vector3(0, 180, 0);
            if (canMoveDown)
            {
                StartCoroutine(MovePlayer(new Vector3(0, 0, -1)));
            }
        }

        if (Input.GetKeyDown(right) && !isMoving && transform.position.x < maxXPos)
        {
            child.transform.eulerAngles = new Vector3(0, 90, 0);
            if (canMoveRight)
            {
                StartCoroutine(MovePlayer(Vector3.right));
            }
        }

        if (Input.GetKeyDown(interact))
        {
            if (gameObject.name == "Player 1"  && activeGridBlock != null) //CLEAN PERSON
            {
                activeGridBlock.MakeClean(true);
                switch (activeGridBlock.task.ToString())
                {
                    case "filingCabinet":
                        activeGridBlock.gameObject.GetComponent<FilingCabinetTask>().OrganizePapers(this.gameObject);
                        break;
                    case "lamp":
                        activeGridBlock.gameObject.GetComponent<LightTask>().SwitchLight(this.gameObject);
                        break;
                    case "coffeeTable":
                        if (gameObject.GetComponentInChildren<RemoteTask>() != null) gameObject.GetComponentInChildren<RemoteTask>().PlaceRemote(activeGridBlock.gameObject);
                        break;
                    case "sink":
                        activeGridBlock.gameObject.GetComponent<SinkTask>().DrainSink();
                        break;
                    case "counter":
                        GameObject plate = this.gameObject;
                        foreach (Transform t in gameObject.GetComponentsInChildren<Transform>())
                        {
                            if (t.CompareTag("Plate")) plate = t.gameObject;
                        }
                        if (plate != null) plateManager.GetComponent<TableTask>().PlacePlate(activeGridBlock.gameObject, activeGridBlock.task.ToString(), this.gameObject);
                        break;
                    case "table":
                        GameObject plate1 = this.gameObject;
                        foreach (Transform t in activeGridBlock.GetComponentsInChildren<Transform>())
                        {
                            if (t.CompareTag("Plate")) plate1 = t.gameObject;
                        }
                        if (plate1 != null) plateManager.GetComponent<TableTask>().TakePlate(this.gameObject, activeGridBlock.gameObject);
                        break;
                    default:
                        break;
                }
            }
            else if (gameObject.name == "Player 2")//DIRTY PERSON
            {
                activeGridBlock.MakeClean(false);
                if (gameObject.GetComponentInChildren<RemoteTask>() != null)
                {
                    GameObject remote = gameObject.GetComponentInChildren<RemoteTask>().gameObject;
                    remote.transform.parent = null;
                    remote.transform.position = remote.transform.position - new Vector3(0f, 1f, 0f);
                }
                else
                {
                    switch (activeGridBlock.task.ToString())
                    {
                        case "filingCabinet":
                            activeGridBlock.gameObject.GetComponent<FilingCabinetTask>().TossPapers(this.gameObject);
                            break;
                        case "lamp":
                            activeGridBlock.gameObject.GetComponent<LightTask>().SwitchLight(this.gameObject);
                            break;
                        case "coffeeTable":
                            if (activeGridBlock.gameObject.GetComponentInChildren<RemoteTask>() != null) activeGridBlock.gameObject.GetComponentInChildren<RemoteTask>().TakeRemote(gameObject);
                            break;
                        case "sink":
                            activeGridBlock.gameObject.GetComponent<SinkTask>().FillSink();
                            break;
                        case "counter":
                            GameObject plate1 = this.gameObject;
                            foreach (Transform t in activeGridBlock.GetComponentsInChildren<Transform>())
                            {
                                if (t.CompareTag("Plate")) plate1 = t.gameObject;
                            }
                            if (plate1 != null) plateManager.GetComponent<TableTask>().TakePlate(this.gameObject, activeGridBlock.gameObject);
                            break;
                        case "table":
                            GameObject plate = this.gameObject;
                            foreach (Transform t in gameObject.GetComponentsInChildren<Transform>())
                            {
                                if (t.CompareTag("Plate")) plate = t.gameObject;
                            }
                            if (plate != null) plateManager.GetComponent<TableTask>().PlacePlate(activeGridBlock.gameObject, activeGridBlock.task.ToString(), this.gameObject);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }



    public void ResetMovement()
    {
        StopAllCoroutines();
        isMoving = false;
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        //SoundManager.Instance.move.Play()


        isMoving = true;

        elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        CheckForGrass();

        yield return new WaitForSeconds(.1f);

        if (!isMoving)
        {
            //playerSprite.sprite = stand;
        }
        
    }

    public void CancelMove()
    {
        StopCoroutine(nameof(MovePlayer));
        elapsedTime = 1;
        isMoving = false;
    }

    void CheckForGrass()
    {
        if (isOnGrass && !isOnBoard)
        {
            //GameManager.Instance.HandleDeath();
        }
    }
}

