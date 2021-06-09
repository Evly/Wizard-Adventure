using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    // Start is called before the first frame update
    private static int vida = 100;
    private static int score = 0;

    private static int enemiesNumber = 4; 
    private static string finalText ="";

    public static void restarVida(int number){
       vida = vida - number;
    }

    public static void sumarScore(int number){
       score = score + number;
    }

    public static int getVida(){
        return vida;
    }

    public static int getScore(){
        return score;
    }

    public static void reiniciarUI(){
        vida = 100;
        score = 0;
    }

    public static void eliminarEnemigo(){
        if(enemiesNumber != 0){
            enemiesNumber --;
        }
    }

    public static int getEnemigos(){
        return enemiesNumber;
    }

    public static void setFinalText(string mensaje){
        finalText = mensaje;
    }

    public static string getFinalText(){
        return finalText;
    }

}
