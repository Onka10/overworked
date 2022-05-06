using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

public class GameManager : Singleton<GameManager>
{

    public IReadOnlyReactiveProperty<GameState> State => _state;

    private readonly ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.Title);

    async void Start()
    {
        _state.AddTo(this);
        //ゲームシーンのみ考える
        //初期化
        //カウントダウン
        await UniTask.Delay (3000);

        //ゲームシーン開始
        _state.Value = GameState.InGame;
        Debug.Log("ゲームスタート");

        //ゲーム中
        await UniTask.Delay(30000);

        //ゲーム終了
        _state.Value = GameState.Result;
        Debug.Log("終わり");
    }

}
