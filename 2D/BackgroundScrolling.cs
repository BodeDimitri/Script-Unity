using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float vel = 0.1f;
    public Renderer quad; 


    void Start()
    {
        
    }

  
    void Update()
    {
        Vector2 offset = new Vector2(vel * Time.deltaTime,0); //Vector 2 permite a mobilidade de dois vetores, em seguida e passado o parametro X e Y

        quad.material.mainTextureOffset += offset; //Altera o material principal do nosso quad e adiciona a variavel que permite a movimentação dele
    }
}