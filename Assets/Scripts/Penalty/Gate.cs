using System;
using UnityEngine;

[Serializable]
public class Gate : ViewOperator<GateView> {
    [SerializeField] private SpawnerBall spawnerBall;

    public event Action<Vector2, float> MoveKickEvent;  
    public void Initialize() {
        Transform parentBall = view.GetParentBall();
        spawnerBall.SetParentBall(parentBall);
        Subscribe();
    }

    public void Open() {
        view.Open();
        SpawnBall();
    }

    private void SpawnBall() {
        spawnerBall.GetBall();
        MoveKickEvent += view.MoveKick;
    }
    
    public void Close() => view.Close();
    public void SetPositionObject(Vector3 position) {
        view.transform.position = position;
        Debug.Log("PositionObject " + position);
    }
    public void MoveKick(Vector2 direction, float distance) {
        MoveKickEvent?.Invoke(direction, distance);
        //view.MoveKick(direction, distance);
        MoveKickEvent -= view.MoveKick;
    }
    
    
    private void Subscribe() {
        view.GetBallEvent += SpawnBall;
    }  
    
    public void UnSubscribe() {
        view.GetBallEvent -= SpawnBall;
    }

}
