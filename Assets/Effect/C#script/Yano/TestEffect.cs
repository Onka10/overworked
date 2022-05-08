using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEffect : MonoBehaviour
{
    private ParticleSystem ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ParticleSystem.isPlaying)
        {
            ParticleSystem.Play();
        }
    }
}
