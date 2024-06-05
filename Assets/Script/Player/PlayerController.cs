using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Assets.Script.Player
{
    public class PlayerController : MonoBehaviour
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
        public void StartShooting(InputAction.CallbackContext callback)
        {
            _isShooting = true;
            StartCoroutine(ShootCoroutine());
        }
        public void StopShooting(InputAction.CallbackContext callback)
        {
            _isShooting = false;
        }
        private void Shoot()
        {
            if (bulletParent == null) bulletParent = gameObject;
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
        public void EnablePlayerControl()
        {
            _inputAction?.Enable();
            _canShoot = true;
        }
        public void DisablePlayerControl()
        {
            _inputAction?.Disable();
        }
        private void OnDisable()
        {
            _inputAction?.Disable();
        }
    }
}