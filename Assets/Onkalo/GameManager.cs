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
    [SerializeField] InGameUI _inGameUI;

    public IReadOnlyReactiveProperty<GameState> State => _state;

    private readonly ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.Title);

    async void Start()
    {

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
        _inGameUI.StarGame();
        Debug.Log("ゲームスタート");

        //ゲーム中
        // await UniTask.Delay(30000);
        await UniTask.WaitWhile(() => Music.IsPlaying);


        //ゲーム終了
        _state.Value = GameState.Result;
        await UniTask.Delay(2000);
        _gameover.PlayOverAnime();
        // Debug.Log("終わり");
    }

}
