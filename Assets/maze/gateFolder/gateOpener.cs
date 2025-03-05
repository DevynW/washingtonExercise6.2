using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateOpener : MonoBehaviour
{
    Animator doorAnimator;
    bool backGate = false;
    bool frontGate = false;
    bool coinInScene = false;
    GameObject coin;
    int i = 0;
    [SerializeField] GameObject coinObj;
    // Start is called before the first frame update
    void Start()
    {
        frontGate = gameObject.CompareTag("frontGate");//is this front gate
        backGate = gameObject.CompareTag("backGate");//is this back gate
        doorAnimator = GetComponent<Animator>();//get ref for animator
        if (frontGate)
        {
            doorAnimator.Play("openDoor");//if front gate, open
        }
    }

    // Update is called once per frame
    void Update()
    {
        coin = GameObject.FindGameObjectWithTag("coin");//return ref for coin
        if (coin != null && i == 0 )
        {
            i = 1;
            coin.GetComponent<coinRetieved>().coinRetrieved.AddListener(OnCoinRetrieval);//if coin exist, subscribe
            Debug.Log("subscribed!");
        }
        else if (coin == null && i == 1)
        {
            i = 0;
        }

       /* if(Input.GetKeyDown(KeyCode.X))
        {
            //testing doors
            doorAnimator.Play("openDoor");
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!frontGate && !backGate)
        {
            doorAnimator.Play("openDoor");//if reg gate, open on trigger

        }

        coin = GameObject.FindGameObjectWithTag("coin"); //return ref for coin

        if (coin != null)
        {
            coinInScene = true;//if coin exist, coin in scene
        }

        if (frontGate && !coinInScene)
        {
            Invoke("makeCoin", 0f);//if front gate triggered and coin not exist, make coin
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnimator.Play("closeDoor");//if gate triggered ends, close
    }

    public void OnCoinRetrieval()
    {
        Debug.Log("coin retrieved");
        if (!frontGate)
        {
            doorAnimator.Play("openDoor");
        }
        if (backGate)
        {
            Invoke("closeBackGate", 30f);
        }
    }

    void closeBackGate()
    {
        i = 0;
        doorAnimator.Play("closeDoor");
        Invoke("makeCoin", 0f);
    }

    public void makeCoin()
    {
        Instantiate(coinObj);
    }
}
