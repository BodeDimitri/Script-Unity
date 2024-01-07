using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesController : MonoBehaviour
{
    public float Health;
    private float currentHealth;
    public float Damage;
    public int Xp;
    public int MinGold;
    public int MaxGold;
    public float AttackDistance;
    public float FollowDistance;
    private GameObject player; //O gameobject do Player
    private float currentDistance;
    private NavMeshAgent enemyAgent;

    private void Awake() {
        currentHealth = Health; //Igualar a vida total a vida atual quando o monstro spawnar
    }
        // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player"); //Tag do player
        enemyAgent = gameObject.GetComponent<NavMeshAgent>(); //Procurar o NavMeshAgent do nosso inimigo
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(transform.position, player.transform.position); //Metodo que mede a distancia entre dois pontos no mundo, a posição do nosso inimigo ate a posição do nosso player
        followPlayer();
    }


    protected virtual void AttackPlayer() { //Permite ser acessado somente pelas classes filhas e o virtual permite ser sobrescrito pelas filhas

    }
    void takeDamage() {
        
    }

    void doDamage() {

    }
        private void OnDrawGizmos() { //Função para desenhar um gizmo
        Gizmos.color = Color.cyan; //Escolhe a cor magenta para o gizmo
        Gizmos.DrawWireSphere(transform.position, AttackDistance); //Range do ataque
        Gizmos.color = Color.magenta; //Escolhe a cor magenta para o gizmo
        Gizmos.DrawWireSphere(transform.position, FollowDistance); //Seguir o player
    }
    private void followPlayer() { //Função para seguir o player
        if (currentDistance < FollowDistance) { //Caso o monstro esteja no range de seguir
            enemyAgent.SetDestination(player.transform.position); //Posição do monstro alterada para fazer o caminho do Player
        }
    }
}