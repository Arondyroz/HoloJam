using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaeAnimation : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Dead
    }

    private Animator animator;
    public Direction currentDirection = Direction.Down;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Example movement logic (replace with your own movement logic)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0f || verticalInput != 0f)
        {
            if (horizontalInput < 0f)
                currentDirection = Direction.Left;
            else if (horizontalInput > 0f)
                currentDirection = Direction.Right;
            else if (verticalInput < 0f)
                currentDirection = Direction.Down;
            else if (verticalInput > 0f)
                currentDirection = Direction.Up;
        }

        //UpdateAnimationState();
    }

    //private void UpdateAnimationState()
    //{
    //    switch (currentDirection)
    //    {
    //        case Direction.Up:
    //            animator.SetFloat("MoveX", 0f);
    //            animator.SetFloat("MoveY", 1f);
    //            break;
    //        case Direction.Down:
    //            animator.SetFloat("MoveX", 0f);
    //            animator.SetFloat("MoveY", -1f);
    //            break;
    //        case Direction.Left:
    //            animator.SetFloat("MoveX", -1f);
    //            animator.SetFloat("MoveY", 0f);
    //            break;
    //        case Direction.Right:
    //            animator.SetFloat("MoveX", 1f);
    //            animator.SetFloat("MoveY", 0f);
    //            break;
    //    }
    //}
}
