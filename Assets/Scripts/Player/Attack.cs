using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Sword _sword;
    public bool attacking;

    void Start()
    {
        attacking = false;
        // Lancer Idle.
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            _sword.PerformAttack();
        }
    }
}
