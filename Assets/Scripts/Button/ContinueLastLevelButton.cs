using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueLastLevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (LevelDataManagement.Instance.CanContinue)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
