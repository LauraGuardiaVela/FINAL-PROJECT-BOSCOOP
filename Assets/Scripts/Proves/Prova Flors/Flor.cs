using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flor : MonoBehaviour
{
    private ProvaFlors provaFlors;
    public GameObject flor;

    public AudioSource soCreixerFlor;

    //per fer créixer la flor
    private float targetScale; // 1
    public float timeToReachTarget; // 2
    private float startScale;  // 3
    private float percentScaled; // 4


    // Start is called before the first frame update
    void Start()
    {
        provaFlors = FindObjectOfType<ProvaFlors>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            creixerFlor();
            Comprovar(other);
            soCreixerFlor.Play();
        }
    }
    
    private void Comprovar(Collider other)
    {
        if(flor.Equals(provaFlors.sequenciaFlors[provaFlors.iteradorFlors]))
        {
            provaFlors.florsCrescudes[provaFlors.iteradorFlors] = true;
            if(provaFlors.iteradorFlors <= provaFlors.numeroFlors - 2) //gestionar que l'iterador no sigui més gran que el número de bolets
            {
                provaFlors.iteradorFlors++; 
            }
        }
    }
    void creixerFlor()
    {
        //percentScaled += i / timeToReachTarget; // 2
        //float scale = Mathf.Lerp(startScale, targetScale, percentScaled); // 3
        float scale = 60;
        flor.transform.localScale = new Vector3(scale, scale, scale);
          
    }

}
