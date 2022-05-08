using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] StartButton _startbutton;
    [SerializeField] MusicManager _musicManager;
    [SerializeField] GameOver _gameover;
    [SerializeField] PlayerInput _playerInput;

    public IReadOnlyReactiveProperty<GameState> State => _state;

    private readonly ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.Title);

    [SerializeField]private bool GameSet=false;

    async void Start()
    {

        _musicManager.LastGameTime
        .Subscribe(t =>{
            if(t == 0)  GameSet=true;
        })
        .AddTo(this);

        _playerInput.Startgame
        .Subscribe(_ => _startbutton.GameStartAnime())
        .AddTo(this);

        //流れ
        
        //タイトル画面
        //TODO初期化
        _state.Value = GameState.Title;

        //ゲームシーン開始
        await UniTask.WaitUntil(() => _startbutton.TitleEnd);
        _startbutton.TitleEnd = false;
        _state.Value = GameState.InGame;
        Debug.Log("ゲームスタート");

        //ゲーム中
        // await UniTask.Delay(30000);
        await UniTask.WaitUntil(() => GameSet);


        //ゲーム終了
        _state.Value = GameState.Result;
        _gameover.PlayOverAnime();
        Debug.Log("終わり");
    }

}
