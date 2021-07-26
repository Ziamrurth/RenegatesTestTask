using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 camOffset;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + camOffset;
    }
}
