using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{

    [Header("Jugador")]
    public PlayerController playerController;

    [Header("Mensaje Interfaz")]
    public TMP_Text Validar_E;

    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip errorSonido;
    public AudioClip sellingSonido;

    private int eggsPrice = 1;
    private int mayoPrice = 5;
    private int milkPrice = 10;
    private int cheesePrice = 20;

    private int totalSell = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Validar_E.text = "Oprima E para vender";
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
                if (playerController.eggs == 0 && playerController.mayo == 0 && playerController.milk == 0 && playerController.cheese == 0)
                {
                    audioSource.PlayOneShot(errorSonido);
                }
                else{
                totalSell = (eggsPrice * playerController.eggs) + (mayoPrice * playerController.mayo) + (milkPrice * playerController.milk) + (cheesePrice * playerController.cheese);          
                playerController.cash += totalSell;
                totalSell = 0;
                playerController.eggs = 0;
                playerController.mayo = 0;
                playerController.milk = 0;
                playerController.cheese = 0;
                audioSource.PlayOneShot(sellingSonido);
                Debug.Log("Dinero del jugador" + playerController.cash);
                }
            }
        }
    }
}
