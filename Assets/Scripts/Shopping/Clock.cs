using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : ShopItem
{
    protected override void Start()
    {
        base.Start();
        if (Buyable())
        {
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { SpendMoney(Value); });
            gameObject.GetComponent<Button>().onClick.AddListener(AddTime);
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { Destroy(gameObject); });
        }
    }
    void AddTime()
    {
        LevelDataManagement.Instance.AddedTime = 10;
    }
}
