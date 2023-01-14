using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test : MonoBehaviour
{
    public TMP_Text inv;
    public TMP_Text commentary;
    public string[] pickupTags = {"glass", "paper", "plastic", "metal"};
    GameObject pickupObject1;
    GameObject pickupObject2;
    GameObject pickupObject3;
    GameObject pickupObject4;
    public PickupItem pickupItem;
    public AudioClip wrongBinSound;
    public AudioClip rightBinSound;
    private AudioSource audioSource;

    private void Start()
    {
        pickupObject1 = GameObject.FindGameObjectWithTag("glass");
        pickupObject2 = GameObject.FindGameObjectWithTag("paper");
        pickupObject3 = GameObject.FindGameObjectWithTag("plastic");
        pickupObject4 = GameObject.FindGameObjectWithTag("metal");
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("TrashbinP"))
        {
            if (pickupObject3 != null && !pickupObject3.activeSelf)
            {
                // An object with the specified tag is disabled
                Debug.Log("Plastic trash is destroyed.");
                inv.text = "Inventory: No Trash";
                pickupItem.holdingItem = false;
                audioSource.PlayOneShot(rightBinSound);
                Destroy(pickupObject3);
                StartCoroutine(ShowGoodJob());

            }
            else
            {
                audioSource.PlayOneShot(wrongBinSound);
                if (pickupObject3.activeSelf && pickupObject1.activeSelf && pickupObject4.activeSelf && pickupObject2.activeSelf)
                {
                    StartCoroutine(ShowEmpty());
                }
                else
                {
                    StartCoroutine(ShowBadJob());
                }
            }
        }
        if (collision.gameObject.CompareTag("TrashbinPa"))
        {
            if (pickupObject2 != null && !pickupObject2.activeSelf)
            {
                // An object with the specified tag is disabled
                Debug.Log("Paper trash is destroyed.");
                inv.text = "Inventory: No Trash";
                audioSource.PlayOneShot(rightBinSound);
                pickupItem.holdingItem = false;
                Destroy(pickupObject2);
                StartCoroutine(ShowGoodJob());
            }
            else
            {
                audioSource.PlayOneShot(wrongBinSound);
                if (pickupObject3.activeSelf && pickupObject1.activeSelf && pickupObject4.activeSelf && pickupObject2.activeSelf)
                {
                    StartCoroutine(ShowEmpty());
                }
                else
                {
                    StartCoroutine(ShowBadJob());
                }
            }
        }
        if (collision.gameObject.CompareTag("TrashbinG"))
        {
            if (pickupObject1 != null && !pickupObject1.activeSelf)
            {
                // An object with the specified tag is disabled
                Debug.Log("Glass trash is destroyed.");
                inv.text = "Inventory: No Trash";
                audioSource.PlayOneShot(rightBinSound);
                pickupItem.holdingItem = false;
                Destroy(pickupObject1);
                StartCoroutine(ShowGoodJob());
            }
            else
            {
                audioSource.PlayOneShot(wrongBinSound);
                if (pickupObject3.activeSelf && pickupObject1.activeSelf && pickupObject4.activeSelf && pickupObject2.activeSelf)
                {
                    StartCoroutine(ShowEmpty());
                }
                else
                {
                    StartCoroutine(ShowBadJob());
                }
            }
        }
        if (collision.gameObject.CompareTag("TrashbinM"))
        {
            if (pickupObject4 != null && !pickupObject4.activeSelf)
            {
                // An object with the specified tag is disabled
                Debug.Log("Metal trash is destroyed.");
                inv.text = "Inventory: No Trash";
                audioSource.PlayOneShot(rightBinSound);
                pickupItem.holdingItem = false;
                Destroy(pickupObject4);
                StartCoroutine(ShowGoodJob());
            }
            else
            {
                audioSource.PlayOneShot(wrongBinSound);
                if (pickupObject3.activeSelf && pickupObject1.activeSelf && pickupObject4.activeSelf && pickupObject2.activeSelf)
                {
                    StartCoroutine(ShowEmpty());
                }
                else
                {
                    StartCoroutine(ShowBadJob());
                }
            }
        }
    }
    IEnumerator ShowGoodJob()
    {
        commentary.text = "Good Job!";
        yield return new WaitForSeconds(2f);
        commentary.text = "Pick up the next trash item!";
    }
    IEnumerator ShowBadJob()
    {
        commentary.text = "Sorry, that's wrong!";
        yield return new WaitForSeconds(2f);
        commentary.text = "Go to the right trashbin!";
    }
    IEnumerator ShowEmpty()
    {
        commentary.text = "You didn't picked up anything!";
        yield return new WaitForSeconds(2f);
        commentary.text = "Pick up trash first!";
    }
}