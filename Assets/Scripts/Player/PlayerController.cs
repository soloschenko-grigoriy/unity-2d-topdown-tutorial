using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
    
        private PlayerControls _playerControls;
        private Vector2 _movementInput;
        private Rigidbody2D _rb;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
    
        private static readonly int MoveX = Animator.StringToHash("moveX");
        private static readonly int MoveY = Animator.StringToHash("moveY");
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _playerControls = new PlayerControls();
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void Update()
        {
            GetInput();
        }
    
        private void FixedUpdate()
        {
            Move();
            FaceMouseDirection();
        }

        private void Move()
        {
            var pos = _movementInput * (movementSpeed * Time.fixedDeltaTime);
            _rb.MovePosition(_rb.position + pos);
        
            _animator.SetFloat(MoveX, _movementInput.x);
            _animator.SetFloat(MoveY, _movementInput.y);
        }
    
        private void FaceMouseDirection()
        {
            var mousePos = Mouse.current.position.ReadValue();
            var worldPos = _camera.WorldToScreenPoint(transform.position);
        
            _spriteRenderer.flipX = mousePos.x < worldPos.x;
        }
        

        private void GetInput()
        {
            _movementInput = _playerControls.ActionsMap.Movement.ReadValue<Vector2>();
        }
    
    
    }
}
