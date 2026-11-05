using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] AudioClip enemyPointsSFX;

    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] int pointsforEnemyKill = 50;
    float xSpeed;
    Rigidbody2D bulletRb;

    PlayerMovement player;

    
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        bulletRb.linearVelocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            FindFirstObjectByType<GameSession>().AddToScore(pointsforEnemyKill);
            AudioSource.PlayClipAtPoint(enemyPointsSFX, transform.position);
        }
        Destroy(gameObject);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 1f);
    }
}
