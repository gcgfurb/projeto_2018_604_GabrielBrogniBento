using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SelecaoPersonagem : NetworkBehaviour {

    //Camera do ambiente
    Camera desativarCamera;

    //Mesh dos personagens
    [SerializeField] ToggleEvent pedestre;
    [SerializeField] ToggleEvent caminhao;

    //Componete do pedestre
    [SerializeField] ToggleEvent compartilhadoPedestre;
    [SerializeField] ToggleEvent localPedestre;
    [SerializeField] ToggleEvent remotoPedestre;

    //Componte do caminhao
    [SerializeField] ToggleEvent compartilhadoCaminhao;
    [SerializeField] ToggleEvent localCaminhao;
    [SerializeField] ToggleEvent remotoCaminhao;

    GameObject mainCamera;

    public bool ePedestre = false;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main.gameObject;
        desativarCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        selecionaPersonagem();

    }
    
    //Metodo principal, para ativar os personagens
    public void selecionaPersonagem()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if(ePedestre == false)
        {
            habilitarCaminhao();
        }
        else
        {
            habilitarPedestre();
        }
    }

    //Quando aperta em um botao troca o estado da variavel
    public void MudarPersonagem()
    {
        if(ePedestre == true)
        {
            ePedestre = false;
            print("Caminhao");
        }
        else
        {
            ePedestre = true;
            print("Pedestre");
        }
    }

    void habilitarPedestre()
    {
        //Ativa a mesh do pedestre
        pedestre.Invoke(true);

        //Desativa as cameras dos outros personagens que nao sao os jogadores locais
        if (isLocalPlayer)
            mainCamera.SetActive(false);

        //Ativa o que todos os personagens possuem em comum
        compartilhadoPedestre.Invoke(true);

        if (isLocalPlayer)
        {
            //Ativa o que o jogador local possui
            localPedestre.Invoke(true);
        }
        else
            //Ativa o que os jogadores remotos possuem
            remotoPedestre.Invoke(true);

        //Desativa a camera do ambiente
        desativarCamera.GetComponent<Camera>().enabled = false;
    }

    void habilitarCaminhao()
    {
        //Ativa a mesh do caminhao
        caminhao.Invoke(true);

        //Desativa as cameras dos outros personagens que nao sao os jogadores locais
        if (isLocalPlayer)
            mainCamera.SetActive(false);

        //Ativa o que todos os personagens possuem em comum
        compartilhadoCaminhao.Invoke(true);

        if (isLocalPlayer)
            //Ativa o que o jogador local possui
            localCaminhao.Invoke(true);
        else
            //Ativa o que os jogadores remotos possuem
            remotoCaminhao.Invoke(true);

        //Desativa a camera do ambiente
        desativarCamera.GetComponent<Camera>().enabled = false;
    }
}
