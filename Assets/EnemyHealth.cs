using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static int LivingEnemyCount;

    private void Awake() => LivingEnemyCount++;
    public GameObject explosionPrefab;
    public int defaultHealthPoint;
    private int healthPoint;

    private void Start() => healthPoint = defaultHealthPoint;

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;
        if (healthPoint <= 0) 
        { Die(); }
    }

    protected virtual void Die()
    {
        LivingEnemyCount--;
        var explosion = Instantiate(explosionPrefab, transform.position,
        transform.rotation);
        Destroy(explosion, 1);
        Destroy(gameObject);
    }
}
