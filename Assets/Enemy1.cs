using UnityEngine;

public abstract class Enemy1:EnemyBase
{
    public float moveRange = 5.0f;
    private Vector3 startPosition;
    private float moveDirection = 1.0f;

    protected override void Start()
    {
        base.Start();
        startPosition = transform.position;
    }
    private void Update()
    {
        if (!isActive) return;
//----------------------------------------------------------------
        float mveDistance = moveDirection * moveSpeed * Time.deltaTime;

        transform.Translate(moveDirection, 0f, 0f);

        if(Mathf.Abs(transform.position.x - startPosition.x) >= moveRange)
        {
            moveDirection *= -1;
        }
    
    }
}
