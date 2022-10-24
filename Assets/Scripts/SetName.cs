using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


public class SetName : MonoBehaviour

{
    public GameObject panelName;
    public GameObject panelSetUser;
    public GameObject panelLobby;
    public GameObject panelRoom;
    public TMP_Text textError;
    void Start()
    {   
        panelName.SetActive(true);
        panelLobby.SetActive(false);
        panelRoom.SetActive(false);
        panelSetUser.SetActive(false);

        
        }
        
    public void SetNamePlayer(string namePlayer) { 
        
        if (!(string.IsNullOrEmpty(namePlayer)))
        {

            PhotonNetwork.NickName = namePlayer;

        }
        else
        {
            textError.text = "Introduce primero tu nombre de avatar...";  
        }
     
    }
    // Botón de conexión al servidor cuandose pulsa  enter.
    public void BtnNickNameCompleted() 
    {
        if (!PhotonNetwork.IsConnected)
        {
            
            if (string.IsNullOrEmpty(PhotonNetwork.NickName))
            {
                textError.text = "Introduce primero tu nombre de avatar...";
                Start();
            }
            else
            {
               
                PhotonNetwork.ConnectUsingSettings();
             
                
                panelName.SetActive(false);  // Se apaga el panel de usuario
                panelSetUser.SetActive(true); // Se carga el panel
                
                   
                Debug.Log("Hemos guardado el nombre deljugador: " + PhotonNetwork.NickName 
                + "."); //Sacamos por log.

            }
        }
    }


    
}
