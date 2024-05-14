using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARExperienceManager : Singleton<ARExperienceManager>
{

    private GameObject wellHead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setWellhead(GameObject wh)
    {
        wellHead = wh;
    }
    public void pointerDown()
    {
        wellHead.GetComponent<PopOutController>().pointerDown();
    }
    public void pointerUp()
    {
        wellHead.GetComponent<PopOutController>().pointerUp();
    }
}
