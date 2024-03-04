using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Gate : ViewOperator<GateView> {
    
    public void Open() => view.Open();
    public void Close() => view.Close();
    public void SetPositionObject(Vector3 position) {
        view.transform.position = position;
        Debug.Log("position " + position);
    }
    public void MoveKick(Vector2 direction, float distance) {
        view.MoveKick(direction, distance);
    }
}
