using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volca : MonoBehaviour
{
    private ProvaVolcans provaVolcans;
    public GameObject volca;

    public AudioSource soCreixerVolca;

    //per fer créixer la flor
    private float targetScale; // 1
    public float timeToReachTarget; // 2
    private float startScale;  // 3
    private float percentScaled; // 4


    // Start is called before the first frame update
    void Start()
    {
        provaVolcans = FindObjectOfType<ProvaVolcans>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
            if(provaVolcans.iteradorVolcans <= provaVolcans.numeroVolcans - 1) //gestionar que l'iterador no sigui més gran que el número de bolets
            {
                provaVolcans.iteradorVolcans++; 
            }
        }
    }
    void creixerVolca()
    {
        //percentScaled += i / timeToReachTarget; // 2
        //float scale = Mathf.Lerp(startScale, targetScale, percentScaled); // 3
        float scale = 0.13f;
        volca.transform.localScale = new Vector3(scale, scale, scale);
    }

}
