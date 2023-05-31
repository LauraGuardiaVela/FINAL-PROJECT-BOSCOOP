using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayersOnRock : MonoBehaviour
{
    private Jug1ARoca jugador1Roca;
    private Jug2ARoca jugador2Roca;
    public bool jugadorsAlesRoques;

    // Start is called before the first frame update
    void Start()
    {
        jugador1Roca = FindObjectOfType<Jug1ARoca>();
        jugador2Roca = FindObjectOfType<Jug2ARoca>();
        jugadorsAlesRoques = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jugador1Roca.jug1Actiu == true && jugador2Roca.jug2Actiu == true){
            jugadorsAlesRoques = true;
        }
    }
}
