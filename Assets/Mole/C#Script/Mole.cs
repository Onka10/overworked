using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class Mole : MonoBehaviour
{
    // [SerializeField] MoleView _moleview;
    [SerializeField] MoleUpDown _moleUpDown;
    [SerializeField] ScoreManager _scoreManager;

    [SerializeField]private MoleState _moleState;                //モグラの状態
    private float mAppearanceTime;               //出現している時間

    private CancellationTokenSource cts = new CancellationTokenSource();

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
        _scoreManager.ScoreAdd();
    }

    /// <summary>
    /// モグラの出現
    /// </summary>
    public async void Apper(CancellationToken ct = default)
    {
        //姿を出現
        _moleState = MoleState.Appearance;
        _moleUpDown.StartUpDown();
        Debug.Log("スタートupdown"+ _moleState);

        await UniTask.Delay(100);
        //移動中
        await UniTask.WaitUntil(() => _moleUpDown.mUpDownComplited,cancellationToken: ct);

        //潜る
        _moleState = MoleState.Incubation;
        Debug.Log("endupdown"+ _moleState);
        
    }

    /// <summary>
    /// モグラの初期化
    /// </summary>
    private void Init()
    {
        //ステータスの初期化
        _moleState = MoleState.Incubation;

        //TODO 色の初期化

        //見た目の初期化
        // _moleview.InitLooks();

    }
}
