using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public int index;
    public bool isTrue;
    public backpoint point;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GetOut()
    {
        if(isTrue)
        {
            point.set();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="backpoint")
        {
            if(other.gameObject.GetComponent<backpoint>() != null)
            {
                if(other.gameObject.GetComponent<backpoint>().index==index)
                {
                    point=other.gameObject.GetComponent<backpoint>();
                    isTrue = true;
                    point.mesh.material = point.overmat;
                  //  GetOut();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "backpoint")
        {
            if (other.gameObject.GetComponent<backpoint>() != null)
            {
                if (other.gameObject.GetComponent<backpoint>().index == index)
                {
                    isTrue = false;
                    point.mesh.material = point.backmat;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
