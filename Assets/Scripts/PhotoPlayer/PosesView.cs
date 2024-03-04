using System;
using UnityEngine;
using UnityEngine.UI;

public class PosesView : View {
    [SerializeField] private Button buttonIdle;
    [SerializeField] private Button buttonKickBall;
    [SerializeField] private Button buttonBallIdle;
    [SerializeField] private Button buttonBallWaiting;

    public event Action IdleEvent, KickBallEvent, BallIdleEvent, BallWaitEvent;
    
    public void Initialize() {
        buttonIdle.onClick.AddListener(OnIdle);
        buttonKickBall.onClick.AddListener(OnKickBall);
        buttonBallIdle.onClick.AddListener(OnBallIdle);
        buttonBallWaiting.onClick.AddListener(OnBallWaiting);
    }

    private void OnIdle() {
        IdleEvent?.Invoke();
    }
    
    private void OnKickBall() {
        KickBallEvent?.Invoke();
    }

    private void OnBallIdle() {
        BallIdleEvent?.Invoke();
    }

    private void OnBallWaiting() {
        BallWaitEvent?.Invoke();
    }

   
}