using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueLastLevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelDataManagement data = LevelDataManagement.Instance;
        if (!data.CanContinue)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
