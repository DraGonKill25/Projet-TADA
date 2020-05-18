using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Vector3 offset;
    
    [Header("Variables")]
    public Transform player;
    [Space]
    [Header("Position")]
    public float camPosX;
    public float camPosY;
    public float camPosZ;
    [Space]
    [Header("Rotation")]
    public float camRotationX;
    public float camRotationY;
    public float camRotationZ;
    [Space]
    [Range(0f, 10f)]
    public float turnSpeed;
    private void Start()
    {
        print(player.position.z);
        print(camPosZ);
        print(player.position.z + camPosZ);
        print(offset.z);
        print(Vector3.Distance(player.position, offset));
        offset = new Vector3(player.position.x + camPosX, player.position.y + camPosY, player.position.z + camPosZ);
        transform.rotation = Quaternion.Euler(camRotationX, camRotationY, camRotationZ);
    }
    private void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}
