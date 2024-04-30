using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backpoint : MonoBehaviour
{
    public int index;
    public MeshRenderer mesh;
    public Material setmat;
    public Material backmat;
    public Material overmat;
  
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        backmat = mesh.material;
    }
    private void OnDisable()
    {
        mesh.material = backmat;
    }
    public void set()
    {
        mesh.material = setmat;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
