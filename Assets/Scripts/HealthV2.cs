using UnityEngine;

public class HealthV2 : MonoBehaviour
{
    public int maxHealth = 100;
    private int accumDamage = 0;
    public void TakeDamage(int damage)
    {
        accumDamage += damage;
        if (accumDamage >= maxHealth)
        {
            Destroy(gameObject);
        }
    }
}
