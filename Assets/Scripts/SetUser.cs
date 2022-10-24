using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SetUser : MonoBehaviour
{

    int indexAvatar;
    // Panles  del Interfaz de Usuario
    //public GameObject panelName;
    public GameObject panelSetUser;
    public GameObject panelLobby;
    public GameObject panelRoom;

    public GameObject[] listAvatars;
    
    public TMP_Text textError;
    // Start is called before the first frame update
    void Start()
    {   
        //panelName.SetActive(false);
        panelLobby.SetActive(false);
        panelRoom.SetActive(false);
        panelSetUser.SetActive(true);

        //Indice para seleccionar el avatar en cada momento.
        indexAvatar = 0;

        inicializaAvatars();

    }

    private void inicializaAvatars()
    {
        foreach (GameObject avatar in listAvatars)
        {

            avatar.SetActive(false);

        }

        if (listAvatars[0])
            
            listAvatars[0].SetActive(true);

    }
    
    // Bot?n de conexi?n al servidor cuandose pulsa  enter.
    public void BtnPhotonServerConnect() 
    {
        if (!PhotonNetwork.IsConnected)
        {
            
            if (string.IsNullOrEmpty(PhotonNetwork.NickName))
            {
                textError.text = "Introduce primero tu nombre de avatar...";
            }
          else
            {
               
                PhotonNetwork.ConnectUsingSettings();
             
                
                panelLobby.SetActive(true); // Se carga el panel
                panelSetUser.SetActive(false); // Se apaga el panel de usuario
                
                PlayerPrefs.SetInt("AvatarIndex", indexAvatar); //Obtenemos el indice del Avatar y lo guardamos
                Debug.Log("Hemos guardado el nombre deljugador: " + PhotonNetwork.NickName + " junto con su indice " +
                        PlayerPrefs.GetInt("AvatarIndex") + "."); //Sacamos por log.

            }
        }
     }

    //Introduduccir nombre del user.

   
    //Bot?n Izquierdo
    public  void MoveLeft()
    {
        //Desactivo el avatar actual.
        listAvatars[indexAvatar].SetActive(false);

        //Decremento del ?ndice:
        indexAvatar--;
        
        //Si el  anteriorerauel  primer me he  salido del rango, y paaso a seccionar el ?ltimo.
        if (indexAvatar < 0)

            indexAvatar = listAvatars.Length - 1;
        
        listAvatars[indexAvatar].SetActive(true);

    }


    //Botón Derecho.
    public void MoveRight()
    {
        //Desactivo el avatar actual.
        listAvatars[indexAvatar].SetActive(false);

        //Decremento del ?ndice:
        indexAvatar++;

        //Si el  anterior era el  primer me he  salido del rango, y paso a seccionar el ?ltimo.
        if (indexAvatar >= listAvatars.Length)

            indexAvatar = 0;

        listAvatars[indexAvatar].SetActive(true);

    }


}
