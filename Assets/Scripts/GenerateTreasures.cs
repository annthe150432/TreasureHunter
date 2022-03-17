using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GenerateTreasures : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        List<LevelDetail> levelDetails = DataManagement<List<LevelDetail>>.ReadDataFromFile("leveldetails", false);
        int level = LevelDataManagement.Instance.Level;
        if (level == 1)
        {
            LevelDataManagement.Instance.DynamiteCount = 0;
        }
        LevelDetail levell = levelDetails.Find(lv => lv.Level == level);


        List<Treasure> treasures = levell.treasure;
        foreach (Treasure treasure in treasures)
        {
            GameObject gameObject = Resources.Load<GameObject>(treasure.Prefab) as GameObject;
            GameObject.Instantiate(gameObject, new Vector3(treasure.X, treasure.Y, treasure.Z), transform.rotation);
        }

        // button skip check
        if(LevelDataManagement.Instance.Current<LevelDataManagement.Instance.Target)
        {
            GameObject.Find("ButtonSkip").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("ButtonSkip").GetComponent<Button>().interactable = true;
        }
    }
    void Update()
    {

    }
}
