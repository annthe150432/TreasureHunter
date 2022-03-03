using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySomeShopItem : MonoBehaviour
{
    private void Awake()
    {
        List<GameObject> childs = new List<GameObject>();
        for (int i=0; i<gameObject.transform.childCount; i++)
        {
            childs.Add(gameObject.transform.GetChild(i).gameObject);
        }
        int removeCount = Random.Range(0, childs.Count-1);
        Debug.Log("Total Childs " + childs.Count);
        Debug.Log("Destroy count " + removeCount);
        for (int i=0; i<removeCount; i++)
        {
            int goIndex = Random.Range(0, childs.Count);
            Debug.Log("Destroy At " + goIndex);
            childs.RemoveAt(goIndex);
            Destroy(gameObject.transform.GetChild(goIndex).gameObject);
        }
    }
}
