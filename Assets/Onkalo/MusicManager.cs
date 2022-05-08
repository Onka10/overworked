using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;

    public IReadOnlyReactiveProperty<int> LastGameTime => _lastTime;
    private readonly ReactiveProperty<int> _lastTime = new ReactiveProperty<int>();

    void Start(){
        _audioSource = GetComponent<AudioSource>();
        _lastTime.Value = (int)_audioSource.clip.length;

        GameManager.I.State
        .Where(s => s==GameState.InGame)
        .Subscribe(s =>MusicStart())
        .AddTo(this);
    }

    public void MusicStop(){
        _audioSource.Stop();
    }

    private void MusicStart(){
        //音源変更
        Music.Play("Music","");
    }

    void update(){
        if(_audioSource.isPlaying){
            _lastTime.Value = (int)(_audioSource.clip.length - _audioSource.time);
        }
    }
}
