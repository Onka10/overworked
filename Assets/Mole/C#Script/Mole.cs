using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Mole : MonoBehaviour
{
    private MoleState _moleState;                //モグラの状態
    private float mAppearanceTime;               //出現している時間

    void Start(){
        _moleState = MoleState.Incubation;
    }

    /// <summary>
    /// モグラの 状態を返す
    /// </summary>
    public MoleState GetMoleState(){
        return _moleState;
    }

    /// <summary>
    /// 攻撃されたらなら死ぬ
    /// </summary>
    public void Attacked()
    {
        if(_moleState != MoleState.Dameged) return;

        _moleState = MoleState.Dameged;
        Debug.Log("攻撃された");

        //TODO スコアマネージャを呼ぶ
    }

    /// <summary>
    /// モグラの出現
    /// </summary>
    public async void Apper()
    {
        //姿を出現
        _moleState = MoleState.Appearance;
        //移動中
        //FIXME MOveと連携が取れてない
        await UniTask.Delay(3000);
        //潜る
        _moleState = MoleState.DisAppearance;
        
    }

    /// <summary>
    /// モグラの初期化
    /// </summary>
    private void Init()
    {
        _moleState = MoleState.Incubation;
        //TODO 色の変更・目の初期化
    }
}
