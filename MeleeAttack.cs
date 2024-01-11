using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeAttack : EnemiesController //Quer dizer que esta herdando do EnemiesController
{
    public float AttackDelay = 2.5f; //Variavel que vai levar o tempo do Delay do ataque
    bool isAttacking = false; //Criada para evitar que os ataques sejam muito rapidos
    protected override void AttackPlayer() { //Override pois ela foi herdada do EnemiesController, tem de manter o retorno e o mesmo nível de proteção
        if (currentDistance <= AttackDistance && !isAttacking) { //Se o ataque tiver range e não estar atacando ele podera atacar denovo
            StartCoroutine(MelleAttackCoroutine()); //Usando a corotina                 //enemyAnimator.SetBool("attack", true); //Mudando a animação do inimigo para realizar o ataque
        }
        else {
            StopCoroutine(MelleAttackCoroutine()); //Para a corotina caso não esteja no range do ataque
        }
    }
    IEnumerator MelleAttackCoroutine() { //Corotina, basicamente leva um tempo para ser executada

        isAttacking = true;//Isso e colocado no inicio pois se for colocado depois do Yield você vai ter de esperar e a corrotina vai ser executada mais de uma vez, causando assim muito dano ao jogador
        float delayMultiplier = UnityEngine.Random.Range(1.0f,1.4f); //Cria uma aleatoriedade do tempo que leva para o inimigo atacar
        enemyAnimator.SetBool("Idle", true);//Animação Idle
        enemyAnimator.SetBool("Attack", true); //Faz o ataque
        yield return new WaitForSeconds(AttackDelay * delayMultiplier); // Delay junti da varuavel que randomiza um pouco o tempo de ataque
        player.GetComponent<PlayerController>().takeDamage(Damage); //Acessa o player>acessa o componente Script "PlayerController" e depois usa a função takeDamage(PlayerController) e usa a variavel Damage(EnemiesController)
        enemyAnimator.SetBool("Attack", false); //Desativa a animação
        enemyAnimator.SetBool("Idle", true); //Volta para o idle por um curto período
        yield return new WaitForSeconds(AttackDelay * delayMultiplier); //Delay
        isAttacking = false;
    }
}
