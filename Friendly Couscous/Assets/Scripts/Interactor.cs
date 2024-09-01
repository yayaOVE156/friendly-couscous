using System.Collections;
using System.Collections.Generic;
using UnityEngine;


interface Interactable
{
    public void InteractAction();
}

public class Interactor : MonoBehaviour
{


    public Transform InteractorSource;
    public float Range = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(r,out RaycastHit hitInfo, Range))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out Interactable interactObject))
                {
                    interactObject.InteractAction();
                }
            }
        }
    }
}
