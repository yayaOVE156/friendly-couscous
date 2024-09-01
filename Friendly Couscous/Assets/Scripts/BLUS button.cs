using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLUS : MonoBehaviour, Interactable
{

    public Simon simon;

    void Start()
    {
        simon = GameObject.FindGameObjectWithTag("SimonTAG").GetComponent<Simon>();
    }
    public void InteractAction()
    {
        simon.playerchoice = 2;
        Debug.Log("Blue is clicked");

    }
}
