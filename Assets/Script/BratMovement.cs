using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BratMovement : MonoBehaviour
{
    public float changePos = 2f;
    public bool canMove = false;

    public float ChangePos
    {
        get { return changePos; }
        set
        {
            if (value >= 0)
                changePos = value;
            else
                changePos = 2f;
        }
    }

    public float difference = 1.03f;
    private bool hasUpdatedPosition = false;
    float moveUp;
    float moveDown;

    Vector2 currentPosition;

    public enum BratStates
    {
        Up,
        Current,
        Down
    }

    public BratStates bratState = BratStates.Current;

    private void Start()
    {
        currentPosition = transform.position;
        moveUp = currentPosition.y + difference;
        moveDown = currentPosition.y - difference;
    }

    private void Update()
    {
        if (canMove == true)
            BratMoveChange();
    }

    void BratMoveChange()
    {
        ChangePos -= Time.deltaTime;

        if (ChangePos <= 0.2f && !hasUpdatedPosition)
        {
            int random = Random.Range(1, 4);
            if (random == 1)
                bratState = BratStates.Up;
            else if (random == 2)
                bratState = BratStates.Current;
            else if (random == 3)
                bratState = BratStates.Down;

            switch (bratState)
            {
                case BratStates.Up:
                    transform.position = new Vector2(currentPosition.x, moveUp);
                    break;
                case BratStates.Current:
                    transform.position = currentPosition;
                    break;
                case BratStates.Down:
                    transform.position = new Vector2(currentPosition.x, moveDown);
                    break;
            }

            hasUpdatedPosition = true;
        }
        else if (ChangePos > 0.2f)
        {
            hasUpdatedPosition = false;
        }
    }

    public void MoveCheck(bool check)
    {
        canMove = check;
    }
}
