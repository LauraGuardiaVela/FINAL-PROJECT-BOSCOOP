using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaBolets : MonoBehaviour
{

    public List<GameObject> llistaBolets = new List<GameObject>(); //llista original de bolets
    public List<GameObject> sequenciaBolets = new List<GameObject>(); //seqüència de bolets 
    public List<bool> boletsTocats = new List<bool>(); //llista en la que emmagatzemarem si un bolet s'ha tocat o no
    
    public int numeroBolets;
    public int iteradorBolets;
    

    public bool boletsIsWin;

    // Start is called before the first frame update
    void Start()
    {
        iteradorBolets = 0;
        numeroBolets = llistaBolets.Count;
        boletsIsWin = false;
        generateSequence();
        StartCoroutine(mostrarSequencia());

    }
    void generateSequence()
    {
        //ara mateix estem assumint que la seqüència és la mateixa que la llista. 
        for(int i = 0; i < numeroBolets; i++)
        {
            boletsTocats.Add(false);
            sequenciaBolets.Add(llistaBolets[i]);
        }
    }
    IEnumerator mostrarSequencia(){

        for(int i = 0; i < numeroBolets; i++){
            
            var boletActual = llistaBolets[i];
            //afegir a la llista de seqüència bolets
            //sequenciaBolets.Add(boletActual);


            var colorOriginal = boletActual.GetComponent<Renderer>().material.color;
            var colorNou = Color.white;
            boletActual.GetComponent<Renderer>().material.color = colorNou;

            yield return new WaitForSeconds(2f);
            boletActual.GetComponent<Renderer>().material.color = colorOriginal;

        }
    }

    // Update is called once per frame
    void Update()
    {
        checkIfWin();
        
    }
    void checkIfWin()
    {
        boletsIsWin = true;
        for(int i = 0; i < numeroBolets; i++)
        {
            if(boletsTocats[i] == false)
            {   
                boletsIsWin = false;
            }
        }
        Debug.Log("Bolets Aconseguit: " + boletsIsWin);
    }
}
