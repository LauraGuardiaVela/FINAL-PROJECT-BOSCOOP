using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Triggers
    public List<GameObject> triggersAigua = new List<GameObject>();

    // Aigua
    public GameObject aigua;

    // Illa
    public GameObject illa;

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
        nivellAigua();

    }
    void obrintCamins()
    {
        if(provaLlums.LlumsisWin == true)
        {
            camins[2].SetActive(true); // camí 3
            triggersAigua[7].SetActive(false); // trigger camí 3
            provaActualJugador2 = "Prova Volcans";
        }
        if(provaFlors.FlorsisWin == true)
        {
            camins[3].SetActive(true); // camí 4
            triggersAigua[8].SetActive(false); // trigger camí 4
            provaActualJugador2 = "Prova Conjunta";
        }

        if(provaBolets.boletsIsWin == true)
        {
            camins[0].SetActive(true); // camí 1
            triggersAigua[5].SetActive(false); // trigger camí 1
            provaActualJugador1 = "Prova Flors";
        }
        if(provaVolcans.volcansIsWin == true)
        {
            camins[1].SetActive(true); // camí 2
            triggersAigua[6].SetActive(false); // trigger camí 2
            provaActualJugador1 = "Prova Conjunta";
        }

        if(provaConjunta.ConjuntaisWin == true)
        {
            camins[4].SetActive(true); // camí 5
            triggersAigua[9].SetActive(false); // trigger camí 5
            StartCoroutine(Esperar());
            SceneManager.LoadScene("JocGuanyat");
        }   
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(5);
    }
    IEnumerator elevantRoques()
    {
        if(camins[0].activeInHierarchy)
        {
            yield return new WaitForSeconds(2);
            EnableChildMeshRenderer(roquesProves[1]);
            triggersAigua[3].SetActive(false); // trigger prova flors
            
        }
        if(camins[2].activeInHierarchy)
        {
            yield return new WaitForSeconds(2);
            EnableChildMeshRenderer(roquesProves[3]);
            triggersAigua[2].SetActive(false); // trigger prova volcans
        }
        if(camins[1].activeInHierarchy && camins[3].activeInHierarchy)
        {
            yield return new WaitForSeconds(2);
            EnableChildMeshRenderer(roquesProves[4]);
            triggersAigua[4].SetActive(false); // trigger prova conjunta
        }
    }
    void nivellAigua()
    {
        if (aigua.transform.position.y >= 5.0f)
        {
            //podríem posar la pantalla de que ha perdut
            SceneManager.LoadScene("Inundació");

            //POSAR SOROLL AIGUA
            //illa.transform.position = new Vector3(0, -15, 0);
        }
    }
}
