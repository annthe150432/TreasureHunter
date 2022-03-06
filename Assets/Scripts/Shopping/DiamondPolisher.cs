using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondPolisher : ShopItem
{
    protected override void Start()
    {
        base.Start();
        if (Buyable())
        {
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { SpendMoney(Value); });
            gameObject.GetComponent<Button>().onClick.AddListener(PolishDiamond);
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { Destroy(gameObject); });
        }
    }
    void PolishDiamond()
    {
        LevelDataManagement.Instance.AddDiamondValue = true;
    }
}
