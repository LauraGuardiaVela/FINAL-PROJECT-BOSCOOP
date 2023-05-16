using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int playerIndex;
    [SerializeField] GameObject aigua;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPosition(Vector3 pos)
    {
        //swith playerIndex
        // a les slides
        Vector3 newPos;
        switch(playerIndex){
            case 1: 
            newPos = new Vector3(Mathf.Clamp(pos.x, 0, 50), pos.y, pos.z);
            break;
            case 2: 
            newPos = new Vector3(Mathf.Clamp(pos.x, 50, 100), pos.y, pos.z);
            break;
            case 3: 
            newPos = pos;
            break;
        }
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 moveUp = new Vector3(0f, 1f, 0f);

        if (other.CompareTag("TriggerAigua"))
        {
            aigua.transform.position = aigua.transform.position + moveUp;
        }
    }
}
