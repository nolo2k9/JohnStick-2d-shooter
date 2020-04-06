using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class settings : MonoBehaviour
{   //reference to AudioMixer
    public AudioMixer audioMixer;
    //Set volume level
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

    }//setVolume

}//settings
