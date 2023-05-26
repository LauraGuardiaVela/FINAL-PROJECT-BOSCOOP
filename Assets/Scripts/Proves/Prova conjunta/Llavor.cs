using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llavor : MonoBehaviour
{
    private ProvaConjunta provaConjunta;
    public GameObject player;
    private bool agafat;
    private bool perSerAlliberat;

    // Start is called before the first frame update
    void Start()
    {
        agafat = false;
        perSerAlliberat = false;
        provaConjunta = FindObjectOfType<ProvaConjunta>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agafat == true && perSerAlliberat == false)
        {
            this.transform.position = player.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agafat = true;
        }

        if (other.CompareTag("Test"))
        {
            perSerAlliberat = true;
            provaConjunta.ConjuntaisWin = true;
        }
    }
}
