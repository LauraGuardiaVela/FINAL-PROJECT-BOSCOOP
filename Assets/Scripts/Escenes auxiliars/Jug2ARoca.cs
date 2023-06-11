using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jug2ARoca : MonoBehaviour
{
    public bool jug2Actiu;
    // Start is called before the first frame update
    void Start()
    {
        jug2Actiu = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player2Peu"))
        {   
            jug2Actiu = true;
        
        }
        
    }
}
