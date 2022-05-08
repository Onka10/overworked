using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TimeView : MonoBehaviour
{
    public Text _timeText;
    public MusicManager _musicManager;

    void Start()
    {
        _musicManager.LastGameTime
        .Subscribe(t => _timeText.text = t.ToString())
        .AddTo(this);
    }


}