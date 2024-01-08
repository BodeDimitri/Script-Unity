using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();    //Atribuy valor ao agent, que e o nosso personagem
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {   //Detectar quando apertar o botão esquerdo
            RaycastHit hit;     //Sensor que detecta o que tem em volta

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 80)){       //Movimento, levando em conta onde o mouse clicou e o Raycast
                agent.destination = hit.point;      //A posição do seu personagem vai ser ate onde ele vai
            } 
        }
    }
}
