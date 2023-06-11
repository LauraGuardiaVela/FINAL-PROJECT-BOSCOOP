using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaVolcans : MonoBehaviour
{
    public List<GameObject> llistaVolcans = new List<GameObject>();
    public List<GameObject> sequenciaVolcans = new List<GameObject>(); // seqüència de volcans
    public List<bool> volcansTocats = new List<bool>(); // llista en la que emmagatzemarem si un volca s'ha tocat o no

    public int numeroVolcans;
    public int iteradorVolcans;

    public bool volcansIsWin;

    // Start is called before the first frame update
    void Start()
    {
        iteradorVolcans = 0;
        numeroVolcans = llistaVolcans.Count;
        volcansIsWin = false;
        generateSequence();
    }

    void generateSequence()
    {
        // la seqüència és la mateixa que la llista
        for(int i = 0; i < numeroVolcans; i++)
        {
            if(i == 0){
                llistaVolcans[i].SetActive(true); // inicialitzem la primera a true
            }
            else
            {
                llistaVolcans[i].SetActive(false);
            }
            volcansTocats.Add(false);
            sequenciaVolcans.Add(llistaVolcans[i]); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        generarVolcans();
        checkIfWin();
    }

    void generarVolcans()
    {
        if(iteradorVolcans != 0 && iteradorVolcans < numeroVolcans)
        {
            if(volcansTocats[iteradorVolcans-1] == true)
            {
                llistaVolcans[iteradorVolcans].SetActive(true);
            }
        }
    }

    void checkIfWin()
    {
        volcansIsWin = true;
        for(int i = 0; i < numeroVolcans; i++)
        {
            if(volcansTocats[i] == false)
            {   
                volcansIsWin = false;
            }
        }
    }
}
