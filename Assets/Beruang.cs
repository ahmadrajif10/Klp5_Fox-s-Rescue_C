using UnityEngine;

public class Beruang : MonoBehaviour
{
    public int maxHits = 3;
    private int currentHits = 0;

    public void TakeHit()
    {
        currentHits++;

        if (currentHits >= maxHits)
        {
            Die();
        }
    }

    void Die()
    {
        // Bisa diganti dengan animasi mati jika mau
        Destroy(gameObject);
    }
}
