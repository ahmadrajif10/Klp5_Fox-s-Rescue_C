using UnityEngine;

public class Kunci : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Rubah harus memiliki tag "Player"
        {
            if (KunciManager.instance != null)
            {
                KunciManager.instance.TambahKunci();
            }

            Destroy(gameObject); // hilangkan kunci ini
        }
    }
}

