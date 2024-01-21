using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private double currentExperience;
    private double neededExperience;
    private double currentLevel;
    //Esse singleton vai facilitar a troca de informações do LevelSystem para o EnemiesController que no caso usamos o SetExperience()
#region singleton

    public static LevelSystem Instance; //Boa pratica ser chamada de Instance

    private void Awake() { // Lembrando que para você precisa digitar: <Classe>.Instance.<Metodo> ou <Classe>.<Variavel>
        if (Instance == null) {// So pode existir um, se existir outro ele sera destroi
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    
    #endregion singleton
    
    public void SetExperience(double amaount) { //Metodo para ganhar xp
        currentExperience += amaount; // Pega o xp atual e aumenta com a quantidade que vai ser passada como parametro no metodo
        LevelUp();
    }

    private void LevelUp() { //Metodo para upar de nivel
        neededExperience = 50.0 * (Math.Pow(1.5, currentLevel - 1)); //Como a quantidade de xp e escalavel foi utilizado um sistema de progressão geométrica para aumentar ele baseado no nível do jogador
        if (currentExperience >= neededExperience) { //Se o XP ja ter passado ou ter atingido limite
            currentLevel += 1; //Upa um nivel
            currentExperience = currentExperience - neededExperience; //Permite que não perca o XP excedente e ele vai para o proxímo nível
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
