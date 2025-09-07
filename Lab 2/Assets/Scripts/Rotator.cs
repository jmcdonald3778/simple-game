using UnityEngine;

public class Rotator : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); // deltatime makes rotation frame rate independent, its the difference in time between current and last frame
    }
}
