using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField,Range(1.0f,100.0f)] private float mAppearanceTimeLimit;   //出現時間
    private string mDeadKey;                               //死因のキーとなるキー
    private MoleStateEnum.MoleState mState;                //モグラの状態
    private float mAppearanceTime;
    /// <summary>
    /// このモグラの死因のキーの設定
    /// </summary>
    /// <param name="_InputKeyID">このキーで死にます</param>
    /// ゲームが始まると一度だけ呼ばれる
    public void InitMole(string _InputKeyID)
    {
        mDeadKey = _InputKeyID;
    }
    /// <summary>
    /// 攻撃が直撃したなら死ぬ
    /// </summary>
    /// <param name="_InputKeyName"></param>
    public void Attacked(string _InputKeyName)
    {
        if (mDeadKey == _InputKeyName) 
        {
            
        }
    }
    private void Appearance()
    {
        mAppearanceTime += Time.deltaTime;
        if (mAppearanceTime>mAppearanceTimeLimit)
        {
            
        }
    }
    private void ChangeMoleState(MoleStateEnum.MoleState _changeState)
    {

    }
    private void OnEnable()
    {
        mAppearanceTime = 0.0f;
    }
    private void Update()
    {


    }
}
