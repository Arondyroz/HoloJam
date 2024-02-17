using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaeMovement : MonoBehaviour
{
    public enum BaeState
    {
        Idle,
        Move
    }

    public enum MoveState
    {
        Up,
        Down,
        Left,
        Right
    }

    public BaeState state = BaeState.Idle;

    private void Update()
    {
        
    }
}
