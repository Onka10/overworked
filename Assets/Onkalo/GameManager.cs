using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Cysharp.Threading.Tasks;
using UniRx;

public class GameManager : MonoBehaviour
{

    public IReadOnlyReactiveProperty<GameState> State => _state;

    private readonly ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.Title);

    void Start()
    {
        _state.AddTo(this);

        // _state
        // .Subscribe

    }

}
