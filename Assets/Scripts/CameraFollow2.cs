using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{

    private float speed = 200;
    public GameObject player;
    private Vector3 offset = new Vector3(0, 2, -3);


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
