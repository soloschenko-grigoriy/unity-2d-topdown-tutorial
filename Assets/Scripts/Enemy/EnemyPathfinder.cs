using UnityEngine;

namespace Enemy
{
    public class EnemyPathfinder : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 2f;
        
        private Vector2 _movementVector;
        private Rigidbody2D _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void FixedUpdate()
        {
            Move();
        }

        public void SetMovementVector(Vector2 value)
        {
            _movementVector = value;
        }
        
        private void Move()
        {
            var pos = _movementVector * (movementSpeed * Time.fixedDeltaTime);
            _rb.MovePosition(_rb.position + pos);
        }
    }
}
