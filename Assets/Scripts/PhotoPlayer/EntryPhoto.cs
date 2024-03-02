using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryPhoto : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARContent arContent;
    [SerializeField] private FinderTarget finderTarget; 
    [SerializeField] private Poses poses;
    [SerializeField] private Player player;
    
    private void Awake() { 
       Screen.sleepTimeout = SleepTimeout.NeverSleep;
       main.CreateView();
       main.Initialize();
       arContent.CreateView();
       player.CreateViewClosed();
       player.Initialize();
       poses.CreateViewClosed();
       poses.Initialize();
       
       ARRaycastManager arRaycastManager = arContent.GetARRaycastManager();
       finderTarget.CreateView();
       finderTarget.SetRayCastManager(arRaycastManager);
       finderTarget.Initialize();
       
       Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        player.SetPositionPlayer(position);
        player.Open();
        
        arContent.DisableARPlaneManager();
        arContent.DisableARRayCastManager();
        finderTarget.Close();
        poses.Open();
    }

    private void OnDestroy() {
        UnSubscribe();
    }

    private void Subscribe() {
        poses.IdleEvent += player.Idle;
        poses.KickBallEvent += player.KickBall;
        poses.FingerUpEvent += player.FingerInUp;
        poses.LegOnBallEvent += player.LegInBall;

        finderTarget.SetPositionEvent += SetPositionObject;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        poses.UnSubscribe();
        poses.IdleEvent -= player.Idle;
        poses.KickBallEvent -= player.KickBall;
        poses.FingerUpEvent -= player.FingerInUp;
        poses.LegOnBallEvent -= player.LegInBall;
        
        finderTarget.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
    }


    
    
}
