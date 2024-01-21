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
    public void takeDamage(float amount) { //Amount e a vida que ela vai perder
        currentHealth -= amount; //Tira a vida baseado no dano que vai sofrer
        currentHealth = Mathf.Clamp(currentHealth, 0, Health); //Impedi que o HP do monstro fique negativo
        if (currentHealth <= 0) { //Caso esteja abaixo de zero
            enemyAnimator.SetBool("Death", true); //Vai fazer a animação de morte
            LevelSystem.Instance.SetExperience((double)Xp); //Isso e usado para mandar a informação para o (Level System) que queremos aumentar o xp baseado no Xp que o monstro dropa
            Invoke("destroyEnemy", 2.0f); //Metodo invoke faz algo daqui alguns segundos, aceita como parametro o metodo e em seguida o tempo
        }
    }

    private void destroyEnemy() { //Metodo usado para destruir um objeto/player/monstro
        Destroy(gameObject); //Destroy e usado para destruir algo e leva como parametro o que vai ser destruido
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