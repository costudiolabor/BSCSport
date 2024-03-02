using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Gate : ViewOperator<GateView> {
    public void MoveKick(Vector2 direction, float distance) {
        view.MoveKick(direction, distance);
    }
}
