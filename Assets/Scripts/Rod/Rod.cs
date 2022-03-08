using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    // type
    [SerializeField]
    private String _tag;
    // weight
    [SerializeField]
    public int slowDown;
    // money
    [SerializeField]
    public int value;

    void Awake()
    {
        this.tag = _tag;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
