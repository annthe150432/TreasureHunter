using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : ShopItem
{
    protected override void Start()
    {
        base.Start();
        gameObject.GetComponent<Button>().onClick.AddListener(AddPullForce);
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { Destroy(gameObject); });
    }
    void AddPullForce()
    {
        LevelDataManagement.Instance.AddPullForce = true;
    }
}
