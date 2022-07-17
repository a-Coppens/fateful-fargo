using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    //Audio
    public AudioSource source;
    public AudioClip clip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LMouseButton"))
        {
            source.PlayOneShot(clip);
            Debug.Log("Sound!");
        }
    }
}
