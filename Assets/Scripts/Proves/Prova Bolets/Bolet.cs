using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolet : MonoBehaviour
{
    private ProvaBolets provaBolets;
    public GameObject bolet;

    public AudioSource saltarBolet;
    
    private Color colorOriginal;
    private Color colorIlluminat;

    // Start is called before the first frame update
    void Start()
    {
        provaBolets = FindObjectOfType<ProvaBolets>();

        colorOriginal = this.GetComponent<Renderer>().material.color;
        colorIlluminat = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        //Codi per dir quina és la seqüència dels bolets --> només per debugar
        /*
        for(int i = 0; i < provaBolets.numeroBolets; i++)
        {
            Debug.Log(i+"="+provaBolets.sequenciaBolets[i]);
        }
        */        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2Peu"))
        {
            Comprovar(other);
            saltarBolet.Play();
        }
    }

    public void Comprovar(Collider other)
    {
        if(bolet.Equals(provaBolets.sequenciaBolets[provaBolets.iteradorBolets]))
        {
            provaBolets.boletsTocats[provaBolets.iteradorBolets] = true;
            StartCoroutine(Illuminar());


            if(provaBolets.iteradorBolets <= provaBolets.numeroBolets - 2) //gestionar que l'iterador no sigui més gran que el número de bolets
            {
                provaBolets.iteradorBolets++; 
            }
        }else{
            provaBolets.iteradorBolets = 0;
            provaBolets.timeToReset = true;
        }
    }

    private IEnumerator Illuminar()
    {
        this.GetComponent<Renderer>().material.color = colorIlluminat;

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator DesIlluminar()
    {
        this.GetComponent<Renderer>().material.color = colorOriginal;
        yield return new WaitForSeconds(1f);

    }
}