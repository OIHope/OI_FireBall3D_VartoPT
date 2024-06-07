using Assets.Script.Level;
using UnityEngine;

namespace Assets.Script.Player
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] bulletHitShieldParticles;
        [SerializeReference] private GameObject[] bulletDestroyParticles;
        [SerializeField] private float bulletSpeed = 10f;
        [SerializeField] private float destroyTime = 2f;
        
        public Vector3 moveDirection = Vector3.forward;

        public void Init()
        {
            Destroy(gameObject, destroyTime);
        }
        private void FixedUpdate()
        {
            Move(moveDirection);
        }
        private void Move(Vector3 moveDirection)
        {
            transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Target target))
            {
                target.TakeDamage();
                moveDirection *= -1;
                if (!other.CompareTag("Shield"))
                {
                    foreach (GameObject particle in bulletDestroyParticles) { Instantiate(particle, transform.position, Quaternion.identity); }
                    Destroy(gameObject);
                }
                else
                {
                    foreach (GameObject particle in bulletHitShieldParticles) { Instantiate(particle, transform.position, Quaternion.identity); }
                }
            }
        }
    }
}