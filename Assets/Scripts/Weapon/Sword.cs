using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapon
{
    public class Sword : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private Animator _animator;
        
        private static readonly int Attack1 = Animator.StringToHash("Attack");
        
        
        private void Awake()
        {
            _playerControls = new PlayerControls();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void Start()
        {
            _playerControls.Combat.Attack.started += _ => Attack();
        }

        private void Attack()
        {
            _animator.SetTrigger(Attack1);
        }
    }
}
