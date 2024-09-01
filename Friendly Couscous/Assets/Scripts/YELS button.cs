using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YELS : MonoBehaviour, Interactable
{

    public Simon simon;

    void Start()
    {
        simon = GameObject.FindGameObjectWithTag("SimonTAG").GetComponent<Simon>();
    }
    public void InteractAction()
    {
        simon.playerchoice = 3;
        Debug.Log("Yellow is clicked");

    }
}
