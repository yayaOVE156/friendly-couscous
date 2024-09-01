using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class REDS : MonoBehaviour, Interactable
{

    public Simon simon;

    void Start()
    {
        simon = GameObject.FindGameObjectWithTag("SimonTAG").GetComponent<Simon>();
    }
    public void InteractAction()
    {
        simon.playerchoice = 1;
        Debug.Log("Red is clicked");

    }
}
