using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScoreManager : MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> Score => _score;
    private readonly ReactiveProperty<int> _score = new ReactiveProperty<int>(0);

    // Start is called before the first frame update

    void Start(){
        GameManager.I.State
        .Where(s => s==GameState.InGame)
        .Subscribe(_ => _score.Value = 0)
        .AddTo(this);
    }

    public void ScoreAdd()
    {
        
        _score.Value+=10;
    }

    public void Miss(){
        _score.Value-=10;

        if(_score.Value < 0)    _score.Value=0;
    }

}
