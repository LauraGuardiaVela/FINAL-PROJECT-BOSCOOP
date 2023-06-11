using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llum : MonoBehaviour
{
    private ProvaLlums ProvaLlums;
    public GameObject llum;

    public AudioSource llumetes;
    
    private Color colorOriginal;
    private Color colorIlluminat;

    // Start is called before the first frame update
    void Start()
    {
        ProvaLlums = FindObjectOfType<ProvaLlums>();

        colorOriginal = this.GetComponent<Renderer>().material.color;
        colorIlluminat = Color.cyan;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1Ma"))
        {
            Comprovar(other);
            llumetes.Play();
        }
    }


    public void Comprovar(Collider other)
    {
        if(llum.Equals(ProvaLlums.sequenciaLlums[ProvaLlums.iteradorLlums]))
        {
            ProvaLlums.llumsTocades[ProvaLlums.iteradorLlums] = true;
            StartCoroutine(Illuminar());

            if(ProvaLlums.iteradorLlums <= ProvaLlums.numeroLlums - 2) //gestionar que l'iterador no sigui més gran que el número de llums
            {
                ProvaLlums.iteradorLlums++; 
            }
        }else{
            ProvaLlums.iteradorLlums = 0;
            ProvaLlums.timeToReset = true;
            
        }

    }

    private IEnumerator Illuminar()
    {
        this.GetComponent<Renderer>().material.color = colorIlluminat;

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator DesIlluminar()
    {
        this.GetComponent<Renderer>().material.color = colorOriginal;
        yield return new WaitForSeconds(1f);
    }
}
