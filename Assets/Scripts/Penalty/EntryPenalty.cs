using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryPenalty : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARContent arContent;
    [SerializeField] private FinderTarget finderTarget;
    [SerializeField] private Gate gate;
    [SerializeField] private SpawnerBall spawnerBall;
    
    [SerializeField] private float timeSpawn = 3.0f;
    private Kicker kicker = new Kicker();
    private void Awake() { 
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        main.CreateView();
        main.Initialize();
        
        arContent.CreateView();
        ARRaycastManager arRaycastManager = arContent.GetARRaycastManager();
        
        finderTarget.CreateView();
        finderTarget.SetRayCastManager(arRaycastManager);
        finderTarget.Initialize();
        
        gate.CreateViewClosed();
        
        kicker.Initialize();
        spawnerBall.GetBall();
        Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        
        gate.Open();
        gate.SetPositionObject(position);
        
        arContent.DisableARPlaneManager();
        arContent.DisableARRayCastManager();
        finderTarget.Close();
        spawnerBall.GetBall();
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
        
        finderTarget.SetPositionEvent += SetPositionObject;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
        kicker.UpButtonEvent -= OnUpButton;
        kicker.UnSubscribe();
    }
    
    private void OnDestroy() {
        UnSubscribe();
    }
}
