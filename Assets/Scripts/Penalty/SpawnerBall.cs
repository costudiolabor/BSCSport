using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnerBall {
   [SerializeField] private Transform parentBall;
   [SerializeField] private Ball prefabBall;
   private Factory _factory = new ();

   public Ball GetBall() {
      Ball ball = _factory.Get(prefabBall, parentBall.position, parentBall.rotation);
      ball.transform.SetParent(parentBall);
      return ball;
   }
}
