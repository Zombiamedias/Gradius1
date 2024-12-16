using System.Collections;
using UnityEngine;

public class PlayerFireAttack : MonoBehaviour
{
    public float fireRate = 0.5f;
    private float nextFireTime = 1f;
    private int currentProjectileIndex = 0;
    float timer;
    [SerializeField] private ProjectilePool projectilePool; // Referencia a la pool de proyectiles
    [SerializeField] private Transform firePoint;
    private FireType fireType;


    private void Start()
    {
        SetFireType(currentProjectileIndex); // Initial proyectile

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextFireTime) // Asegúrate de que el jugador esté disparando
        {
            FireProjectile();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetFireType(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetFireType(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetFireType(2);
        }
    }

    private void FireProjectile()
    {
        fireType.Fire(); // Dispara el proyectil
         
        ResetHotFired();
    }
    public void SetFireType(int projectileIndex)
    {
        currentProjectileIndex = projectileIndex;
        switch (projectileIndex)
        {

            case 0:
                fireType = new SingleShot(projectilePool, firePoint, projectileIndex); // singleshot pool
                break;
            case 1:
                fireType = new DoubleShot(projectilePool, firePoint, projectileIndex); // Cambia doubleshot pool
                break;
            case 2:
                fireType = new TripleShot(projectilePool, firePoint, projectileIndex); // Cambia tripleshot pool
                break;
            default:
                Debug.LogWarning("Shoot type missing");
                break;
        }
    }
    public void ResetHotFired()
    {
        nextFireTime = fireRate; // Establece el próximo tiempo de disparo
        timer = 0;
    }
}