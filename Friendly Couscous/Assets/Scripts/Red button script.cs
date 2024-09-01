using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour, Interactable
{

    public Simon simon;

    void Start()
    {
        simon = GameObject.FindGameObjectWithTag("SimonTAG").GetComponent<Simon>();
    }
    public void InteractAction()
    {
        
        simon.buttonpressed = true;
        
    }
}
