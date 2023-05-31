using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaFlors : MonoBehaviour
{
    public List<GameObject> llistaFlors = new List<GameObject>();
    public List<GameObject> sequenciaFlors = new List<GameObject>(); //seqüència de bolets 
    public List<bool> florsCrescudes = new List<bool>(); //llista en la que emmagatzemarem si un bolet s'ha tocat o no

    public int numeroFlors;
    public int iteradorFlors;

    public bool FlorsisWin;


    
    // Start is called before the first frame update
    void Start()
    {
        iteradorFlors = 0;
        numeroFlors = llistaFlors.Count;
        FlorsisWin = false;
        generateSequence();
        

        //per créixer la flor
        //targetScale = 65f;
        //startScale = transform.localScale.x;
    }

    void generateSequence()
    {
        //ara mateix estem assumint que la seqüència és la mateixa que la llista. 
        for(int i = 0; i < numeroFlors; i++)
        {
            if(i == 0){
                llistaFlors[i].SetActive(true); //inicialitzem la primera a true
            }
            else
            {
                llistaFlors[i].SetActive(false);
            }
            florsCrescudes.Add(false);
            sequenciaFlors.Add(llistaFlors[i]); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        generarFlors();
        checkIfWin();
    }

    void generarFlors()
    {
        if(iteradorFlors != 0)
        {
            if(florsCrescudes[iteradorFlors-1] == true)
            {
                llistaFlors[iteradorFlors].SetActive(true);
            }
        }
    }

    void checkIfWin()
    {
        FlorsisWin = true;
        for(int i = 0; i < numeroFlors; i++)
        {
            if(florsCrescudes[i] == false)
            {   
                FlorsisWin = false;
            }
        }
    }
}