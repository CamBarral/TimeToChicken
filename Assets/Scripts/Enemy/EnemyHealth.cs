using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IEnemy
{
    public Sword sword;
    public float maxHealth;


    [SerializeField] private GameObject _chickenLootPrefab;

    private Vector3 _spawnPoint;
    private float _currentHealth;

    void Start()
    {
        _currentHealth = maxHealth;
    }

    void Update()
    {
        GameObject spawnPoint = this.gameObject;
        _spawnPoint = spawnPoint.transform.position;
    }

    public void PerformAttack()
    {

    }

    public void TakeDamage()
    {
        _currentHealth -= sword.Sdamage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Loot a chickenLoot.
        _chickenLootPrefab = Instantiate(_chickenLootPrefab, _spawnPoint + new Vector3 (0, 1.5f, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}