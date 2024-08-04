using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource music;

    [Header("Auido Clips")]
    public AudioClip background;
    
    // Start is called before the first frame update
    void Start()
    {
        music.clip = background;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
