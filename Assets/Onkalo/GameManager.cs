using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] StartButton _startbutton;
    [SerializeField] MusicManager _musicManager;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] InGameUI _inGameUI;

    public IReadOnlyReactiveProperty<GameState> State => _state;

    private readonly ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.Title);

    void Start()
    {
        _playerInput.Startgame
        .Where(_ => _state.Value != GameState.InGame)
        .Subscribe(_ => {
            //初期化
            _startbutton.GameStartAnime();
            GameFlow().Forget();
        })
        .AddTo(this);

        GameFlow().Forget();
    }



    private async UniTaskVoid GameFlow(){
        //タイトル画面
        _state.Value = GameState.Title;

        //ゲームカウントダウン
        await UniTask.WaitUntil(() => _startbutton.TitleEnd);
        _startbutton.TitleEnd = false;

        //ゲームシーン開始
        _state.Value = GameState.InGame;
        _inGameUI.StarGame();

        //ゲーム中
        await UniTask.WaitWhile(() => Music.IsPlaying);
        //モグラが終わるまでまつ
        await UniTask.Delay(1000);


        //ゲーム終了
        _state.Value = GameState.Result;
        await UniTask.Delay(2000);
    }

}
