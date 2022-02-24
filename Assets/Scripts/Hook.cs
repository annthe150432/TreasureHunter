using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float rotateSpeed = 30f;
    public float maxZ = 55f;
    public float minZ = -55f;

    private float rotateAngle;
    private bool rotateRight;
    private bool canRotate;

    public float moveSpeed = 20f;
    private float initialMoveSpeed;

    public float minY = -2.5f;
    private float initialY;

    private bool moveDown;

    private RopeRenderer ropeRenderer;

    void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

        initialY = transform.position.y;
        initialMoveSpeed = moveSpeed;
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    // Do rotation of hook when not drop down
    private void Rotate()
    {
        if (!canRotate)
        {
            return;
        }

        if (rotateRight)
        {
            rotateAngle += rotateSpeed * Time.deltaTime;
        }
        else
        {
            rotateAngle -= rotateSpeed * Time.deltaTime;            
        }

        transform.rotation = Quaternion.AngleAxis(rotateAngle, Vector3.forward);


        if (rotateAngle >= maxZ)
        {
            rotateRight = false;
        }
        else if (rotateAngle <= minZ)
        {
            rotateRight = true;
        }
    }

    // Check user input
    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;
            }
        }
    }

    // Move the rope up and down
    private void MoveRope()
    {
        // no input from user => still rotating
        if (canRotate)
        {
            return;
        }

        if (!canRotate)
        {
            // get current hook pos
            Vector3 temp = transform.position;

            if (moveDown)
            {
                // move hook down
                temp -= transform.up * Time.deltaTime * moveSpeed;
            }
            else
            {
                // move hook up
                temp += transform.up * Time.deltaTime * moveSpeed;
            }
            transform.position = temp;

            if (temp.y <= minY)
            {
                // hook reached the limit, start move up
                moveDown = false;
            }

            if (temp.y >= initialY)
            {
                // hook reached the top, start swinging
                canRotate = true;
                ropeRenderer.RenderLine(temp, false);
                moveSpeed = initialMoveSpeed;
            }
            ropeRenderer.RenderLine(temp, true);
        }
    }

}
