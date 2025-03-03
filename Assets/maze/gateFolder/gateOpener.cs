using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateOpener : MonoBehaviour
{
    Animator doorAnimator;
    bool backGate = false;
    bool frontGate = false;
    // Start is called before the first frame update
    void Start()
    {
        frontGate = gameObject.CompareTag("frontGate");
        backGate = gameObject.CompareTag("backGate");
        doorAnimator = GetComponent<Animator>();
        if (frontGate)
        {
            doorAnimator.Play("openDoor");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!frontGate && !backGate)
        {
            doorAnimator.Play("openDoor");

        }

        /*if (frontGate)
        {
            Invoke("makeCoin", 0f);
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.Play("closeDoor");
    }

    public void coinRetrieved()
    {
        doorAnimator.Play("openDoor");
        if (backGate)
        {
            Invoke("closeBackGate", 15f);
        }
    }

    void closeBackGate()
    {
        doorAnimator.Play("closeDoor");
        Invoke("makeCoin", 0f);
    }
}
