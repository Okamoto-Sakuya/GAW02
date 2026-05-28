using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 10;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        Debug.Log("ダメージ受けた: " + damage + " / 残りHP: " + hp);

        if (hp <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}