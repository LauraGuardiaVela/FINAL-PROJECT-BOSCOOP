using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InundacioToTitol : MonoBehaviour
{
    //public bool passarEscena;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            DeFinalATitol();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {   
            DeFinalATitol();
            
        }
        
    }

    public void DeFinalATitol(){
        SceneManager.LoadScene("Títol");
    }
}
