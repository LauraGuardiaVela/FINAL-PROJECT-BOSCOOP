using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sortir : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            DeTitolASortir();
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player1Ma") || other.CompareTag("Player2Peu"))
        {   
            DeTitolASortir();
        }
    }

    public void DeTitolASortir(){
        Application.Quit();
    }
}
