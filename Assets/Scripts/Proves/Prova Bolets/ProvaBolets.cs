using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaBolets : MonoBehaviour
{
    //private gestionadorJoc gestionadorJoc;

    public List<GameObject> llistaBolets = new List<GameObject>(); //llista original de bolets
    public List<GameObject> sequenciaBolets = new List<GameObject>(); //seqüència de bolets 
    public List<bool> boletsTocats = new List<bool>(); //llista en la que emmagatzemarem si un bolet s'ha tocat o no
    
    public int numeroBolets;
    public int iteradorBolets;

    public bool boletsIsWin;
    public bool timeToReset;

    private Color colorOriginal;
    private Color colorIlluminat;

    // Start is called before the first frame update
    void Start()
    {
        //gestionadorJoc = FindObjectOfType<gestionadorJoc>();

        iteradorBolets = 0;
        numeroBolets = llistaBolets.Count;
        boletsIsWin = false;
        
        colorOriginal = llistaBolets[0].GetComponent<Renderer>().material.color; //tots els bolets tindran el mateix color
        colorIlluminat = Color.white;
        
        generateSequence();
        StartCoroutine(mostrarSequencia());

    }
    void generateSequence()
    {
        /* SI VOLEM GENERAR LA SEQÜÈNCIA NO RANDOM 
        //ara mateix estem assumint que la seqüència és la mateixa que la llista. 
        for(int i = 0; i < numeroBolets; i++)
        {
            boletsTocats.Add(false);
            sequenciaBolets.Add(llistaBolets[i]);
        }*/

        // Create a random number generator
        System.Random random = new System.Random();
        
        // Create a list to store the available game objects 
        List<GameObject> availableBolets = new List<GameObject>(llistaBolets);
        
        // Iterate through the list of game objects
        for (int i = 0; i < numeroBolets; i++)
        {
            boletsTocats.Add(false);

            // Generate a random index within the available range
            int randomIndex = random.Next(0, availableBolets.Count);

            // Add the selected game object to the sequence
            sequenciaBolets.Add(availableBolets[randomIndex]);

            // Remove the selected game object from the available options
            availableBolets.RemoveAt(randomIndex);
        }
    }
    IEnumerator mostrarSequencia(){

        for(int i = 0; i < numeroBolets; i++){
            
            //var boletActual = llistaBolets[i];
            var boletActual = sequenciaBolets[i];
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
        if(timeToReset == true)
        {
            resetBolets();
            timeToReset = false;
        }
        checkIfWin();
    }

    void resetBolets()
    {
        //iteradorBolets = 0;
        //Desil·luminar tots els bolets
        //Posar de nou boletsTocats a false
        for(int i = 0; i < numeroBolets; i++)
        {
            boletsTocats[i] = false;
        }
        for(int i = 0; i < numeroBolets; i++)
        {
            StartCoroutine(DesIlluminar(i));
        }

    }
    
    private IEnumerator DesIlluminar(int i)
    {
        //llistaBolets[i].GetComponent<Renderer>().material.color = colorOriginal;
        sequenciaBolets[i].GetComponent<Renderer>().material.color = colorOriginal;
        //this.GetComponent<Renderer>().material.color = colorOriginal;
        yield return new WaitForSeconds(1f);

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
    }
}
