using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Rotación")]
    public int rotationScale = 10;
    public float anguloDiaInicio = 180f;
    public float anguloDiaFin = 270f;
    public float anguloNocheInicio = -90f;
    public float anguloNocheFin = 0f;

    [Header("Script jugador")]
    public GameObject scarGun;

    [Header("Script del spawn de enemigos")]
    public GameObject enemySpawner;

    [Header("Audio")]
    public AudioClip audioDia;
    public AudioClip audioNoche;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationScale * Time.deltaTime, 0, 0);

        // Obtén la rotación en el eje X de la Directional Light
        float rotacionX = transform.rotation.eulerAngles.x;

        // Comprueba si está en el rango del día
        if (rotacionX >= anguloDiaInicio && rotacionX <= anguloDiaFin){
            // Es de día
            if (!audioSource.isPlaying || audioSource.clip != audioDia){
                audioSource.clip = audioDia;
                audioSource.loop = true;
                audioSource.Play();
                scarGun.SetActive(false);
                enemySpawner.SetActive(false);
            }
        }   
        else{
            // Es de noche
            if (!audioSource.isPlaying || audioSource.clip != audioNoche){
                audioSource.clip = audioNoche;
                audioSource.loop = true;
                audioSource.Play();
                scarGun.SetActive(true);
                enemySpawner.SetActive(true);
                enemySpawner.SetActive(true);
            }
        }
        // Reproducir clip de audio continuamente
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
