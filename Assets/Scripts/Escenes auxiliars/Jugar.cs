using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Jugar : MonoBehaviour
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
            DeTitolAPreJoc();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {   
            DeTitolAPreJoc();
        }
        
    }

    public void DeTitolAPreJoc(){
        SceneManager.LoadScene("PreJoc");
    }
}
