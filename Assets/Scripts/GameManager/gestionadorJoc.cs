using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionadorJoc : MonoBehaviour
{
    private ProvaFlors provaFlors;
    private ProvaVolcans provaVolcans;
    private ProvaConjunta provaConjunta;
    private ProvaLlums provaLlums;
    private ProvaBolets provaBolets;

    public string provaActualJugador1;
    public string provaActualJugador2;

    //Camins
    public List<GameObject> camins = new List<GameObject>(); 

    //Proves
    public List<GameObject> roquesProves = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        // La prova dels bolets i la de les llums seran les primeres sempre 
        provaActualJugador1 = "Prova Llums";
        provaActualJugador2 = "Prova Bolets";

        provaFlors = FindObjectOfType<ProvaFlors>();
        provaVolcans = FindObjectOfType<ProvaVolcans>();
        provaConjunta = FindObjectOfType<ProvaConjunta>();
        provaLlums = FindObjectOfType<ProvaLlums>();        
        provaBolets = FindObjectOfType<ProvaBolets>();

        //HERE YOUR CODE 
        for(int i = 0; i < roquesProves.Count; i++)
        {
            if(i != 0 && i != 2){ //només volem que apareguin les 2 primeres (una de cada jugador)
                DisableChildMeshRenderer(roquesProves[i]);
            }
        }

    }
    void DisableChildMeshRenderer(GameObject parent)
    {
        MeshRenderer[] meshRenderers = parent.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.enabled = false;
        }
    }
    void EnableChildMeshRenderer(GameObject parent)
    {
        MeshRenderer[] meshRenderers = parent.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        obrintCamins();
        StartCoroutine(elevantRoques());
    }
    void obrintCamins()
    {
        if(provaLlums.LlumsisWin == true)
        {
            camins[2].SetActive(true);
            provaActualJugador2 = "Prova Volcans";
        }
        if(provaFlors.FlorsisWin == true)
        {
            camins[3].SetActive(true);
            provaActualJugador2 = "Prova Conjunta";
        }

        if(provaBolets.boletsIsWin == true)
        {
            camins[0].SetActive(true);
            provaActualJugador1 = "Prova Flors";
        }
        if(provaVolcans.volcansIsWin == true)
        {
            camins[1].SetActive(true);
            provaActualJugador1 = "Prova Conjunta";
        }

        if(provaConjunta.ConjuntaisWin == true)
        {
            camins[4].SetActive(true);
        }   
    }
    IEnumerator elevantRoques()
    {
        if(camins[0].activeInHierarchy)
        {
            yield return new WaitForSeconds(2);
            EnableChildMeshRenderer(roquesProves[1]);
            //roquesProves[1].SetActive(true);
            
        }
        if(camins[2].activeInHierarchy)
        {
            yield return new WaitForSeconds(2);
            EnableChildMeshRenderer(roquesProves[3]);
            //roquesProves[3].SetActive(true);
        }
        if(camins[1].activeInHierarchy && camins[3].activeInHierarchy)
        {
            yield return new WaitForSeconds(2);
            EnableChildMeshRenderer(roquesProves[4]);
            //roquesProves[4].SetActive(true);
        }
    }
}
