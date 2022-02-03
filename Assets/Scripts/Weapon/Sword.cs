using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator _animator;

    public int Sdamage;

    void Start()
    {
        _animator = GetComponent<Animator>();
        Sdamage = 2;
    }

    void Update()
    {
        
    }

    public void PerformAttack()
    {
        _animator.SetTrigger("Base_Attack");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "chickenMob")
        {
            FindObjectOfType<AudioManager>().Play("SwordHit");

            col.GetComponent<IEnemy>().TakeDamage(); //In EnemyHealth.
        }
    }
}
