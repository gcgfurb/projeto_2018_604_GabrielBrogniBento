using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.ThirdPerson;

public class SelecaoPersonagem : NetworkBehaviour {

    Camera desativarCamera;

    [SerializeField] ToggleEvent pedestre;
    [SerializeField] ToggleEvent caminhao;

    [SerializeField] ToggleEvent compartilhadoPedestre;
    [SerializeField] ToggleEvent localPedestre;
    [SerializeField] ToggleEvent remotoPedestre;

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
        pedestre.Invoke(true);
        habilitarControlePedestre();
        desativarCamera.GetComponent<Camera>().enabled = false;
        //desabilitarCaminhao();
    }

    void habilitarCaminhao()
    {
        caminhao.Invoke(true);
        habilitarControleCaminhao();
        desativarCamera.GetComponent<Camera>().enabled = false;
        //desabilitarPedestre();
    }

    /*void desabilitarPedestre()
    {
        pedestre.Invoke(false);
        desabilitarControlePedestre();
    }*/

    /*void desabilitarCaminhao()
    {
        caminhao.Invoke(false);
        desabilitarControleCaminhao();
    }*/

    void habilitarControlePedestre()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(false);

        compartilhadoPedestre.Invoke(true);

        if (isLocalPlayer) { 
            localPedestre.Invoke(true);
        }
        else
            remotoPedestre.Invoke(true);
    }

    void habilitarControleCaminhao()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(false);

        compartilhadoCaminhao.Invoke(true);

        if (isLocalPlayer)
            localCaminhao.Invoke(true);
        else
            remotoCaminhao.Invoke(true);
    }

    /*void desabilitarControlePedestre()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(true);

        compartilhadoPedestre.Invoke(false);

        if (isLocalPlayer)
            localPedestre.Invoke(false);
        else
            remotoPedestre.Invoke(false);
    }*/

    /*void desabilitarControleCaminhao()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(true);

        compartilhadoCaminhao.Invoke(false);

        if (isLocalPlayer)
            localCaminhao.Invoke(false);
        else
            remotoCaminhao.Invoke(false);
    }*/
}
