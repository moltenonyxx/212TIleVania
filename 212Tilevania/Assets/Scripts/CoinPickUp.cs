using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSFX;

    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !wasCollected)
        {
            AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);
            wasCollected = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
