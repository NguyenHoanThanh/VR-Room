using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFallHandle : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip breakBoneClip;
    [SerializeField] private OnTimedInterval onTimedInterval;

    private void OnCollisionEnter()
    {
        onTimedInterval.StopInterval();

        float collisionMagnitude = rigidbody.velocity.magnitude;

        float volume = Mathf.Clamp01(collisionMagnitude * 5f);
        volume = Mathf.Min(volume, 1); 

        audioSource.clip = breakBoneClip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
