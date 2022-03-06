using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareStone : ShopItem
{
    protected override void Start()
    {
        base.Start();
        if (Buyable())
        {
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { SpendMoney(Value); });
            gameObject.GetComponent<Button>().onClick.AddListener(DoubleStoneValue);
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { Destroy(gameObject); });
        }
    }
    void DoubleStoneValue()
    {
        LevelDataManagement.Instance.DoubleStoneValue = true;
    }
}
