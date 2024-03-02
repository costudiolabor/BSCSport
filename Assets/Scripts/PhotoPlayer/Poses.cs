using System;
using Unity.VisualScripting;

[Serializable]
public class Poses : ViewOperator<PosesView> {
    public event Action IdleEvent, KickBallEvent, FingerUpEvent, LegOnBallEvent;
    public void Initialize() {
        view.Initialize();
        // view.IdleEvent += OnIdle;
        // view.KickBallEvent += OnKickBall;
        // view.LegOnBallEvent += OnLegOnBall;
        // view.FingerUpEvent += OnFingerUp;
        Subscribe();
    }
    
    private void OnIdle() {
        IdleEvent?.Invoke();
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

    public void Open() => view.Open();
    public void Close() => view.Close();
    
    private void Subscribe() {
        view.IdleEvent += OnIdle;
        view.KickBallEvent += OnKickBall;
        view.LegOnBallEvent += OnLegOnBall;
        view.FingerUpEvent += OnFingerUp;
    }  
    
    public void UnSubscribe() {
        view.IdleEvent -= OnIdle;
        view.KickBallEvent -= OnKickBall;
        view.LegOnBallEvent -= OnLegOnBall;
        view.FingerUpEvent -= OnFingerUp;
    }
}