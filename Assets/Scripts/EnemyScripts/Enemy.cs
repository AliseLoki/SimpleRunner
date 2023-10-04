using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();

        if (collision.TryGetComponent(out Player player))
        {
            player.GetDamage(_damage );
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
