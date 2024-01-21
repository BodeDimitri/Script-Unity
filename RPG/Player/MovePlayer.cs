using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    NavMeshAgent agent;
    Animator playerAnimator;
    [SerializeField] //Campo que e visto e pode ser alterado no inspector mas não pode ser acessado de outras classes
    float runSpeed; //Velocidade de corrida do nosso personagem
    [SerializeField]
    float walkSpeed; //Velocidade média
    PlayerController playercontroller;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();    //Atribuy valor ao agent, que e o nosso personagem
        playerAnimator = gameObject.GetComponentInChildren<Animator>(); 
        playercontroller = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {   //Detectar quando apertar o botão esquerdo
            RaycastHit hit;     //Sensor que detecta o que tem em volta, e como se um raio tivesse sido lançado para dectar algo, e o que permite usarmos o .point

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 80)){       //Movimento, levando em conta onde o mouse clicou e o Raycast
                agent.destination = hit.point;      //A posição do seu personagem vai ser ate onde ele vai //point e onde o rario atingiu o collider
            } 
        }

        if(Input.GetMouseButtonDown(1)) {   //Detectar quando apertar o botão direito, metodo usado para interagir com itens
            RaycastHit hit;     

            playercontroller.objectsInRange.Clear(); //Limpa a lista antes do click para evitar que junte objetos

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 80)){       //Movimento, levando em conta onde o mouse clicou e o Raycast mas esse e usado para interagir com intens
                if (playercontroller != null) { //checa se playercontroller não e nulo, usado para evitar que o player tente pegar qualquer coisa, evitando possível erro 
                    playercontroller.GetObjectsInRange(hit.point); //
                    Debug.Log("Hit");
                }
            } 
        }

        if (Input.GetKey(KeyCode.LeftShift)) {//Botão para correr
            agent.speed = runSpeed; // Corre na velocidade que foi setada dentro do inspetor
        } else {
            agent.speed = walkSpeed; //Anda na velocidade que foi setada dentro do inspetor
        }

        if (agent.velocity.magnitude > 0) {//Velocity retorna velocidade em Vector3, de todos os 3 eixos //Se a velocidade do nosso personagem for maior que zero
            playerAnimator.SetFloat("Velocity", agent.velocity.magnitude / runSpeed); //Mudando a "Velocity" no Animator e em seguida fazendo o calculo para chegar a ela
    }
    }
    
    public void setFocus(Vector3 focusTarget) { //Segue o que foi passado como target
        agent.destination = focusTarget; // O player vai se movimentar ate o objeto em questão
    }

}
