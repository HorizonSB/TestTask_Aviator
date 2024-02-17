using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int healAmount;
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PLAYER_TAG)
        {
            GameHandler.Instance.AddHealthPoint(healAmount);
            Destroy(gameObject);
        }
    }
}
