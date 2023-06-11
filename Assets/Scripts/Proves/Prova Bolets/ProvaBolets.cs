using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaBolets : MonoBehaviour
{
    public List<GameObject> llistaBolets = new List<GameObject>(); // llista original de bolets
    public List<GameObject> sequenciaBolets = new List<GameObject>(); // seqüència de bolets 
    public List<bool> boletsTocats = new List<bool>(); // llista en la que emmagatzemarem si un bolet s'ha tocat o no
    
    public int numeroBolets;
    public int iteradorBolets;

    public bool boletsIsWin;
    public bool timeToReset;

    private Color colorOriginal;
    private Color colorIlluminat;

    // Start is called before the first frame update
    void Start()
    {
        iteradorBolets = 0;
        numeroBolets = llistaBolets.Count;
        boletsIsWin = false;
        
        colorOriginal = llistaBolets[0].GetComponent<Renderer>().material.color; // tots els bolets tindran el mateix color
        colorIlluminat = Color.white;
        
        generateSequence();
        StartCoroutine(mostrarSequencia());

    }
    void generateSequence()
    {
        System.Random random = new System.Random();
        List<GameObject> availableBolets = new List<GameObject>(llistaBolets);
        
        for (int i = 0; i < numeroBolets; i++)
        {
            boletsTocats.Add(false);
            int randomIndex = random.Next(0, availableBolets.Count);
            sequenciaBolets.Add(availableBolets[randomIndex]);
            availableBolets.RemoveAt(randomIndex);
        }
    }
    IEnumerator mostrarSequencia(){

        for(int i = 0; i < numeroBolets; i++){
            
            var boletActual = sequenciaBolets[i];

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
        //Posar de nou boletsTocats a false
        for(int i = 0; i < numeroBolets; i++)
        {
            boletsTocats[i] = false;
        }
        //Desil·luminar tots els bolets
        for(int i = 0; i < numeroBolets; i++)
        {
            StartCoroutine(DesIlluminar(i));
        }

    }
    
    private IEnumerator DesIlluminar(int i)
    {
        sequenciaBolets[i].GetComponent<Renderer>().material.color = colorOriginal;
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
