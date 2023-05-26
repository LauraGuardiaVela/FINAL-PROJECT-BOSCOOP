using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llum : MonoBehaviour
{
    private ProvaLlums ProvaLlums;
    public GameObject bolet;

    public AudioSource saltarBolet;
    
    private Color colorOriginal;
    private Color colorIlluminat;


    // Start is called before the first frame update
    void Start()
    {
        ProvaLlums = FindObjectOfType<ProvaLlums>();

        colorOriginal = this.GetComponent<Renderer>().material.color;
        colorIlluminat = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        //Codi per dir quina és la seqüència dels bolets --> només per debugar
        for(int i = 0; i < ProvaLlums.numeroBolets; i++)
        {
            Debug.Log(i+"="+ProvaLlums.sequenciaBolets[i]);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Comprovar(other);
            saltarBolet.Play();
        }
    }


    public void Comprovar(Collider other)
    {
        Debug.Log("iteradorBolets: "+ProvaLlums.iteradorBolets);
        if(bolet.Equals(ProvaLlums.sequenciaBolets[ProvaLlums.iteradorBolets]))
        {
            Debug.Log("If de nou");
            ProvaLlums.boletsTocats[ProvaLlums.iteradorBolets] = true;
            StartCoroutine(Illuminar());


            if(ProvaLlums.iteradorBolets <= ProvaLlums.numeroBolets - 2) //gestionar que l'iterador no sigui més gran que el número de bolets
            {
                ProvaLlums.iteradorBolets++; 
            }
        }else{
            ProvaLlums.iteradorBolets = 0;
            Debug.Log("iteradorBolets Else: "+ProvaLlums.iteradorBolets);
            ProvaLlums.timeToReset = true;
            
        }

    }

    private IEnumerator Illuminar()
    {
        this.GetComponent<Renderer>().material.color = colorIlluminat;

        yield return new WaitForSeconds(1f);
        //this.GetComponent<Renderer>().material.color = colorOriginal;
    }
    private IEnumerator DesIlluminar()
    {
        this.GetComponent<Renderer>().material.color = colorOriginal;
        yield return new WaitForSeconds(1f);

    }
}
