using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] Objects;
    [SerializeField] private GameObject top;
    private GameObject current;

    public void loadObject(int id)
    {
        Destroy(top.GetComponentInChildren<Findable>().gameObject);
        current = Instantiate(Objects[id], Vector3.zero, Quaternion.identity, top.transform);
    }
    void Start()
    {
        
    }
}
