using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papallona1 : MonoBehaviour
{
    private gestionadorJoc gestionadorJoc;

    // Atributs comuns
    public GameObject player;
    public GameObject papallona;

    // Cadascuna de les proves que ha de fer la papallona

    // Llums
    private ProvaLlums provaLlums;
    public List<GameObject> llistaObjectiusLlums = new List<GameObject>();
    private int objectiuActualLlum;

    // Flors
    private ProvaFlors provaFlors;
    public List<GameObject> llistaObjectiusFlors = new List<GameObject>();
    private int objectiuActualFlor;

    // Prova Conjunta Jugador 1
    private ProvaConjunta provaConjunta;
    public GameObject llavorInicialObjectiu; // Anem en direcció a la primera llavor per mostrar el moviment
    public GameObject testObjectiu; // Anem en direcció a la primera llavor per mostrar el moviment
    private int i; //controlar que només la primera vegada vagi cap a la posició i després oscil·li
    private float speed = 4f;

    // Variables moviment
    private float movementSpeed = 5f;
    private Vector3 targetPos;
    private bool isMoving = false;
    private Vector3 targetPosOffset;
    private Vector3 upOffset;

    void Start()
    {
        // Per poder accedir al gestionador del joc
        gestionadorJoc = FindObjectOfType<gestionadorJoc>();

        // Per totes les proves igual
        targetPosOffset = new Vector3(0, 5, 1);
        upOffset = new Vector3(0, 100, 0);

        // Un init diferent per cada prova
        StartProvaLlums();
        StartProvaFlors();
        StartProvaConjunta();

    }
    void StartProvaLlums()
    {
        provaLlums = FindObjectOfType<ProvaLlums>();
        llistaObjectiusLlums = provaLlums.sequenciaLlums;
        objectiuActualLlum = 0;
    }

    void StartProvaFlors()
    {
        provaFlors = FindObjectOfType<ProvaFlors>();
        llistaObjectiusFlors = provaFlors.sequenciaFlors;
        objectiuActualFlor = 0;
    }

    void StartProvaConjunta()
    {
        i = 0;
    }

    void Update()
    {
        if (gestionadorJoc.provaActualJugador1 == "Prova Llums")
        {
            UpdateProvaLlums();
        }
        else if (gestionadorJoc.provaActualJugador1 == "Prova Flors" && provaLlums.LlumsisWin == true)
        {
            movementSpeed = 10f;
            UpdateProvaFlors();
        }
        else if ((gestionadorJoc.provaActualJugador1 == "Prova Conjunta") && (gestionadorJoc.provaActualJugador2 == "Prova Conjunta"))
        {
            UpdateProvaConjunta();
        }
        else if (provaConjunta.ConjuntaisWin == true)
        {
            UpdateFinal();
        }
    }

    void UpdateProvaLlums()
    {
        if (objectiuActualLlum < llistaObjectiusLlums.Count && !isMoving)
        {
            targetPos = llistaObjectiusLlums[objectiuActualLlum].transform.position + targetPosOffset;
            StartCoroutine(MoveToTarget());

            objectiuActualLlum++;
        }
    }

    void UpdateProvaFlors()
    {
        if (objectiuActualFlor < llistaObjectiusFlors.Count && !isMoving)
        {
            targetPos = llistaObjectiusFlors[objectiuActualFlor].transform.position + targetPosOffset;
            StopCoroutine(MoveToTarget());
            StartCoroutine(MoveToTarget());
            objectiuActualFlor++;
        }
    }

    void UpdateProvaConjunta()
    {
        if (i == 0)
        {
            targetPos = llavorInicialObjectiu.transform.position + targetPosOffset;
            if (!isMoving)
            {
                StopCoroutine(MoveToTarget());
                StartCoroutine(MoveToTarget());
            }
        } else
        {
            targetPos = testObjectiu.transform.position + targetPosOffset;
            StartCoroutine(MoveToTarget());
        }

    }

    void UpdateFinal()
    {
        targetPos = papallona.transform.position + upOffset;
        StopCoroutine(MoveToTarget());
        StartCoroutine(MoveToTarget());
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
        if ((gestionadorJoc.provaActualJugador2 == "Prova Conjunta") && (gestionadorJoc.provaActualJugador1 == "Prova Conjunta"))
        {
            i++;
        }

    }
}