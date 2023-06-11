using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jug1ARoca : MonoBehaviour
{
    public bool jug1Actiu;
    // Start is called before the first frame update
    void Start()
    {
        jug1Actiu = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player1Ma"))
        {   
            jug1Actiu = true;
        }
    }
}
