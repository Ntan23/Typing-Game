using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }

        foreach(Sounds currsound in sounds)
        {
            currsound.audioSource =  gameObject.AddComponent<AudioSource>();

            currsound.audioSource.clip = currsound.audioClip;

            currsound.audioSource.volume = currsound.audioVolume;

            currsound.audioSource.pitch = currsound.audioPitch;

            currsound.audioSource.loop = currsound.isLoop;
        }
    }
    

    public Sounds[] sounds;

    private void Start()
    {
        
    }

    public void PlayAudio(string nameAudio)
    {
        Sounds currsound = Array.Find(sounds, sounds => sounds.audioName == nameAudio);
        if(currsound == null) 
        {
            Debug.Log("Error! " + nameAudio + "Not found!");
            return;
        }
        
        currsound.audioSource.Play();
    }

     public void PlayAudioShot(string nameAudio)
    {
        Sounds currsound = Array.Find(sounds, sounds => sounds.audioName == nameAudio);
        if(currsound == null) 
        {
            Debug.Log("Error! " + nameAudio + "Not found!");
            return;
        }
        else{
            currsound.audioSource.PlayOneShot(currsound.audioClip);
        }
    }

    
}
