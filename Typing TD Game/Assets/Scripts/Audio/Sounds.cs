using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sounds
{

    public string audioName;
    public AudioClip audioClip;

    [Range(0f,1f)]
    public float audioVolume;
    [Range(.1f,3f)]
    public float audioPitch;

    public bool isLoop;

    [HideInInspector]
    public AudioSource audioSource;




}
