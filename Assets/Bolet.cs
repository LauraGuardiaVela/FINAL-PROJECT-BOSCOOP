using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Illuminar());
        }
    }

    private IEnumerator Illuminar()
    {
        var colorOriginal = this.GetComponent<Renderer>().material.color;
        var colorNou = Color.white;

        this.GetComponent<Renderer>().material.color = colorNou;

        yield return new WaitForSeconds(1f);
        this.GetComponent<Renderer>().material.color = colorOriginal;
    }
}
