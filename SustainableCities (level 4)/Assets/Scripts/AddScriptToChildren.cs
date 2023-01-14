using UnityEngine;

public class AddScriptToChildren : MonoBehaviour
{
    public MonoBehaviour scriptToAdd;

    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "FL" || child.name == "FR" || child.name == "BR" || child.name == "BL")
            {
                child.gameObject.AddComponent(scriptToAdd.GetType());
            }
        }
    }
}
