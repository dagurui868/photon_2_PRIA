using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class ConnectCtrl : MonoBehaviourPunCallbacks
{
    // Paneles
    public GameObject panelLobby;
    public GameObject panelRoom;


    // Textos informativos
    public TMP_Text welcomeText;
    public TMP_Text infoText;

    // Variables 
    private bool isLoading;


    //Evento  que se  dispara cuando estamosconectados  a Photon.
    
    public override void OnConnectedToMaster() {

        Debug.Log("Conectado a Photon.");
        panelLobby.SetActive(false);
        panelRoom.SetActive(true);
        welcomeText.text = "Bienvenido/a " + PhotonNetwork.NickName + "!";
    
    }

    // Warning para desconexion.
    public override void OnDisconnected(DisconnectCause cause)
    {
        //base.OnDisconnected(cause); // COn este se llama al padre.
        
        Debug.LogError("Desconectado del servidor Photon.");

    }

    // M�todo de uni�n da sala al azar.

    public void UnirseSalaAlAzar()
    {
        PhotonNetwork.JoinRandomRoom();
        //Debug.Log("1");
    }

    // Contorlo cuando   falla la uni�in a la salaal azr y creo una con un nombre  concreto

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("No se pudo unir a la sala al azar. Mensaje:" + message);

        // Creamos la sala  y nos unimos.
        CrearUnirseALaSala();
    }

    private void CrearUnirseALaSala()
    {
      
        RoomOptions options = new RoomOptions() { MaxPlayers = 4, IsVisible = true};

        /*
         opciones
            - MaxPlayers: m�x n�mero de jugadores.
            - IsVisible : visibilidad de la sala.
         
         */
        
        PhotonNetwork.JoinOrCreateRoom("Sala creada",  options,TypedLobby.Default);
        
    }

    public override void OnJoinedRoom()
    {
      
        Debug.Log("Conectado a la sala " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Hay " + PhotonNetwork.CurrentRoom.PlayerCount + " jugador(es).");
     
        infoText.text = "Te uniste a la sala " + PhotonNetwork.CurrentRoom.Name + " con " + PhotonNetwork.CurrentRoom.PlayerCount + " jugador(es)."; 
}

    private void Update()
    {

        if (!isLoading && PhotonNetwork.IsMasterClient && PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            Debug.Log("Entrando en el nivel 1.");
            isLoading = true;
            PhotonNetwork.LoadLevel(1);

        }
    }
}
