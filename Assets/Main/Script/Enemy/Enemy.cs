using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;

    public Transform player;
    public float moveSpeed = 3f;

    public float attackRange = 1.5f;
    public int damage = 1;
    public float attackCooldown = 1f;

    private float attackTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            // ’Ç‚¢‚©‚¯‚é
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
        else
        {
            // UŒ‚
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                Attack();
                attackTimer = 0f;
            }
        }
    }

    void Attack()
    {
        Debug.Log("Enemy Attack");

        PlayerHealth ph = player.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}