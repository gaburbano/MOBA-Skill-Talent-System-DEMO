using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Replace this code with your own death logic (e.g. play death animation, remove object from game, etc.)
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject);
    }
}