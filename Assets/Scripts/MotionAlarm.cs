using UnityEngine;

public class MotionAlarm : MonoBehaviour
{
    [SerializeField] private Material alarmMaterial;
    [SerializeField] private GameObject debugGameObject;
    [SerializeField] private float driftAmount = 0.01f;
    private Vector3 startPosition;
    private float startTime;
    void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (drifted() == true)
        {
            debugGameObject.GetComponent<Renderer>().material = alarmMaterial;
            transform.position = startPosition;
        }
    }

    private bool drifted()
    {
        if (Mathf.Abs(startPosition.x - transform.position.x) > driftAmount)
        {
            return true;
        }
        if (Mathf.Abs(startPosition.y - transform.position.y) > driftAmount)
        {
            return true;
        }
        return false;
    }
}
