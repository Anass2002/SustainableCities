using UnityEngine;

public class RotateAround : MonoBehaviour
{
    // The speed at which the game object will rotate
    public float rotateSpeed = -50.0f;

    void Update()
    {
        // Rotate the game object around a diagonal axis inclined at 45 degrees to the x-axis and y-axis
        transform.Rotate(new Vector3(1, 1, 1) * Time.deltaTime * rotateSpeed);
    }
}
