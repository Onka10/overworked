using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    private ParticleSystem mParticle;
    private void Start()
    {
        if (mParticle = this.gameObject.GetComponent<ParticleSystem>()) { }
        else
        {
            mParticle = gameObject.GetComponentInChildren<ParticleSystem>();
        }
    }
    private void Update()
    {
        if(!mParticle.isPlaying)
        {
            mParticle.gameObject.SetActive(false);
        }
    }
}