using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public static AudioSource audioS;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AudioPlay(AudioClip clip)
    {
        //播放指定的音效
        audioS.PlayOneShot(clip);
    }
}
