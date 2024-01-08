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
    protected GameObject player; //O gameobject do Player
    protected float currentDistance;
    private NavMeshAgent enemyAgent;
    protected Animator enemyAnimator;

    private void Awake() {
        currentHealth = Health; //Igualar a vida total a vida atual quando o monstro spawnar
    }
        // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player"); //Tag do player
        enemyAgent = gameObject.GetComponent<NavMeshAgent>(); //Procurar o NavMeshAgent do nosso inimigo
        enemyAnimator = gameObject.GetComponent<Animator>(); //Procurando o Animator da aranha para ser usado no ataque
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(transform.position, player.transform.position); //Metodo que mede a distancia entre dois pontos no mundo, a posição do nosso inimigo ate a posição do nosso player
        followPlayer();
        AttackPlayer();
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
        if (currentDistance <= enemyAgent.stoppingDistance) { //Usado para o inimigo rotacionar corrretamente quando chegar muito proximo do nosso personagem
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z); //Vector3 leva como parametro o X e o Z do nosso personagem e o Y do inimigo pois ele não vai mover o Y
            transform.LookAt(targetPosition); //Usado para fazer o personagem usar para determinado lugar, no caso isso foi definido na variavel anterior
        }
    }
}