using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveCharacter : MonoBehaviour
{

    public float velSpeed = 1.5f;
    public float turnSpeed = 0.2f;
    public new Light2D light;
    void Start()
    {
        light = gameObject.GetComponentInChildren<Light2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        running();
        turningAndLightining();

        float H = Input.GetAxis("Horizontal"); //Controle Horizontal W S
        float V = Input.GetAxis("Vertical"); // Controle Vertical A D
        transform.Translate(new Vector3(H * Time.deltaTime * velSpeed ,V * Time.deltaTime * velSpeed,0));


    }
    public void running() {
        if(Input.GetKey(KeyCode.LeftControl)) {   
            velSpeed = 3.3f;
            light.falloffIntensity = 0.8f;
        } else {
            velSpeed = 1.0f;
            light.falloffIntensity = 0.5f;
        }
    }
    public void turningAndLightining() {
    if(Input.GetKey(KeyCode.Q)) {
        transform.Rotate(0,0,turnSpeed);
        light.intensity = 0.5f;
     }
    else if(Input.GetKey(KeyCode.E)) {
        transform.Rotate(0,0,-turnSpeed);
        light.intensity = 0.5f;
     } else {
        light.intensity = 3f;
     }
    }

}