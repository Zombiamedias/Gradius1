
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    private ProjectilePool pool;
    private HealthSystem hpSystem;
    public int projectileType;
    private bool hasCollided = false;
    public  Coroutine returnCoroutine;
    // Update is called once per frame
    private void Start()
    {
        pool = FindAnyObjectByType<ProjectilePool>();
        hpSystem = GetComponent<HealthSystem>();
    }
    void Update()
    {
        Move();
        if (transform.position.x >= 9)
        {
            ReturnToPool();
        }
    }
    private void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // continue movement
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            hasCollided = true;
            hpSystem.TakeDamage(damage);
            ReturnToPool();
        }
    }
    public void ReturnToPool()
    {
        if (returnCoroutine != null)
        {
            StopCoroutine(returnCoroutine);
            returnCoroutine = null;
        }
        pool.ReturnProjectile(gameObject, projectileType);
    }
    
}
