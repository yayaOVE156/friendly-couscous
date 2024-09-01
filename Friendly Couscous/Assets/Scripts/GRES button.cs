using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRES : MonoBehaviour, Interactable
{

    public Simon simon;

    void Start()
    {
        simon = GameObject.FindGameObjectWithTag("SimonTAG").GetComponent<Simon>();
    }
    public void InteractAction()
    {
        simon.playerchoice = 0;
        Debug.Log("Green is clicked");

    }
}
