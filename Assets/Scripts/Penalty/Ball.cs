using System.Collections;
using UnityEngine;
public class Ball : MonoBehaviour {
    [SerializeField] private Rigidbody thisRigidbody;
    [SerializeField] private float maxSpeedBall = 1.0f;
    [SerializeField] private float timeLife = 10.0f;
    private Coroutine _coroutine;
    
    public void Kick(Vector2 direction, float power) {
        var speedBall = maxSpeedBall * power;
        Vector3 directionBall = new Vector3(direction.x, transform.position.y, direction.y) +  transform.forward;;
        thisRigidbody.AddForce(directionBall * speedBall, ForceMode.Impulse);
        StartCoroutine(TimerLife());
    }
  
    //private void OnEnable() { _coroutine = StartCoroutine(TimerLife()); }

    private IEnumerator TimerLife() {
        yield return new WaitForSeconds(timeLife);
        gameObject.SetActive(false);
        _coroutine = null;
    }
    
    private void OnDisable() {
        if (_coroutine == null) return; 
        StopCoroutine(_coroutine);
    }
}
