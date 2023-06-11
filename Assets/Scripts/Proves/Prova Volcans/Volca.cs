using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volca : MonoBehaviour
{
    private ProvaVolcans provaVolcans;
    public GameObject volca;

    public AudioSource soCreixerVolca;

    // Start is called before the first frame update
    void Start()
    {
        provaVolcans = FindObjectOfType<ProvaVolcans>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2Peu"))
        {
            creixerVolca();
            Comprovar(other);
            soCreixerVolca.Play();
        }
    }
    
    private void Comprovar(Collider other)
    {
        if(volca.Equals(provaVolcans.sequenciaVolcans[provaVolcans.iteradorVolcans]))
        {
            provaVolcans.volcansTocats[provaVolcans.iteradorVolcans] = true;
            provaVolcans.llistaVolcans[provaVolcans.iteradorVolcans].SetActive(false);
            if(provaVolcans.iteradorVolcans <= provaVolcans.numeroVolcans - 1) // gestionar que l'iterador no sigui més gran que el número de volcans
            {
                provaVolcans.iteradorVolcans++; 
            }
        }
    }

    void creixerVolca()
    {
        float scale = 0.13f;
        volca.transform.localScale = new Vector3(scale, scale, scale);
    }
}
