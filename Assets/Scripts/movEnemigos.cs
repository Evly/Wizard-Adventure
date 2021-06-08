using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movEnemigos : MonoBehaviour
{
    //private float velocidadX = 1;
    //private float velocidadZ = -0.5f;
    Transform posicionJugador;
    private Vector3 posicion;
    UnityEngine.AI.NavMeshAgent agente;
    //Start is called before the first frame update
    void Start()
    {
        posicionJugador = GameObject.FindGameObjectWithTag ("Jugador").transform;
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination (posicionJugador.position);
        /*transform.Translate(
            velocidadX * Time.deltaTime,
            0,
            velocidadZ * Time.deltaTime
        );
        if ((transform.position.x < -1)||(transform.position.x > 1))
            velocidadX = -velocidadX;
        if ((transform.position.z < -1.5)||(transform.position.z > 1.5))
            velocidadX = -velocidadX;*/
    }

}
