using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magrana : MonoBehaviour
{
    private ProvaConjunta provaConjunta;
    public GameObject llavor1;
    public GameObject llavor2;

    // Start is called before the first frame update
    void Start()
    {
        provaConjunta = FindObjectOfType<ProvaConjunta>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2Peu"))
        {
            Desgranar();
        }
    }

    private void Desgranar()
    {
        // moure
        TweenPosition tweenPosition = gameObject.AddComponent<TweenPosition>();
        tweenPosition.targetPosOffset = new Vector3(0, 0, -8f);
        tweenPosition.timeToReachTarget = 2f;

        // fer mes petita
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = 4f;

        // apareixer llavors
        llavor1.SetActive(true);
        llavor2.SetActive(true);
        
        // llançar llavors
        llavor1.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, -1) * 5;
        llavor2.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, -1) * 5;
    }


}
