using System.Collections;
using UnityEngine;

public class PlayerFireAttack : MonoBehaviour
{
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
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
    }

    private void FireProjectile()
    {
        fireType.Fire(); // Dispara el proyectil
        nextFireTime = Time.time + fireRate; // Establece el próximo tiempo de disparo
    }
    public void SetFireType(int projectileIndex)
    {
        currentProjectileIndex = projectileIndex;
        switch (projectileIndex)
        {

            case 0:
                fireType = new SingleShot(projectilePool, firePoint, projectileIndex); // Cambia para usar la pool
                break;
            case 1:
                fireType = new DoubleShot(projectilePool, firePoint, projectileIndex); // Cambia para usar la pool
                break;
            case 2:
                fireType = new TripleShot(projectilePool, firePoint, projectileIndex); // Cambia para usar la pool
                break;
            default:
                Debug.LogWarning("Shoot type missing");
                break;
        }
    }
    public void ResetHotFired()
    {
        timer = 0;
    }
}