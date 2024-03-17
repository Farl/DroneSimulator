using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Local References:")]
    [SerializeField] private AudioSource _audioSource = default;
    [Header("Settings:")]
    [SerializeField] private float _pitch = 1f;
    [SerializeField] private float _pitchVelocityMultiplier = 0.0035f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        float calculatedPitch = _pitch + (_rigidbody.velocity.magnitude * _pitchVelocityMultiplier);

        _audioSource.pitch = calculatedPitch;
    }
}
