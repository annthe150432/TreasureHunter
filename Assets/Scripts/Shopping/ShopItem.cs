using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    protected int Value = 0;
    public int BaseValue = 0;
    protected virtual void Start()
    {
        Value = BaseValue + BaseValue * (LevelDataManagement.Instance.Level - 1) / 4;
        GameObject PriceText = gameObject.transform.GetChild(0).gameObject;
        Text text = PriceText.GetComponent<Text>();
        text.text = Value.ToString();
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { SpendMoney(Value); });
    }

    public void SpendMoney(int spend)
    {
        if (spend > LevelDataManagement.Instance.Current)
        {
            return;
        }
        LevelDataManagement.Instance.UpdateLevelData(current: LevelDataManagement.Instance.Current - spend);
        GameObject currentMoneyGO = GameObject.FindGameObjectWithTag("CurrentMoney");
        Text moneyText = currentMoneyGO.GetComponent<Text>();
        moneyText.text = LevelDataManagement.Instance.Current.ToString();
    }
}
