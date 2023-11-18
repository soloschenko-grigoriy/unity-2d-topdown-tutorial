using System;
using System.Collections;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapon
{
    public class Sword : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private Animator _animator;
        private PlayerController _playerController;
        private ActiveWeapon _activeWeapon;
        private Camera _camera;
        
        private static readonly int Attack1 = Animator.StringToHash("Attack");
        
        
        private void Awake()
        {
            _camera = Camera.main;
            _playerControls = new PlayerControls();
            _animator = GetComponent<Animator>();
            _activeWeapon = GetComponentInParent<ActiveWeapon>();
            _playerController = GetComponentInParent<PlayerController>();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void Start()
        {
            _playerControls.Combat.Attack.started += _ => Attack();
        }

        private void Update()
        {
            FlipWeapon();
        }

        private void FlipWeapon()
        {
            var mousePos = Mouse.current.position.ReadValue();
            var worldPos = _camera.WorldToScreenPoint(_playerController.transform.position);

            var rotation = mousePos.x < worldPos.x ? 180 : 0;
            var offset = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            
            _activeWeapon.transform.rotation = Quaternion.Euler(0, rotation, offset);
        }

        private void Attack()
        {
            _animator.SetTrigger(Attack1);
        }
    }
}
