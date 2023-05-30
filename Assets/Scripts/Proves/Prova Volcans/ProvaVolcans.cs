using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaVolcans : MonoBehaviour
{
    public List<GameObject> llistaVolcans = new List<GameObject>();
    public List<GameObject> sequenciaVolcans = new List<GameObject>(); //seqüència de bolets 
    public List<bool> volcansTocats = new List<bool>(); //llista en la que emmagatzemarem si un bolet s'ha tocat o no

    public int numeroVolcans;
    public int iteradorVolcans;

    public bool volcansIsWin;

    
    // Start is called before the first frame update
    void Start()
    {
        iteradorVolcans = 0;
        numeroVolcans = llistaVolcans.Count;
        volcansIsWin = false;
        Debug.Log(numeroVolcans);
        generateSequence();
        

        //per créixer la flor
        //targetScale = 65f;
        //startScale = transform.localScale.x;
    }

    void generateSequence()
    {
        //ara mateix estem assumint que la seqüència és la mateixa que la llista. 
        for(int i = 0; i < numeroVolcans; i++)
        {
            if(i == 0){
                llistaVolcans[i].SetActive(true); //inicialitzem la primera a true
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
        generarFlors();
        checkIfWin();
        /*if (percentScaled < 1f) // 1
        {
            percentScaled += Time.deltaTime / timeToReachTarget; // 2
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); // 3
            //Flor.transform.localScale = new Vector3(scale, scale, scale); // 4
            llistaVolcans[0].transform.localScale = new Vector3(scale, scale, scale);
            llistaVolcans[1].transform.localScale = new Vector3(scale, scale, scale);
            llistaVolcans[2].transform.localScale = new Vector3(scale, scale, scale);
            llistaVolcans[3].transform.localScale = new Vector3(scale, scale, scale);
            llistaVolcans[4].transform.localScale = new Vector3(scale, scale, scale);
            llistaVolcans[5].transform.localScale = new Vector3(scale, scale, scale);
        }*/
    }

    void generarFlors()
    {
        Debug.Log("volcansTocats["+iteradorVolcans+"] = "+volcansTocats[iteradorVolcans]);
        if(iteradorVolcans != 0)
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
        Debug.Log("Volcans Aconseguit: " + volcansIsWin);
    }
}
