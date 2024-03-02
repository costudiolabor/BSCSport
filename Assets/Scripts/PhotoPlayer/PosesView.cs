using System;
using UnityEngine;
using UnityEngine.UI;

public class PosesView : View {
    [SerializeField] private Button buttonIdle;
    [SerializeField] private Button buttonFingerUp;
    [SerializeField] private Button buttonLegOnBall;
    [SerializeField] private Button buttonKickBall;

    public event Action IdleEvent, KickBallEvent, FingerUpEvent, LegOnBallEvent;
    
    public void Initialize() {
        buttonIdle.onClick.AddListener(OnIdle);
        buttonFingerUp.onClick.AddListener(OnFingerUp);
        buttonLegOnBall.onClick.AddListener(OnLegOnBall);
        buttonKickBall.onClick.AddListener(OnKickBall);
    }

    private void OnKickBall() {
        KickBallEvent?.Invoke();
    }

    private void OnLegOnBall() {
        LegOnBallEvent?.Invoke();
    }

    private void OnFingerUp() {
        FingerUpEvent?.Invoke();
    }

    private void OnIdle() {
        IdleEvent?.Invoke();
    }
}