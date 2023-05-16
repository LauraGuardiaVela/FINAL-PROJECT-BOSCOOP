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
        provaFlors = FindObjectOfType<ProvaFlors>();
        provaVolcans = FindObjectOfType<ProvaVolcans>();
        provaConjunta = FindObjectOfType<ProvaConjunta>();
        provaLlums = FindObjectOfType<ProvaLlums>();        
        provaBolets = FindObjectOfType<ProvaBolets>();

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
        }
        if(provaFlors.FlorsisWin == true)
        {
            camins[3].SetActive(true); // camí 4
            triggersAigua[8].SetActive(false); // trigger camí 4
        }
        if(provaBolets.boletsIsWin == true)
        {
            camins[0].SetActive(true); // camí 1
            triggersAigua[5].SetActive(false); // trigger camí 1
        }
        if(provaVolcans.volcansIsWin == true)
        {
            camins[1].SetActive(true); // camí 2
            triggersAigua[6].SetActive(false); // trigger camí 2
        }
        if(provaConjunta.ConjuntaisWin == true)
        {
            camins[4].SetActive(true); // camí 5
            triggersAigua[9].SetActive(false); // trigger camí 5
        }   
    }
    IEnumerator elevantRoques()
    {
        if(camins[0].activeInHierarchy) // supera prova bolets -> camí 1 s'obre
        {
            yield return new WaitForSeconds(5);
            roquesProves[1].SetActive(true); // roca flors
            triggersAigua[3].SetActive(false); // trigger prova flors
        }
        if(camins[2].activeInHierarchy) // supera prova llums -> camí 3 s'obre
        {
            yield return new WaitForSeconds(5);
            roquesProves[3].SetActive(true); // roca volcans
            triggersAigua[2].SetActive(false); // trigger prova volcans
        }
        if(camins[1].activeInHierarchy && camins[3].activeInHierarchy)
        {
            yield return new WaitForSeconds(5);
            roquesProves[4].SetActive(true); // roca conjunta
            triggersAigua[4].SetActive(false); // trigger prova conjunta

        }
    }

    void nivellAigua()
    {
        if (aigua.transform.position.y >= 5.0f)
        {
            illa.transform.position = new Vector3(0, -15, 0);
        }
    }
}

