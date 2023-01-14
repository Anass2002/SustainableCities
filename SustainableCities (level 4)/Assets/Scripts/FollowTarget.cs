using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject[] targets; // the target gameobjects to follow for each lane
    public float speed = 5f; // the speed at which the gameobject should follow the target
    public int lane = 2; // the current lane the gameobject is in
    public int numLanes = 4; // the total number of lanes
    public float laneWidth = 1f; // the width of each lane

    public GameObject congratulations; // the congratulations gameobject
    
    public GameObject backgroundMusic; // the gameobject that plays the background music

    void Update()
    {
        // get the target for the current lane
        GameObject target = targets[lane - 1];

        // move towards the target's position at the set speed
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        // check for input to change lanes
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lane > 1)
        {
            // move left into the next lane
            lane--;
            transform.position += Vector3.left * laneWidth;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && lane < numLanes)
        {
            // move right into the next lane
            lane++;
            transform.position += Vector3.right * laneWidth;
        }

        // stop moving if we've reached the destination
        if (transform.position == target.transform.position)
        {
            // deactivate the background music gameobject
            backgroundMusic.SetActive(false);

            // disable the audio source on this gameobject
            GetComponent<AudioSource>().enabled = false;

            // wait 1 second before setting the congratulations gameobject to active and playing the success sound
            StartCoroutine(ShowCongratulations());
        }
    }

    IEnumerator ShowCongratulations()
    {
        yield return new WaitForSeconds(1f);

        // set the congratulations gameobject to active
        congratulations.SetActive(true);

        // play the success sound
        

        // disable this script
        enabled = false;
    }
}
