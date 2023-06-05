using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoneBuild2Controller : MonoBehaviour
{
    [Header("Gallinero")]
    public GameObject gallinero2;

    [Header("Precio")]
    public int precioGallinero = 0;

    [Header("Letrero")]
    public Image imagenCanvas;
    public Sprite nuevaImagen;
    public Sprite huevoImagen;
    public TMP_Text cash;

    [Header("Mensaje Interfaz")]
    public TMP_Text Validar_E;

    [Header("Jugador")]
    public PlayerController playerController;

    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip errorSonido;

    // Start is called before the first frame update
    void Start()
    {
        gallinero2.SetActive(false);
        imagenCanvas.sprite = nuevaImagen;
        cash.text = precioGallinero.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Validar_E.text = "Oprima E para comprar";
            Validar_E.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Validar_E.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (playerController.cash >= precioGallinero){
                    
                    playerController.cash -= precioGallinero;
                    imagenCanvas.sprite = huevoImagen;
                    cash.text = "";
                    gallinero2.SetActive(true);
                    gameObject.SetActive(false);
                }
                else{
                    Debug.Log("Jugador tiene " + playerController.cash);
                    audioSource.PlayOneShot(errorSonido);
                }
               
            }
        }
    }
}
