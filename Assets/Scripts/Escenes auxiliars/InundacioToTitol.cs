using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InundacioToTitol : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            DeFinalATitol();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1Ma") || other.CompareTag("Player2Peu"))
        {   
            DeFinalATitol();
        }
    }

    public void DeFinalATitol(){
        SceneManager.LoadScene("Títol");
    }
}
