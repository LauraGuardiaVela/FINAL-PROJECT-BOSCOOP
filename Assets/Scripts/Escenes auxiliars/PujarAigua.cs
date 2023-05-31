using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PujarAigua : MonoBehaviour
{
    private CheckPlayersOnRock jugadorsRoques;

    private int posYfinal;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        //yield return new WaitForSeconds(2);
        jugadorsRoques = FindObjectOfType<CheckPlayersOnRock>();
        posYfinal = -16;
        offset = 0.1f;
        this.transform.position = new Vector3(this.transform.position.x, -50,this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //augmentAigua();
        StartCoroutine(augmentAigua());
    }

    IEnumerator augmentAigua(){
    //void augmentAigua(){    
        if(jugadorsRoques.jugadorsAlesRoques == true){
            if(posYfinal <= this.transform.position.y){
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("Scene");
            } else {
                this.transform.position += new Vector3(0, offset,0);
            }
        }

        /*if(posYfinal <= this.transform.position.y){
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Scene");
        } else {
            this.transform.position += new Vector3(0, offset,0);
        }*/
        
    }
}
