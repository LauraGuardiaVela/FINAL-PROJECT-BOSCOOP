using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flor : MonoBehaviour
{
    private ProvaFlors provaFlors;
    public GameObject flor;

    public AudioSource soCreixerFlor;

    // Start is called before the first frame update
    void Start()
    {
        provaFlors = FindObjectOfType<ProvaFlors>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1Ma"))
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
            if(provaFlors.iteradorFlors <= provaFlors.numeroFlors - 2) // gestionar que l'iterador no sigui més gran que el número de flors
            {
                provaFlors.iteradorFlors++; 
            }
        }
    }
    void creixerFlor()
    {
        float scale = 60;
        flor.transform.localScale = new Vector3(scale, scale, scale);  
    }
}
