using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[ RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager)) ]
public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField] private GameObject WellheadPrefab;
    private ARRaycastManager ARRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private ARAnchorManager ARAnchorManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject Wellhead = null;
    private ARAnchor wellheadAnchor = null;
    // [SerializeField] private GameObject ErrorPrefab;
    private void Awake()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
        ARPlaneManager = GetComponent<ARPlaneManager>();
        ARAnchorManager = GetComponent<ARAnchorManager>();
    }
    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;
        if (ARRaycastManager.Raycast(finger.currentTouch.screenPosition, 
            hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            ARPlane plane = ARPlaneManager.GetPlane(hits[0].trackableId);
            
            // wellheadAnchor = ARAnchorManager.AddComponent<ARAnchor>();
            // Need the plane to attach the anchor to (see 1).  Otherwise the anchor is not anchored.
            // ARAnchorManager.AddAnchor(pose);
            wellheadAnchor = ARAnchorManager.AttachAnchor(plane, pose);
            
            // make the wellhead and parent it to the anchor
            if (Wellhead != null)
            {
                Destroy(Wellhead);
            }
            Wellhead = Instantiate(WellheadPrefab, pose.position, pose.rotation, wellheadAnchor.transform);
            ARExperienceManager.Instance.setWellhead(Wellhead);
        }
    }
    
}
