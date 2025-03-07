using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class coinRetieved : MonoBehaviour
{
    public UnityEvent coinRetrieved;
    GameObject[] gates;
    // Start is called before the first frame update
    void Start()
    {
        gates = GameObject.FindGameObjectsWithTag("gate");
        GameObject backGate = GameObject.FindGameObjectWithTag("backGate");
        coinRetrieved.AddListener(backGate.GetComponent<gateOpener>().OnCoinRetrieval);

        foreach ( GameObject gate in gates )
        {
            coinRetrieved.AddListener(gate.GetComponent<gateOpener>().OnCoinRetrieval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        coinRetrieved.Invoke();
        Debug.Log("fn invoked");
        /*Invoke("onCoinRetrieval",0f);
        Invoke("victoryScreech", 0f);*/
        Destroy(gameObject);
    }

}
