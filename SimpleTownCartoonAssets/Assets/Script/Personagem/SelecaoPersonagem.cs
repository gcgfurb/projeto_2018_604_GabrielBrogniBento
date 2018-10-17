using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SelecaoPersonagem : NetworkBehaviour {

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
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MudarPersonagem()
    {
        if(ePedestre == true)
        {
            habilitarCaminhao();
            desabilitarPedestre();
            ePedestre = false;
        }
        else
        {
            habilitarPedestre();
            desabilitarCaminhao();
            ePedestre = true;
        }
    }

    void habilitarPedestre()
    {
        pedestre.Invoke(true);
        habilitarControlePedestre();
    }

    void habilitarCaminhao()
    {
        caminhao.Invoke(true);
        habilitarControleCaminhao();
    }

    void desabilitarPedestre()
    {
        pedestre.Invoke(false);
        desabilitarControlePedestre();
    }

    void desabilitarCaminhao()
    {
        caminhao.Invoke(false);
        desabilitarControlePedestre();
    }

    void habilitarControlePedestre()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(false);

        compartilhadoPedestre.Invoke(true);

        if (isLocalPlayer)
            localPedestre.Invoke(true);
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

    void desabilitarControlePedestre()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(true);

        compartilhadoPedestre.Invoke(false);

        if (isLocalPlayer)
            localPedestre.Invoke(false);
        else
            remotoPedestre.Invoke(false);
    }

    void desabilitarControleCaminhao()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(true);

        compartilhadoCaminhao.Invoke(false);

        if (isLocalPlayer)
            localCaminhao.Invoke(false);
        else
            remotoCaminhao.Invoke(false);
    }
}
