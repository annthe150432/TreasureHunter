using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IngameDynamite : MonoBehaviour
{
    private float speed = 20f;

    public Transform Rod { get; set; }
    public GameObject Pod;

    private bool _destroyed;
    public bool Destroyed { get => _destroyed; }

    // Start is called before the first frame update
    void Start()
    {

        Pod = GameObject.FindGameObjectWithTag("HookSwing");
        Physics2D.IgnoreCollision(Pod.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Rod != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Rod.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("HookSwing"))
        {
            Destroy(collision.gameObject);
        }

        // destroy the dynamite
        Destroy(gameObject);
        Pod.GetComponent<Hook>().DynamiteThrow = true;

    }

}
