using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CowBarnController : MonoBehaviour
{
    [Header("Numero En letrero")]
    public TMP_Text NumberMilk;

    [Header("Jugador")]
    public PlayerController playerController;

    [Header("Mensaje Interfaz")]
    public TMP_Text Validar_E;

    [Header("Cantidad de leche del establo")]
    public int unitPerSecond = 10;
    public int currentValueMilk = 0;

    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip collectSonido;

    //Intervalos de generacion
    private float timer = 0f;
    private float interval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currentValueMilk = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            IncrementValue();
            timer = 0f;
        }

        UpdateValueText();
    }

    private void IncrementValue()
    {
        currentValueMilk += unitPerSecond; 
    }

    private void UpdateValueText()
    {
        NumberMilk.text = currentValueMilk.ToString(); // Actualizar el valor en el Text del UI
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Validar_E.text = "Oprima E para recoger";
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
                playerController.milk += currentValueMilk;
                currentValueMilk = 0;
                Debug.Log("Variable vaciada.");
            }
        }
    }
}
