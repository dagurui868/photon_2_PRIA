using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public float moveSpeed;
    public float rotationSpeed;
    void start{

        if (!GetComponent<PhotonView>().IsMine)
            Destroy(GetComponentInChildren<Camera>()) // Si no es el propio  componente destruye la camara.

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.down * rotationSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.up * rotationSpeed * Time.deltaTime);

        }
    }
}
