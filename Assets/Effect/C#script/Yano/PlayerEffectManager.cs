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
    public void Play()
    {
        GameObject PlayEffect = GetEffect();
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
        for (int i = 0; i < (int)KeyBoardEnum.M; i++)
        {
            mPlayEffectList.Add(mPlayerEffects.transform.GetChild(i).gameObject);
        }
    }
    /// <summary>
    /// 使えるエフェクトを有効化して返すよ
    /// </summary>
    /// <returns>使えるエフェクト</returns>
    private GameObject GetEffect()
    {
        GameObject CanUseEffect = null ;
        //作って合ったやつを有効化して渡す
        foreach (GameObject effect in mPlayEffectList)
        {
            if (!effect.activeSelf)
            {
                effect.SetActive(true);
                CanUseEffect = effect;
            }
        }
        return CanUseEffect;
    }

    private void Start()
    {
        CreateEffectPool();
    }
}

