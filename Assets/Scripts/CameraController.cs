using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 myPosition;

    // Start is called before the first frame update
    void Start()
    {
        myPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            new Vector3(myPosition.x, player.position.y + 3, myPosition.z);
    }   
}
