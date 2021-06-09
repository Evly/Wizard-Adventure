/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movEnemigos : MonoBehaviour
{
    //private float velocidadX = 1;
    //private float velocidadZ = -0.5f;
    //private float velocidadDisparo = -2;
    //[SerializeField] Transform prefabDisparo = null;
    Transform posicionJugador;
    private Vector3 posicion;
    UnityEngine.AI.NavMeshAgent agente;
    //Start is called before the first frame update
    void Start()
    {
        posicionJugador = GameObject.FindGameObjectWithTag ("Jugador").transform;
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();

       // StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination (posicionJugador.position);
      */  /*transform.Translate(
            velocidadX * Time.deltaTime,
            0,
            velocidadZ * Time.deltaTime
        );
        if ((transform.position.x < -1)||(transform.position.x > 1))
            velocidadX = -velocidadX;
        if ((transform.position.z < -1.5)||(transform.position.z > 1.5))
            velocidadX = -velocidadX;*/
 //   }

   /* IEnumerator Disparar(){
        float pausa = Random.Range(3, 7.5f);
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabDisparo,
            transform.position,
            Quaternion.identity);
        disparo.gameObject.GetComponent<Rigibody>();
        new Vector3(0, velocidadDisparo, 0);
    }*/
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class movEnemigos : MonoBehaviour
{
    Transform posicionJugador;
    NavMeshAgent agente;
    public int distanciaJugador;
    public int vidaEnemigo=2;
    public bool enemigoMuerto = false;
    bool moveIni = false;
    Animator anim; 
    public GameObject despoint;
    public GameObject initpoint;
    private AudioSource muerteJugador;
    private Collider colider;
    // Start is called before the first frame update
    void Start()
    {
        posicionJugador = GameObject.FindGameObjectWithTag("Player").transform;
        agente = GetComponent<NavMeshAgent>();  
        anim = GetComponent<Animator> ();
        muerteJugador = GetComponent<AudioSource> ();
        colider = GetComponent<Collider> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemigoMuerto){
            if (Vector3.Distance(posicionJugador.position, transform.position) >= distanciaJugador){
                if (agente.remainingDistance < 0.5f){
                    moveAutomatic();
                    moveIni = !moveIni;
                    colider.isTrigger = false;
                }
                
                    //irAlSiguientePunto();
            }else{
                    attackPlayer();
            }

       }
    }

    void attackPlayer(){
        if(gameObject.transform.position.x <= posicionJugador.position.x){
            colider.isTrigger = true;
        }else{
            colider.isTrigger = false;
        }
        agente.SetDestination(posicionJugador.position);
    }
    
    void moveAutomatic(){
        if(moveIni){
            agente.SetDestination(despoint.transform.position);
        }else{
            agente.SetDestination(initpoint.transform.position);
        }
        
    }

    // void OnParticleCollision(GameObject other) {
    //      killEnemy();
    // }
    private void OnParticleCollision(GameObject other) {
        killEnemy();   
    }
    

    public void killEnemy(){
        vidaEnemigo-=1;
        if(vidaEnemigo == 0 ){
            StartCoroutine (died());
        }
    }

    public IEnumerator died(){
        if(!enemigoMuerto){
            enemigoMuerto=true;
            anim.SetBool("estaMuerto",true);
            muerteJugador.Play();
            GameEvents.sumarScore(200);
            GameEvents.eliminarEnemigo();
            yield return new WaitForSecondsRealtime(3.45f);
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            GameEvents.restarVida(10);
        }
    }

}
