using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaeMovement : MonoBehaviour
{
  

    public float moveSpeed = 5f;
    public Transform movePoint;
    public float gridDistance = 1.3f;

    public LayerMask layerMask;

    private float cooldownMove = 0.5f;

    public bool isMove;

    public float CooldownMove
    {
        get { return cooldownMove; }
        set
        {
            if (value < 0)
                cooldownMove = value;
        }
    }

    private void Start()
    {
        movePoint.parent = null;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(isMove == false)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.5f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, layerMask))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * gridDistance;
                        isMove = true;
                        StartCoroutine(BaeMoving(cooldownMove));
                    }
                    
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, layerMask))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * gridDistance;
                        isMove = true;
                        StartCoroutine(BaeMoving(cooldownMove));
                    }
                
                }
            }
        }
      
    }

    IEnumerator BaeMoving(float wait)
    {
        yield return new WaitForSeconds(wait);
        isMove = false;
    }
}
