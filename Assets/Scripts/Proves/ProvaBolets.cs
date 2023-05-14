using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaBolets : MonoBehaviour
{

    public List<GameObject> llistaBolets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ferSequencia());

    }

    IEnumerator ferSequencia(){

        for(int i = 0; i < 4; i++){
            var boletActual = llistaBolets[i];
            var colorOriginal = boletActual.GetComponent<Renderer>().material.color;
            var colorNou = Color.white;
            boletActual.GetComponent<Renderer>().material.color = colorNou;

            yield return new WaitForSeconds(2f);
            boletActual.GetComponent<Renderer>().material.color = colorOriginal;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
