using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimeView : MonoBehaviour
{
    public Text _timeText;
    public MusicManager _musicManager;

    [SerializeField] GameObject _timeviewobject;

    void Start()
    {
        GameManager.I.State
        .Where(s => s==GameState.InGame)
        .Subscribe(_ => _timeviewobject.SetActive(true) )
        .AddTo(this);

        GameManager.I.State
        .Where(s => s!=GameState.InGame)
        .Subscribe(_ => _timeviewobject.SetActive(false) )
        .AddTo(this);

        _musicManager.LastGameTime
        .Subscribe(t => _timeText.text = t.ToString())
        .AddTo(this);
    }


}