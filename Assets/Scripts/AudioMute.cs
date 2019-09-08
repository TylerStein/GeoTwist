using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMute : MonoBehaviour
{
    public bool useInput = true;
    public string muteInput = "Mute";
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (useInput && Input.GetButtonDown(muteInput)) {
            toggleMute();
        }
    }

    public void toggleMute() {
        audioSource.mute = !audioSource.mute;
    }
}
