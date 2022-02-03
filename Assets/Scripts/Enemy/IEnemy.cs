using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy //Allow to implement functions into many Objects.
{
    void TakeDamage();
    void PerformAttack();
}
