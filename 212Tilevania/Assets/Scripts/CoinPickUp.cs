using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsforCoinPickup = 100;

    bool wasCollected = false;

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !wasCollected)
        {
            AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);
            FindFirstObjectByType<GameSession>().AddToScore(pointsforCoinPickup);
            wasCollected = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
