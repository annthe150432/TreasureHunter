using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hook : MonoBehaviour
{
    /// <summary>
    /// To do:
    /// Handle rest of items used: clock, diamond polisher, energy, square stone, hook mole
    /// </summary>
    
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
    private float _slowDown;

    private Transform rod;
    private bool flagRod;
    private int dollar;

    private int numBomb;
    [SerializeField]
    private GameObject dynamitePrefab;
    private bool dynamiteThrow;
    public bool DynamiteThrow { get { return dynamiteThrow; } set { dynamiteThrow = value; } }

    private RopeRenderer ropeRenderer;

    internal void OnTriggerEnter(Collider collision)
    {
        throw new NotImplementedException();
    }

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
        _slowDown = 0;
        flagRod = false;
        // should load from save
        dollar = 0;
        // should load from save
        numBomb = LevelDataManagement.Instance.DynamiteCount;
        dynamiteThrow = false;
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
                // handle energy boost
                if(LevelDataManagement.Instance.AddPullForce)
                {
                    // move hook up
                    if (flagRod)
                    {
                        print("mm");
                        temp += transform.up * Time.deltaTime * (moveSpeed - _slowDown + 5);
                    }
                    else
                    {
                        temp += transform.up * Time.deltaTime * moveSpeed;
                    }
                }
                else
                {
                    if (flagRod)
                    {
                        temp += transform.up * Time.deltaTime * (moveSpeed - _slowDown);
                    }
                    else
                    {
                        temp += transform.up * Time.deltaTime * moveSpeed;
                    }
                }

                // move hook up
                if (flagRod)
                {
                    temp += transform.up * Time.deltaTime * (moveSpeed - _slowDown);
                }
                else
                {
                    temp += transform.up * Time.deltaTime * moveSpeed;
                }

                // while moving can throw bomb
                // throw bomb
                if (numBomb > 0)
                {

                    // only throw when there is something on hook
                    if (rod != null)
                    {
                        // allow throw dynamite
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Vector3 throwPos = transform.parent.position;
                            GameObject throwDynamite = Instantiate<GameObject>(dynamitePrefab, throwPos, Quaternion.identity);
                            throwDynamite.tag = "Dynamite";
                            throwDynamite.AddComponent<IngameDynamite>();
                            IngameDynamite throwDynamite_script = throwDynamite.GetComponent<IngameDynamite>();
                            throwDynamite_script.Rod = rod;
                            
                        }
                    }
                    if (dynamiteThrow)
                    {
                        //restore hook speed and hook status to unhooked
                        flagRod = false;
                        // minus 1 dynamite
                        LevelDataManagement.Instance.UpdateDynamiteCount(false);
                    }

                }

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
                dynamiteThrow = false;


                if (rod != null)
                {
                    // remove rod from screen
                    Destroy(rod.gameObject);
                    _slowDown = 0;
                    flagRod = false;

                    // add point
                    GameObject point = GameObject.FindGameObjectWithTag("CurrentMoney");
                    if (point != null)
                    {
                        Text value = point.GetComponent<Text>();
                        int pointValue = value != null ? Int32.Parse(value.text) : 0;
                        
                        // handle double value for stone
                        if(rod.tag.Equals("Rock")&&LevelDataManagement.Instance.DoubleStoneValue)
                        {
                            dollar *= 2;
                        }

                        // handle diamond polisher
                        if (rod.tag.Equals("Diamond") && LevelDataManagement.Instance.AddDiamondValue)
                        {
                            dollar += 150;
                        }
                        pointValue += dollar;
                        value.text = pointValue.ToString();
                        dollar = 0;
                    }
                }

            }
            ropeRenderer.RenderLine(temp, true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!flagRod)
        {
            // get hooked object information
            rod = collision.transform;
            dollar = rod.GetComponent<Rod>().value;
            _slowDown = rod.GetComponent<Rod>().slowDown;
            dollar = rod.GetComponent<Rod>().value;

            // change hook status
            moveDown = false;
            rod.SetParent(transform);
            flagRod = true;

        }
    }





}
