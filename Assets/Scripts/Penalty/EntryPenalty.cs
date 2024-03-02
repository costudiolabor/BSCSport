using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryPenalty : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARContent arContent;
    [SerializeField] private SpawnerBall spawnerBall;
    [SerializeField] private Gate gate;
    //[SerializeField] private FinderTarget finderTarget;
    
    [SerializeField] private float timeSpawn = 3.0f;
    private Kicker kicker = new Kicker();
    private void Awake() { 
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        main.CreateView();
        main.Initialize();
        arContent.CreateView();
        //gate.CreateViewClosed();
        gate.CreateView();
        kicker.Initialize();
        //spawnerBall.GetBall();
        Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        arContent.DisableARPlaneManager();
        arContent.DisableARRayCastManager();
    }
    
    private void OnUpButton(Vector2 direction, float distance) {
        gate.MoveKick(direction, distance);
        StartCoroutine(TimerSpawn());
    }
    
    private IEnumerator TimerSpawn() {
        yield return new WaitForSeconds(timeSpawn);
        spawnerBall.GetBall();
    }

    private void Subscribe() {
        kicker.UpButtonEvent += OnUpButton;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        kicker.UpButtonEvent -= OnUpButton;
        kicker.UnSubscribe();
    }
    
    private void OnDestroy() {
        UnSubscribe();
    }
}
