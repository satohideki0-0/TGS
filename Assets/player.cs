using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public GameObject bulletPrefab;
    public Transform firePoint; // 弾の発射位置


    public GameObject specialBall;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animator;
    private bool canMove = true; // プレイヤーが動けるかどうかのフラグ

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Animator を取得
    }

    private void Update()
    {
        if (canMove)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Z)) // Zで弾を発射
            {
                Fire();
            }
        }
        else
        {
            // アニメーションが終了するまで待機
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("SpecialAnimation") &&
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                canMove = true; // アニメーションが終了したらプレイヤーが動けるようになる
            }
        }
    }

    private void Move()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.Normalize();
        rb.velocity = new Vector2(movementInput.x * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // アニメーション終了後にプレイヤーの操作を無効化するための関数
    public void DisableMovement()
    {
        canMove = false;
    }
    public void EnableMovement()
    {
        canMove = true; // プレイヤーが動けるようにする
    }

    public void Destroy()
    {
        Destroy(specialBall.gameObject);
    }
}
