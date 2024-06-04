using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        private PlayerInput _inputAction;

        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject bulletParent;
        [SerializeField] private Transform bulletShootPoint;
        [SerializeField] private float shootDelay;
        private bool _canShoot = true;
        private bool _isShooting = false;

        private void Awake()
        {
            _inputAction = new PlayerInput();
            _inputAction.GameInput.Shoot.started += StartShooting;
            _inputAction.GameInput.Shoot.canceled += StopShooting;
        }
        private void StartShooting(InputAction.CallbackContext callback)
        {
            _isShooting = true;
            StartCoroutine(ShootCoroutine());
        }
        private void StopShooting(InputAction.CallbackContext callback)
        {
            _isShooting = false;
        }
        private void Shoot()
        {
            var bullet = Instantiate(bulletPrefab, bulletShootPoint.position, Quaternion.identity, bulletParent.transform).GetComponent<BulletManager>();
            bullet.Init();
        }
        private IEnumerator ShootCoroutine()
        {
            while (_isShooting && _canShoot)
            {
                Shoot();
                _canShoot = false;
                yield return new WaitForSeconds(shootDelay);
                _canShoot = true;
            }
        }
        private void OnEnable()
        {
            _inputAction?.Enable();
        }
        private void OnDisable()
        {
            _inputAction?.Disable();
        }
    }
}