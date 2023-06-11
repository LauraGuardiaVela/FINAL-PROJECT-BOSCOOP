using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jugar : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            DeTitolAPreJoc();
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player1Ma") || other.CompareTag("Player2Peu"))
        {   
            DeTitolAPreJoc();
        }
    }

    public void DeTitolAPreJoc(){
        SceneManager.LoadScene("PreJoc");
    }
}
