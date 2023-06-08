using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject objetoConScript;
    public GameObject menuPausa;
    public Button botonReanudar;
    public Button botonSalir;
    private MonoBehaviour script;
    // Start is called before the first frame update
    void Start()
    {
        script = objetoConScript.GetComponent<MonoBehaviour>();
        menuPausa.SetActive(false);
        botonReanudar.onClick.AddListener(ReanudarJuego);
        botonSalir.onClick.AddListener(SalirDelJuego);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (menuPausa.activeSelf){
                // Si el menú de pausa está activo, lo desactivamos y reactivamos el script
                menuPausa.SetActive(false);
                script.enabled = true;
                Time.timeScale = 1f; // Reanudamos el tiempo normal
            }
            else{
                // Si el menú de pausa está inactivo, lo activamos y desactivamos el script
                menuPausa.SetActive(true);
                script.enabled = false;
                Time.timeScale = 0f; // Pausamos el tiempo
                Cursor.visible = true;
            }
        }
    }

    void ReanudarJuego(){
        menuPausa.SetActive(false);
        script.enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1f; // Reanudamos el tiempo normal
    }

    void SalirDelJuego(){
        Application.Quit();
    }
}
