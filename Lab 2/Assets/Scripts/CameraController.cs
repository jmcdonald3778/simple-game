using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; 
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position; //initial offset between camera and player
    }

    // Update is called once per frame
    void LateUpdate() // called after all Update functions have been called, good for camera follow scripts to ensure the player has moved first
    {
        transform.position = player.transform.position + offset; //camera follows player maintaining the initial offset
    }
}
