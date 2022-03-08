using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IngameDynamite : MonoBehaviour
{
    // moving speed of dynamite
    private float speed = 20f;
    // object getting pulled
    public Transform Rod { get; set; }
    // the hook
    public GameObject Pod;

    // Start is called before the first frame update
    void Start()
    {
        Pod = GameObject.FindGameObjectWithTag("HookSwing");
        // ignore collision of dynamite with hook
        Physics2D.IgnoreCollision(Pod.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        // dynamite move towards hooked object
        if (Rod != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Rod.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("HookSwing"))
        {
            // destroy hooked object
            Destroy(collision.gameObject);
        }

        // destroy the dynamite
        Destroy(gameObject);
        // for restore speed of hook
        Pod.GetComponent<Hook>().DynamiteThrow = true;

    }

}
