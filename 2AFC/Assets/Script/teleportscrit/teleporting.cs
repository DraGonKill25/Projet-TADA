using UnityEngine;

public class teleporting : MonoBehaviour
{
    public Transform TeleportTarget;

    void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        player.transform.position = TeleportTarget.transform.position;
    }
}
