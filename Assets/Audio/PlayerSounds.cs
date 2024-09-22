using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] splats;

    AudioSource myAudioSource;

    [SerializeField] Collider2D circleCollider;

    [SerializeField] AudioClip shellBreak;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "Damaging"))
        {
            playRandomSound();
        }

        if (collision.gameObject.tag == "Damaging")
        {
            myAudioSource.PlayOneShot(shellBreak);
        }
    }

    void playRandomSound()
    {
        AudioClip clip = splats[Random.Range(0, splats.Length)];
        myAudioSource.PlayOneShot(clip);
    }
}
