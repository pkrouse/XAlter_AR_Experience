using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TagFinder : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    [SerializeField] private Material debugMaterial;
   
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, 0.1f));
    }

    void Update()
    {
        // var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hitObject;
        if (Physics.Raycast(ray, out hitObject))
        {
            if (hitObject.transform.CompareTag("Readable"))
            {
                hitObject.transform.gameObject.GetComponent<Renderer>().material = debugMaterial;
            }
        }
    }
}
