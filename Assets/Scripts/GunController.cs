using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    public bool isFiring = false;


    [Header("Gun Settings")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    [Header("Sound Settings")]
    public AudioClip shootSound;

    [Header("Bullet Settings")]
    public float bulletDamage = 10f;
    public float bulletSpeed = 10f;
    
    public float timeBetweenShots; // Cadencia de disparo (balas por segundo)
    private float nextShotTime; // Tiempo para el próximo disparo

    // Start is called before the first frame update
    void Start(){
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        timeBetweenShots = 1f / 5f; // 5 balas por segundo
        nextShotTime = Time.time; // Configura el próximo disparo para el inicio
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot()){
            Shoot();
        }else
        {
            isFiring = false;
            animator.SetBool("isFiring", isFiring);
        }
    }

    private bool CanShoot()
    {
        return Time.time >= nextShotTime; // Verifica si es posible disparar según el tiempo actual
    }

    void Shoot(){
        // Código a ejecutar cuando se presione el botón derecho del mouse
        //1-Instanciar la BalaPrefab en las posiciones de BalaInicio
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = firePoint.forward * bulletSpeed;


        //Debemos Destruir la bala
        Destroy(bullet, 1.0f);

        //Animar el disparo
        isFiring = true;
        animator.SetBool("isFiring", isFiring);
        AudioSource.PlayClipAtPoint(shootSound, firePoint.position);

        nextShotTime = Time.time + timeBetweenShots; // Configura el próximo disparo
    }

}
