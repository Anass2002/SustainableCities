using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupItem : MonoBehaviour
{
    public float pickupRange = 2f;
    public LayerMask pickupLayer;
    public AudioClip pickupSound;
    public string[] pickupTags;
    public string[] trashBinTags;
    public TextMeshProUGUI itemNameText;

    private AudioSource audioSource;
    private GameObject currentObject;
    public bool holdingItem = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Pickup());
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, pickupLayer))
        {
            foreach (string tag in pickupTags)
            {
                if (hit.collider.tag == tag && !holdingItem)
                {
                    currentObject = hit.collider.gameObject;
                }
            }
        }
        else
        {
            currentObject = null;
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (currentObject == null)
        {
            Debug.Log("No trash found!");
            return;
        }
        foreach (string trashBinTag in trashBinTags)
        {
            if (collision.gameObject.tag == trashBinTag)
            {
                switch (currentObject.tag)
                {
                    case "paper":
                        if (trashBinTag == "TrashbinPa")
                        {
                            Debug.Log("paper in vuilbak");
                            audioSource.PlayOneShot(pickupSound);
                            
                            itemNameText.text = "";
                            holdingItem = false;
                        }
                        break;
                    case "glass":
                        if (trashBinTag == "TrashbinG")
                        {
                            Debug.Log("glass in vuilbak");
                            audioSource.PlayOneShot(pickupSound);
                            Destroy(currentObject);
                            itemNameText.text = "";
                            holdingItem = false;
                        }
                        break;
                    case "metal":
                        if (trashBinTag == "TrashbinM")
                        {
                            Debug.Log("metal in vuilbak");
                            audioSource.PlayOneShot(pickupSound);
                            Destroy(currentObject);
                            itemNameText.text = "";
                            holdingItem = false;
                        }
                        break;
                    case "plastic":
                        if (trashBinTag == "TrashbinP")
                        {
                            Debug.Log("plastic in vuilbak");
                            audioSource.PlayOneShot(pickupSound);
                            Destroy(currentObject);
                            itemNameText.text = "";
                            holdingItem = false;
                        }
                        break;
                    default:
                        audioSource.PlayOneShot(wrongBinSound);
                        break;
                }
                break;
            }
        }
    }*/

    IEnumerator Pickup()
    {
        if (currentObject != null)
        {
            Debug.Log("Object picked up");
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(pickupSound);
            currentObject.SetActive(false);
            itemNameText.text = "Inventory: " + currentObject.name;
            holdingItem = true;
        }
    }

}