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
    /// エフェクトをコピーして新しく作るよ
    /// </summary>
    /// <returns>新しく作った奴</returns>
    private GameObject CreateNewEffect()
    {
        GameObject NewEffect = Instantiate(mPlayerEffects);   //新しいエフェクト

        // 新しく作った奴は非有効化されてListに格納されるよ
        NewEffect.SetActive(false);
        mPlayEffectList.Add(NewEffect);
        return NewEffect;
    }
    /// <summary>
    /// 使えるエフェクトを有効化して返すよ。なかったら新しく作るよ
    /// </summary>
    /// <returns>使えるエフェクト</returns>
    private GameObject GetEffect()
    {
        //作って合ったやつを有効化して渡す
        foreach (GameObject CanUseEffect in mPlayEffectList)
        {
            if (!CanUseEffect.activeSelf)
            {
                CanUseEffect.SetActive(true);
                return CanUseEffect;
            }
        }
        //新しく作って有効かして渡す
        GameObject NewEffect = CreateNewEffect();
        NewEffect.SetActive(true);
        return NewEffect;
    }

    private void Start()
    {
        CreateEffectPool();
    }
}

