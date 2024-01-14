using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelleAttack : PlayerController //Herdando de player controller
{
    bool isAttacking = false; //Começa sem atacar 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override IEnumerator playerAttack() { //Pertencente ao PlayerController
        isAttacking = true; //Quando atacar
        base.isOccupied = true; //Herdando de Player Controller com o base, a variavel vai ser mudada

        if (isAttacking != false) { //O que vai acontecer quando atacat

        }
        yield return new WaitForSeconds(cdAttack); //Cd do ataque
        isAttacking = false; //Pode atacar novamente
        base.isOccupied = false; //Não esta mais atacado pois ja parou de atacar
        StopCoroutine(playerAttack()); //Se auto para, e bom fazer isso para ter certeza que parou
    }
}
