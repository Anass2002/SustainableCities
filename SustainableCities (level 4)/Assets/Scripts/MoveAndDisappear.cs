using UnityEngine;

public class MoveAndDisappear : MonoBehaviour
{
    public Transform destination; // The target the object should move to
    public float speed; // The speed at which the object should move

    void Update()
    {
        // Calculate the distance between the object and its destination
        float distance = Vector3.Distance(transform.position, destination.position);

        // If the object is close enough to its destination, make it disappear
        if (distance < 0.1f)
        {
            Destroy(gameObject);
        }
        // Otherwise, move the object towards its destination
        else
        {
            // Rotate the object towards its destination
            Quaternion targetRotation = Quaternion.LookRotation(destination.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f);

            // Move the object towards its destination
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        }
    }
}
