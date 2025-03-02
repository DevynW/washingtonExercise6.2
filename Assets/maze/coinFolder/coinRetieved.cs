using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRetieved : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void coinArimasu()
    {
        Invoke("coinRetrieved",0f);
    }

}
