using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SceneManager : MonoBehaviour
{
    public Transform positionOne, positionTwo;


    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)

        {

            PhotonNetwork.Instantiate("Player1", positionOne.position, positionOne.rotation);
        }    
        else 
        {

            PhotonNetwork.Instantiate("Player2", positionTwo.position, positionTwo.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
