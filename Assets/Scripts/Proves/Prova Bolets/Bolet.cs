using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolet : MonoBehaviour
{
    private ProvaBolets provaBolets;
    public GameObject bolet;

    public AudioSource saltarBolet;


    // Start is called before the first frame update
    void Start()
    {
        provaBolets = FindObjectOfType<ProvaBolets>();
    }

    // Update is called once per frame
    void Update()
    {
        //Codi per dir quina és la seqüència dels bolets --> només per debugar
        for(int i = 0; i < provaBolets.numeroBolets; i++)
        {
            Debug.Log(i+"="+provaBolets.sequenciaBolets[i]);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Illuminar());
            Comprovar(other);
            saltarBolet.Play();
        }
    }


    private void Comprovar(Collider other)
    {
        Debug.Log("iteradorBolets: "+provaBolets.iteradorBolets);
        if(bolet.Equals(provaBolets.sequenciaBolets[provaBolets.iteradorBolets]))
        {
            provaBolets.boletsTocats[provaBolets.iteradorBolets] = true;

            if(provaBolets.iteradorBolets <= provaBolets.numeroBolets - 2) //gestionar que l'iterador no sigui més gran que el número de bolets
            {
                provaBolets.iteradorBolets++; 
            }
        }

    }

    private IEnumerator Illuminar()
    {
        var colorOriginal = this.GetComponent<Renderer>().material.color;
        var colorNou = Color.white;

        this.GetComponent<Renderer>().material.color = colorNou;

        yield return new WaitForSeconds(1f);
        //this.GetComponent<Renderer>().material.color = colorOriginal;
    }
}
