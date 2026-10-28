using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D EnemyBody;
    void Start()
    {
        EnemyBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyBody.linearVelocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipFace();
    }

    void FlipFace()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(EnemyBody.linearVelocity.x)), 1f);
    }
}
