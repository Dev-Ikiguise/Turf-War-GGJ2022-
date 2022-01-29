using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public static Movement2 Instance;

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

    public bool canMoveForward;

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
            transform.eulerAngles = new Vector3(0, 0, 0);
            if (canMoveForward)
            {
                StartCoroutine(MovePlayer(new Vector3(0, 0, 1)));
            }
        }

        if (Input.GetKeyDown(left) && !isMoving && transform.position.x > -maxXPos)
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            if (canMoveForward)
            {
                StartCoroutine(MovePlayer(Vector3.left));
            }
        }

        if (Input.GetKeyDown(down) && !isMoving && transform.position.z > -maxZPos)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            if (canMoveForward)
            {
                StartCoroutine(MovePlayer(new Vector3(0, 0, -1)));
            }
        }

        if (Input.GetKeyDown(right) && !isMoving && transform.position.x < maxXPos)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            if (canMoveForward)
            {
                StartCoroutine(MovePlayer(Vector3.right));
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
