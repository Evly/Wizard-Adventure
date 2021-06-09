using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public  Text textoPuntos;

    public  Text textoVida;
    void Start()
    {
        textoPuntos.text = "Puntos: "+GameEvents.getScore().ToString();
        textoVida.text = "Vida: "+GameEvents.getVida().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textoPuntos.text = "Puntos: "+GameEvents.getScore().ToString();
        textoVida.text = "Vida: "+GameEvents.getVida().ToString();
    }
}