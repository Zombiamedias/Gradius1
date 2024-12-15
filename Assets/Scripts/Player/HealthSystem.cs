using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth =3;
    private int currentHealth;
    private bool canTakeDamage = true;
    
    private void Start() {
        currentHealth = maxHealth;
    }
    public void TakeDamage (int damage){
        if (canTakeDamage)
        {
            currentHealth-= damage;
        }
    }
}
