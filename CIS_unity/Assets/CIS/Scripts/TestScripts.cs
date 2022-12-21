using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CIS;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CIS.Machine machine = new CIS.Machine();
        string s = machine.print();
        Debug.Log(s);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
