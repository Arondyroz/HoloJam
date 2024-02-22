using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaeMovement : MonoBehaviour
{
    //public float moveSpeed = 5f;

    //private float cooldownMove = 1f;

    //public bool isMove;

    //public float CooldownMove  
    //{
    //    get { return cooldownMove; }
    //    set
    //    {
    //        if (value < 0)
    //            cooldownMove = value;
    //    }
    //}

    //public enum BaeState
    //{
    //    Idle,
    //    Move
    //}

    //public enum MoveState
    //{
    //    Idle,
    //    Up,
    //    Down,
    //    Left,
    //    Right
    //}

    //public BaeState baeState = BaeState.Idle;
    //public MoveState baeMove = MoveState.Idle;

    //private void Update()
    //{
    //    switch(baeState)
    //    {
    //        case BaeState.Idle:
    //            MovementManager();
    //            break;
    //        case BaeState.Move:
    //            UpdateBaeMove();
    //            //StartCoroutine(ChangeToIdle(cooldownMove));
    //            break;
    //    }
    //}

    //void UpdateBaeMove()
    //{
    //    switch (baeMove)
    //    {
    //        case MoveState.Up:
    //            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    //            break;
    //        case MoveState.Down:
    //            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    //            break;
    //        case MoveState.Left:
    //            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    //            break;
    //        case MoveState.Right:
    //            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    //            break;
    //    }

    //}

    //IEnumerator ChangeToIdle(float waitTime)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(waitTime);
    //        isMove = false;
    //        baeState = BaeState.Idle;
    //    }
    //}

    //void MovementManager()
    //{
    //    float moveHorizontal = Input.GetAxisRaw("Horizontal");
    //    float moveVertical = Input.GetAxisRaw("Vertical");

    //    if (moveHorizontal > 0)
    //    {
    //        baeMove = MoveState.Right;
    //    }
    //    else if (moveHorizontal < 0)
    //    {
    //        baeMove = MoveState.Left;
    //    }
    //    else if (moveVertical > 0)
    //    {
    //        baeMove = MoveState.Up;
    //    }
    //    else if (moveVertical < 0)
    //    {
    //        baeMove = MoveState.Down;
    //    }

    //    baeState = BaeState.Move;
    //}
    public float moveSpeed = 5f; // Speed of movement
    public float gridSize = 1f; // Size of each grid cell
    private bool isMoving = false; // Flag to check if character is currently moving
    private Vector2 destination; // Destination grid position

    private void Update()
    {
        if (!isMoving)
        {
            // Check for input to move the character
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Calculate destination based on input
            if (horizontalInput != 0 || verticalInput != 0)
            {
                // Calculate destination grid position
                Vector2Int currentGridPos = Vector2Int.RoundToInt(transform.position / gridSize);
                Vector2Int inputDirection = new Vector2Int((int)horizontalInput, (int)verticalInput);
                destination = currentGridPos + inputDirection;

                // Move the character towards the destination
                StartCoroutine(MoveToDestination(destination));
            }
        }
    }

    private IEnumerator MoveToDestination(Vector2 destination)
    {
        isMoving = true;
        Vector3 targetPosition = new Vector3(destination.x * gridSize, destination.y * gridSize, transform.position.z);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
