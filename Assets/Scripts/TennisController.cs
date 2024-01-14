using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisController : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        PlaySound();
    }
    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.volume = rigidbody.velocity.magnitude * 0.8f;
            audioSource.Stop();
            audioSource.Play();
        }
    }
}
