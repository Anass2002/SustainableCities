using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFromAToB : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 10f;
    private bool collision = false;
    //IEnumerator is een manier in .NET om acties te herhalen, met coroutine
    IEnumerator Start()
    {
        
        while (true)
        {
            do yield return null; while (MoveTowards(pointA));
            do yield return null; while (MoveTowards(pointB));
        }
    }
    //Wissellen van richting.
    bool MoveTowards(Transform target)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);
        if (collision)
        {
            return false;
        }
        return transform.position != target.position;
    }

    
}
