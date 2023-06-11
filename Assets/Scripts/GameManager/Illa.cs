using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illa : MonoBehaviour
{
    private gestionadorJoc gestJoc;

    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        gestJoc = FindObjectOfType<gestionadorJoc>();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == 2)
        {
            gestJoc.jocGuanyat = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1Ma") || other.CompareTag("Player2Peu"))
        {
            counter++;
        }
    }
}
