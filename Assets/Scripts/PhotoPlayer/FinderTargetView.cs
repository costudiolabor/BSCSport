using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FinderTargetView : View {
    [SerializeField] private GameObject planeMarkerPrefab;
    private ARRaycastManager _arRaycastManager;
    private Vector2 _touchPosition;
    private bool _isInit;
    public event Action<Vector3> SetPositionEvent;

    public void SetRayCastManager(ARRaycastManager arRaycastManager) => _arRaycastManager = arRaycastManager;
    
    public void Initialize() {
        planeMarkerPrefab.SetActive(false);
        _isInit = true;
    } 

    void Update() {
        ShowMarker();
    }

    void ShowMarker() {
        if (_isInit == false) return;
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        _arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        if (hits.Count > 0) {
            planeMarkerPrefab.transform.position = hits[0].pose.position;
            planeMarkerPrefab.SetActive(true);
        }
       
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            SetPositionEvent?.Invoke(hits[0].pose.position);
        }
    }
}