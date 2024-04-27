using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerGame : MonoBehaviour
{
    public GameObject model1;
    public GameObject hammer;
    private int counter = 0;
    public AudioSource WarningAudio;
    public AudioSource hammerHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            hammer.SetActive(!hammer.activeSelf);
        }
        if (hammer.activeSelf && OVRInput.GetDown(OVRInput.Button.Two))
        {
            changeColor();
        }
    }

    void changeColor()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("model1"))
            {
                Renderer modelRenderer = hit.collider.GetComponent<Renderer>();
                if (counter < 10)
                {
                    counter++;
                    Color randomColor = new Color(Random.value, Random.value, Random.value);
                    modelRenderer.material.color = randomColor;
                    hammerHit.Play();
                }
                else
                {
                    WarningAudio.Play();
                }
            }
        }
    }

}
