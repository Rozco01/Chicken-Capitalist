using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BankController : MonoBehaviour
{

    private int winState = 1;
    [Header("Letrero victoria")]
    public Image imagenBasada;
    public TMP_Text Tittle;
    public TMP_Text Texto;
    public TMP_Text Texto2;

    [Header("Numero En letrero")]
    public TMP_Text numberMoney;
    private int currentDebtMoney = -100000;

    [Header("Jugador")]
    public PlayerController playerController;
    public GameObject objetoConScript;
    private MonoBehaviour script;

    [Header("Mensaje Interfaz")]
    public TMP_Text Validar_E;

    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip errorSonido;

    // Start is called before the first frame update
    void Start()
    {
        script = objetoConScript.GetComponent<MonoBehaviour>();
        imagenBasada.enabled = false;
        Tittle.enabled = false;
        Texto.enabled = false;
        Texto2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(winState == 1){
            if(currentDebtMoney >= 0){
                numberMoney.text = "0";
                winState = 2;
            }else{
            UpdateValueText();
            }
        }else if(winState == 2){
            Ganaste();
        }
        
    }

    private void UpdateValueText()
    {
        numberMoney.text = currentDebtMoney.ToString(); // Actualizar el valor en el Text del UI
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Validar_E.text = "Oprima E para pagar al banco";
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

    private void OnTriggerStay(Collider other){
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Input.GetKeyDown(KeyCode.E) && playerController.cash == 0 || currentDebtMoney >= 0){
                    audioSource.PlayOneShot(errorSonido);
                    Debug.Log("No tienes dinero suficiente.");
                }else{
                    currentDebtMoney += playerController.cash;
                    playerController.cash = 0;
                    Debug.Log("Variable vaciada.");
                }
            }
        }
    }

    private void Ganaste(){
        script.enabled = false;
        imagenBasada.enabled = true;
        Tittle.enabled = true;
        Texto.enabled = true;
        Texto2.enabled = true;
        if (Input.GetKeyDown(KeyCode.E)){
            imagenBasada.enabled = false;
            Tittle.enabled = false;
            Texto.enabled = false;
            Texto2.enabled = false;
            script.enabled = true;
            winState = 3;
        }
    }

}
