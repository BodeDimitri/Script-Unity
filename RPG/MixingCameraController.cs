using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class MixingCameraController : MonoBehaviour
{
    private CinemachineMixingCamera mixCam;
    public CinemachineVirtualCamera vCam; //Virtual cam
    private bool isFirstPerson; //Para saber se esta em primeira pessoa
    public bool hasTarget; 
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        mixCam = GetComponent<CinemachineMixingCamera>();  //Variavel que reporesenta a Mixingcamera
        hasTarget = false;
        target = transform; //Se não der um parametro vai ser o nosso proprio transform, posição
        vCam.m_LookAt = target;
    }

    // Update is called once per frame
    void Update()
    {
        //mixCam.m_Weight0 += Input.GetAxis("Mouse ScrollWheel"); //mixCam.m e uma maneira de acessar as cameras filhas, seguindo ordem em que foram colocadas // GetAxis pega o input do seu Scroll quanto mais scrolla mais valor
        //mixCam.m_Weight0 = Mathf.Clamp(mixCam.m_Weight0, 0, 0.3f); //O valor vai ser usado para fazer a troca entre as cameras, metodo Clamp define um valor maxímo e um valor minimo(0 e 1) para o mixCamWeight0 baseado no input anterior

        //mixCam.m_Weight1 -= Input.GetAxis("Mouse ScrollWheel"); //Mesma coisa do anterior porem e usado para a camera em 3 pessoa
        //mixCam.m_Weight1 = Mathf.Clamp(mixCam.m_Weight1, 0, 0.3f);    
        checkFirstPerson();
        if (hasTarget) {
            interactingWithTarget();
        }
    }
    private void checkFirstPerson() {
        if (Input.GetKeyDown(KeyCode.V) && !hasTarget) { //Quando apertar o botão V e não ter um target
            if (isFirstPerson) { //Checa utilizando uma variavel booleana se esta em primeira pessoa, caso estiver vai usar primeira pessoa, caso não vai para a terceira pessoa
                mixCam.m_Weight0 = 0.3f; //Usando primeira pessoa
                mixCam.m_Weight1 = 0;
                mixCam.m_Weight2 = 0; //Tem de ser zerada
            } else {
                mixCam.m_Weight0 = 0;
                mixCam.m_Weight1 = 0.3f;//Usando terceira pessoa
                mixCam.m_Weight2 = 0; //Tem de ser zerada
            }
            isFirstPerson = !isFirstPerson; //Vai inverter o valor indepedente do resultado permitindo um vai e volta entre as cameras 
        }    
    }
        public void interactingWithTarget(){
            mixCam.m_Weight0 = 0; //Zera as cameras pois essa vai ser a camera principal 
            mixCam.m_Weight1 = 0;
            mixCam.m_Weight2 = 0.3f; //Da foco para nossa camera target

            vCam.m_LookAt = target; //A virtual camera vai olhar para target 
            hasTarget = false; //Desativando no final
            
    }
}
