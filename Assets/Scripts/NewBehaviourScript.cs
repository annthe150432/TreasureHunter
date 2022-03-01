using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Treasure> treasures = DataManagement<List<Treasure>>.ReadDataFromFile("leveltreasure", false);
        foreach (Treasure treasure in treasures)
        {
            GameObject gameObject = Resources.Load<GameObject>("Prefabs/Diamond1") as GameObject;
            GameObject.Instantiate(gameObject, new Vector3(treasure.X, treasure.Y, treasure.Z), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
