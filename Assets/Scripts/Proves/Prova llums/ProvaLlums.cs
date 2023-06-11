using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaLlums : MonoBehaviour
{
    public List<GameObject> llistaLlums = new List<GameObject>(); // llista original de llums
    public List<GameObject> sequenciaLlums = new List<GameObject>(); // seqüència de llums
    public List<bool> llumsTocades = new List<bool>(); // llista en la que emmagatzemarem si una llum s'ha tocat o no
    
    public int numeroLlums;
    public int iteradorLlums;

    public bool LlumsisWin;
    public bool timeToReset;

    private Color colorOriginal;
    private Color colorIlluminat;

    // Start is called before the first frame update
    void Start()
    {
        iteradorLlums = 0;
        numeroLlums = llistaLlums.Count;
        LlumsisWin = false;
        
        colorOriginal = llistaLlums[0].GetComponent<Renderer>().material.color; // totes les llums tindran el mateix color
        colorIlluminat = Color.cyan;
        
        generateSequence();
        StartCoroutine(mostrarSequencia());

    }
    void generateSequence()
    {
        // la seqüència és la mateixa que la llista
        for(int i = 0; i < numeroLlums; i++)
        {
            llumsTocades.Add(false);
            sequenciaLlums.Add(llistaLlums[i]);
        }
    }

    IEnumerator mostrarSequencia(){

        for(int i = 0; i < numeroLlums; i++){
            var boletActual = sequenciaLlums[i];
            
            var colorOriginal = boletActual.GetComponent<Renderer>().material.color;
            var colorNou = Color.cyan;
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
            resetLlums();
            timeToReset = false;
        }
        checkIfWin();
    }

    void resetLlums()
    {
        //Posar de nou llumsTocades a false
        for(int i = 0; i < numeroLlums; i++)
        {
            llumsTocades[i] = false;
        }
        //Desil·luminar totes les llums
        for(int i = 0; i < numeroLlums; i++)
        {
            StartCoroutine(DesIlluminar(i));
        }

    }
    
    private IEnumerator DesIlluminar(int i)
    {
        sequenciaLlums[i].GetComponent<Renderer>().material.color = colorOriginal;
        yield return new WaitForSeconds(1f);

    }

    void checkIfWin()
    {
        LlumsisWin = true;
        for(int i = 0; i < numeroLlums; i++)
        {
            if(llumsTocades[i] == false)
            {   
                LlumsisWin = false;
            }
        }
    }
}
