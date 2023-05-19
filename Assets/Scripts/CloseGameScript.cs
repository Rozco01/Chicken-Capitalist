using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Salir juego");
    }
}
