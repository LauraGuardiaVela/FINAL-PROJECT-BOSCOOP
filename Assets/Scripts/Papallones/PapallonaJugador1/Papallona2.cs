using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papallona2 : MonoBehaviour
{

    private gestionadorJoc gestionadorJoc;

    // Atributs comuns
    public GameObject player;
    public GameObject papallona;

    // Cadascuna de les proves que ha de fer la papallona

    // Bolets
    private ProvaBolets provaBolets;
    public List<GameObject> llistaObjectiusBolets = new List<GameObject>();
    private int objectiuActualBolet;

    // Volcans
    private ProvaVolcans provaVolcans;
    public List<GameObject> llistaObjectiusVolcans = new List<GameObject>();
    private int objectiuActualVolca;

    // Prova Conjunta Jugador 2
    private ProvaConjunta provaConjunta;
    public GameObject magranaInicialObjectiu; // Anem en direcció a la primera magrana per mostrar el moviment
    private int i; //controlar que només la primera vegada vagi cap a la posició i després oscil·li
    private float speed = 10f;

    // Variables moviment
    public float movementSpeed = 100f; 
    private Vector3 targetPos;
    private bool isMoving = false;
    private Vector3 targetPosOffset;

    void Start()
    {
        // Per poder accedir al gestionador del joc
        gestionadorJoc = FindObjectOfType<gestionadorJoc>();
        
        // Per totes les proves igual
        targetPosOffset = new Vector3(-3,0,-3);

        // Un init diferent per cada prova
        StartProvaBolets();
        StartProvaVolcans();
        StartProvaConjunta();
       
    }
    void StartProvaBolets()
    {
        provaBolets = FindObjectOfType<ProvaBolets>();
        llistaObjectiusBolets = provaBolets.sequenciaBolets;
        objectiuActualBolet = 0;
    }
    void StartProvaVolcans()
    {
        provaVolcans = FindObjectOfType<ProvaVolcans>();
        llistaObjectiusVolcans = provaVolcans.sequenciaVolcans;
        objectiuActualVolca = 0;
    }
    void StartProvaConjunta()
    {
        //magranaInicialObjectiu.transform.position;
        gestionadorJoc.provaActualJugador1 = "Prova Llums";
        gestionadorJoc. provaActualJugador2 = "Prova Bolets";
        i = 0;
    }

    void Update()
    {
        /*Debug.Log("PROVA J1:"+gestionadorJoc.provaActualJugador1+" PROVA J2:"+gestionadorJoc.provaActualJugador2);
        //if((gestionadorJoc.provaActualJugador2 == "Prova Conjunta") && (gestionadorJoc.provaActualJugador1 == "Prova Conjunta"))
        if(gestionadorJoc.provaActualJugador2 == "Prova Conjunta")
        {
            Debug.Log("OKAY HERE I AM");
            UpdateProvaConjunta();
        }*/
        if(gestionadorJoc.provaActualJugador2 == "Prova Bolets" )
        {   
            UpdateProvaBolets();
        }
        else if(gestionadorJoc.provaActualJugador2 == "Prova Volcans" && provaBolets.boletsIsWin == true)
        {
            UpdateProvaVolcans();
        }else{
            UpdateProvaConjunta();
        }

    }
    void UpdateProvaBolets()
    {
        if (objectiuActualBolet < llistaObjectiusBolets.Count && !isMoving)
        {
            targetPos = llistaObjectiusBolets[objectiuActualBolet].transform.position + targetPosOffset;
            StartCoroutine(MoveToTarget());
            objectiuActualBolet++;
        }
    }
    void UpdateProvaVolcans()
    {
        if (objectiuActualVolca < llistaObjectiusVolcans.Count && !isMoving)
        {
            targetPos = llistaObjectiusVolcans[objectiuActualVolca].transform.position + targetPosOffset;
            StartCoroutine(MoveToTarget());
            objectiuActualVolca++;
        }
    }

    void UpdateProvaConjunta()
    {
        if(i == 0)
        {
            targetPos = magranaInicialObjectiu.transform.position + targetPos;
            StartCoroutine(MoveToTarget());
            i++;
            
        }else{

            float y = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;
            papallona.transform.position = new Vector3(0, 0, y);
        }
        
    }
    IEnumerator MoveToTarget()
    {
        isMoving = true;
        Vector3 startPos = papallona.transform.position;
        float distance = Vector3.Distance(startPos, targetPos);
        float startTime = Time.time;

        while (papallona.transform.position != targetPos)
        {
            float timeSinceStart = Time.time - startTime;
            float fraction = timeSinceStart * movementSpeed / distance;
            papallona.transform.position = Vector3.Lerp(startPos, targetPos, fraction);
            yield return null;
        }

        isMoving = false;
    }
}
