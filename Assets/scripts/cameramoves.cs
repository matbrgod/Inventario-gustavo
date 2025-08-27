using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;       // The player the camera should follow
    public float followSpeed = 0.1f; // How smooth the camera follows

    void Update()
    {
        // Target position = player's X and Y, but keep camera's Z (so it stays at the same depth)
        Vector3 posToGo = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            transform.position.z
        );

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, posToGo, followSpeed);
    }
}

