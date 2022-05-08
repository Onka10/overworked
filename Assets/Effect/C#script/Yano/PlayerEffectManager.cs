using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectManager : MonoBehaviour
{
    [SerializeField] private GameObject mPlayerEffects;
    private List<GameObject> mPlayEffectList = new List<GameObject>();
    /// <summary>
    /// エフェクトを出現させるよ
    /// </summary>
    public void Play(KeyBoardEnum _key)
    {
        GameObject PlayEffect = mPlayEffectList[(int)_key];
        ParticleSystem particleSystem;
        //エフェクトを拾って動かすよ
        if (particleSystem = PlayEffect.GetComponent<ParticleSystem>())
        {
            particleSystem.Play();
        }
        else
        {
            particleSystem = PlayEffect.GetComponentInChildren<ParticleSystem>();

            particleSystem.Play();
        }
    }

    /// <summary>
    /// 一度作って貯めておくよ
    /// </summary>
    private void CreateEffectPool()
    {
        for (int i = 0; i <= (int)KeyBoardEnum.M; i++)
        {
            GameObject effect = mPlayerEffects.transform.GetChild(i).gameObject;
            effect.SetActive(false);
            mPlayEffectList.Add(effect);
        }
    }

    private void Start()
    {
        CreateEffectPool();
    }
}

