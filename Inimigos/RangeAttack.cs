using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : EnemiesController
{
    protected override void AttackPlayer() { //Override pois ela foi herdada do EnemiesController, tem de manter o retorno e o mesmo nível de proteção
        print("ranged attack");
    }
}
