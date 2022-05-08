using UnityEngine;

public class SEManager : Singleton<SEManager>
{
    [SerializeField] private AudioSource mPlayerAttackAudioSource;
    [SerializeField] private AudioSource mClickAudioSource;
    /// <summary>
    /// 攻撃したときの音
    /// </summary>
    public void StartAttackSE()
    {

        mPlayerAttackAudioSource.Play();

    }
    /// <summary>
    /// クリックしたときの音
    /// </summary>
    public void StartClickSE()
    {

        mClickAudioSource.Play();

    }
}
