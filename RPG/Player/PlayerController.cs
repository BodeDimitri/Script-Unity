using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Runtime.Serialization;

public class PlayerController : MonoBehaviour
{
    public float currentHealth;
    float maxHealth = 100;
    public List<Transform> objectsInRange; //Lista de objetos, a lista vai se tratar de <Transform> posição do objeto
    MovePlayer moveplayer; //Nossa outra classe
    MixingCameraController mixingCameraController; 
    public float cdAttack = 3.0f; //Tempo para atacar, e o delay
    protected bool isOccupied; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //Começar com a vida maxima
        moveplayer = gameObject.GetComponent<MovePlayer>();
        mixingCameraController = GameObject.FindWithTag("MixingCam").GetComponent<MixingCameraController>(); //Quando for procurar por tag tem de usar o GameObject maíusculo, agora consegue alterar as variaveis do script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage) { //Função de levar dano
        currentHealth -= damage; //Desconta da vida atual a quantidade de dano, que e o parametro da função
        if (currentHealth < 0 ) { //Se a saude for negativa a zero, usado para evitar do personagem ficar com vida negativa
            currentHealth = 0;
        }
    }

    public void GetObjectsInRange(Vector3 mousePosition) //Metodo que vai lançar um raycast e vai retornar uma array com todos os coliders que foram encontrados    
    {
        foreach (Collider col in Physics.OverlapSphere(mousePosition, 3.5f)) { //Passa por cada elemento com collider, e criado uma esfera em volta de onde foi clicado para isso ser testado se for collider
            if (col.GetComponent<Interectable>() != null) { //Se atingir um collider que tenha um componente Interctable, no caso que seja diferente que nulo, e bom usar o null como verificação prossegue
                objectsInRange.Add(col.transform); //Adiciona a lista de objetos Interectable, acessa col em seguida o transform do mesmo
                if (objectsInRange.Contains(col.transform)) { //Se o objeto ja tiver sido adicionado a lista, nada vai acontecer
                Debug.Log("Ja esta na lista"); //Nada acontece alem da mensagem no terminal
                } else {
                    objectsInRange.Add(col.transform); //Se não foi adicionado vai ser adicionado pois ja passou pelas verificações e este não esta contido na lista
                }
            } else {
                continue; //Caso não tenha sido encontrado objetos ele apenas continua executando
            } 
        }

        if (objectsInRange.Count > 0)  //So vai interagir caso tenha um objeto para ser interagido
            interacting();
        
    }

    void interacting() { //Para interagir com o objeto
        if (moveplayer != null){ //
            moveplayer.setFocus(objectsInRange[0].position); //Nosso foco e o nosso objeto que foi passado pela lista e pegar a sua posição
        if (mixingCameraController != null) {
            mixingCameraController.target = objectsInRange[0]; //Target da mixing camo primeiro objeto da lista
            mixingCameraController.hasTarget = true;
        }
            foreach(Transform obj in objectsInRange) { //Itera cada objeto que foi adicionado 
                var objType = obj.gameObject.GetComponent<Interectable>().objectType; //Acessa o Script Interectable e depois a variavel objectType 

                switch (objType) {
                    case Interectable.objectTypes.Enemy: //Caso for inimigo
                        StartCoroutine(playerAttack()); //Começa a corotina do ataque
                        break;
                    case Interectable.objectTypes.Chest: //Caso for um bau
                        if (!isOccupied) { //Se não esta ocupado

                        }
                        break;
                    case Interectable.objectTypes.Item: //Caso for item

                        break;
                    case Interectable.objectTypes.Store: //Caso for loja

                        break;
                    case Interectable.objectTypes.Npc: //Caso for npc

                        break;
                    case Interectable.objectTypes.Gold: //Caso for gold

                        break;

                    default:

                        break;
                }
            
        }
    }
}
    protected virtual IEnumerator playerAttack() { //Para o Player não conseguir atacar enquanto ele já esta atacando
        yield return new WaitForSeconds(cdAttack); // Vai ser sobrescrita
    }
}
