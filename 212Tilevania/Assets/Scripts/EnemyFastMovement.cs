using UnityEngine;

public class EnemyFastMovement : MonoBehaviour
{
    [SerializeField] float moveSpeedFast = 3f;
    Rigidbody2D EnemyFastBody;
    void Start()
    {
        EnemyFastBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyFastBody.linearVelocity = new Vector2(moveSpeedFast, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeedFast = -moveSpeedFast;
        FlipFace();
    }

    void FlipFace()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(EnemyFastBody.linearVelocity.x)), 1f);
    }
}
