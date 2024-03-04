using UnityEngine;

public class PlayerPenalty : MonoBehaviour {
   [SerializeField] private Animator animator;
   [SerializeField] private Boots boots;
   [SerializeField] private string animParametr = "MoveKick";

   public void MoveKick(Vector2 direction, float distance) {
      boots.SetParametrs(direction, distance);
      animator.SetTrigger(animParametr);
   }
}
