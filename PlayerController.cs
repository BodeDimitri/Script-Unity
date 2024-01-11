using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float currentHealth;
    float maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //Começar com a vida maxima
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
}
