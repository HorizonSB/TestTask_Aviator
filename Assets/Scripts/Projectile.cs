using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private const string ENEMY_TAG = "Enemy";
    private const string PLAYER_TAG = "Player";


    private enum ProjectileType
    {
        ally,
        enemy
    }

    [SerializeField] private ProjectileType projectileType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ENEMY_TAG && projectileType == ProjectileType.ally)
        {
            GameHandler.Instance.AddScorePoint();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == PLAYER_TAG && projectileType == ProjectileType.enemy)
        {
            GameHandler.Instance.MinusHealthPoint(1);
            Destroy(gameObject);
        }


    }
}
