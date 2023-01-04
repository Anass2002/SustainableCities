using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeLights : MonoBehaviour
{
    [SerializeField] Renderer brakelights1;
    [SerializeField] Renderer brakelights2;
    [SerializeField] Material brakelightsON;
    [SerializeField] Material brakelightsOFF;

    

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            brakelights1.material = brakelightsON;
            brakelights2.material = brakelightsON;
        }
        else
        {
            brakelights1.material = brakelightsOFF;
            brakelights2.material = brakelightsOFF;
        }
    }
}
