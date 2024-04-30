using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    public Transform[] all;
    public int index;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (all[index]!=null)
        {
            transform.LookAt(all[index]);
        }else
        {
            index++;
        }
    }
}
