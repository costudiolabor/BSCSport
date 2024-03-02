using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateView : View {
    [SerializeField] private PlayerPenalty playerPenalty;
    
    
    public void MoveKick(Vector2 direction, float distance) {
        playerPenalty.MoveKick(direction, distance);
    }
}
