using UnityEngine;

public class ActionDestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float delay;
    private void DestroyObject() => Destroy(target, delay);
}
