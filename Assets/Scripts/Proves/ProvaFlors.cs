using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvaFlors : MonoBehaviour
{
    public List<GameObject> llistaFlors = new List<GameObject>();
    //public GameObject Flor;
    private float targetScale; // 1
    public float timeToReachTarget; // 2
    private float startScale;  // 3
    private float percentScaled; // 4
    
    // Start is called before the first frame update
    void Start()
    {
        targetScale = 65f;
        startScale = transform.localScale.x;
        //StartCoroutine(ferSequencia());
    }

    /*
    IEnumerator ferSequencia(){
        for(int i = 0; i < 3; i++){
            
            var florActual = llistaFlors[i];
            var scaleOriginal = boletActual.GetComponent<Renderer>().material.color;
            var colorNou = Color.white;
            boletActual.GetComponent<Renderer>().material.color = colorNou;

            yield return new WaitForSeconds(5f);
            boletActual.GetComponent<Renderer>().material.color = colorOriginal;

            
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f) // 1
        {
            percentScaled += Time.deltaTime / timeToReachTarget; // 2
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); // 3
            //Flor.transform.localScale = new Vector3(scale, scale, scale); // 4
            llistaFlors[0].transform.localScale = new Vector3(scale, scale, scale);
            llistaFlors[1].transform.localScale = new Vector3(scale, scale, scale);
            llistaFlors[2].transform.localScale = new Vector3(scale, scale, scale);
            llistaFlors[3].transform.localScale = new Vector3(scale, scale, scale);
            llistaFlors[4].transform.localScale = new Vector3(scale, scale, scale);
            llistaFlors[5].transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}