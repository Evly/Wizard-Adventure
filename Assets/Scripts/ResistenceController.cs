using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistenceController : MonoBehaviour
{
    // Start is called before the first frame update
    public int resistencia;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void registrarImpacto(Vector3 puntoimpacto){
        resistencia --;
        if(resistencia <=0){
            StartCoroutine("Colision");
        }
    }



    private void OnParticleCollision(GameObject other) {
        //Destroy(transform.gameObject);
    }

    public IEnumerator Colision(){
        audioSource.Play(); //sonido al destruir objeto
        yield return new WaitForSecondsRealtime(2.5f);

        if(transform.gameObject.CompareTag("Recolectable")){
            Destroy(transform.gameObject);
            Debug.Log("Colision rayo-objeto");
            GameEvents.sumarScore(100);
        }
        
       
    }

}
