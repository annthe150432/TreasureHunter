using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCollision : MonoBehaviour
{

    protected Transform stuckTo = null;
    protected Vector3 offset = Vector3.zero;
    protected GameObject rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void LateUpdate()
    {
        if (stuckTo != null)
            transform.position = stuckTo.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="HookSwing")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HookSwing")
        {
            stuckTo = collision.transform;
        }
    }
}
