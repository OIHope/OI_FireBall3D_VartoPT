using UnityEngine;

public class ActionActivateDeactivateDestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject[] targetDestroy;
    [SerializeField] private GameObject[] targetActivate;
    [SerializeField] private GameObject[] targetDeactivate;
    public void ManipulateObject()
    {
        foreach (GameObject obj in targetDestroy)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in targetActivate)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in targetDeactivate)
        {
            obj.SetActive(false);
        }
    }
}
