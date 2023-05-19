using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneScript : MonoBehaviour
{
    public void cambioEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void cambioEscena(int escena)
    {
        SceneManager.LoadScene(escena);
    }
}
