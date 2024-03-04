using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryPhoto : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARContent arContent;
    [SerializeField] private FinderTarget finderTarget; 
    [SerializeField] private Poses poses;
    [SerializeField] private Avatars avatars;
    
    private void Awake() { 
       Screen.sleepTimeout = SleepTimeout.NeverSleep;
       main.CreateView();
       main.Initialize();
       arContent.CreateView();
       
       avatars.CreateViewClosed();
       avatars.Initialize();
       
       poses.CreateViewClosed();
       poses.Initialize();
       
       ARRaycastManager arRaycastManager = arContent.GetARRaycastManager();
       finderTarget.CreateView();
       finderTarget.SetRayCastManager(arRaycastManager);
       finderTarget.Initialize();
       
       Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        avatars.SetPositionPlayer(position);
        avatars.Open();
        
        arContent.DisableARPlaneManager();
        arContent.DisableARRayCastManager();
        finderTarget.Close();
        poses.Open();
    }

    private void OnDestroy() {
        UnSubscribe();
    }

    private void Subscribe() {
        poses.IdleEvent += avatars.Idle;
        poses.KickBallEvent += avatars.KickBall;
        poses.BallIdleEvent += avatars.BallIdle;
        poses.BallWaitEvent += avatars.BallWaitWaiting;

        finderTarget.SetPositionEvent += SetPositionObject;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        poses.UnSubscribe();
        
        poses.IdleEvent -= avatars.Idle;
        poses.KickBallEvent -= avatars.KickBall;
        poses.BallIdleEvent -= avatars.BallIdle;
        poses.BallWaitEvent -= avatars.BallWaitWaiting;
        
        finderTarget.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
    }
}
