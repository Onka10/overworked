using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] StartButton _startbutton;
    [SerializeField] MusicManager _musicManager;

    public IReadOnlyReactiveProperty<GameState> State => _state;

    private readonly ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.Title);

    [SerializeField]private bool GameSet=false;

    async void Start()
    {

        _musicManager.LastGameTime
        .Subscribe(t =>{
            // if(t == 0)  GameSet=true;
            Debug.Log(t);
        })
        .AddTo(this);

        //流れ
        
        //タイトル画面
        //TODO初期化
        await UniTask.WaitUntil(() => _startbutton.TitleEnd);

        //ゲームシーン開始
        _state.Value = GameState.InGame;
        Debug.Log("ゲームスタート");

        //ゲーム中
        // await UniTask.Delay(30000);
        await UniTask.WaitUntil(() => GameSet);


        //ゲーム終了
        _state.Value = GameState.Result;
        Debug.Log("終わり");
    }

}
