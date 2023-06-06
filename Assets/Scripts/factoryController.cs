using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class factoryController : MonoBehaviour
{
    [Header("Numero En letrero")]
    public TMP_Text NumberMayo;

    [Header("Mensaje Interfaz")]
    public TMP_Text Validar_E;

    [Header("Jugador")]
    public PlayerController playerController;

    [Header("Cantidad de moyonesa a producir")]
    public int currentValueMayo = 0;

    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip collectSonido;
    public AudioClip buildSonido;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(buildSonido);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateValueText();
        CantMayo();
    }

    private void UpdateValueText(){
        NumberMayo.text = currentValueMayo.ToString(); // Actualizar el valor en el Text del UI
    }

    private void CantMayo(){
        currentValueMayo = playerController.eggs; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Validar_E.text = "Oprima E para producir mayonesa";
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
                playerController.mayo += currentValueMayo;
                playerController.eggs = 0;
                currentValueMayo = 0;
                audioSource.PlayOneShot(collectSonido);
                Debug.Log("Variable vaciada.");
            }

        }
    }
}
