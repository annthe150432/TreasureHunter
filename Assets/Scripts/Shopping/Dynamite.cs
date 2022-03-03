using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dynamite : ShopItem
{
    protected override void Start()
    {
        base.Start();
        if (Buyable())
        {
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { SpendMoney(Value); });
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { LevelDataManagement.Instance.UpdateDynamiteCount(true); });
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { Destroy(gameObject); });
        }
    }
}
