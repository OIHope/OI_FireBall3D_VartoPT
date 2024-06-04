using UnityEngine;

public class ActionDestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float delay;
    [SerializeField] private bool deactivate = false;
    private void DestroyObject()
    {
        if (deactivate)
        {
            target.SetActive(false);
        }
        else
        {
            Destroy(target, delay);
        }
    }
}
