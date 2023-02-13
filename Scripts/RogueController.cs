using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class RogueController : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private bool _isMovingRight;
    private bool _isMovingLeft;
    private bool _isMoving;
    private int _movingAnimation = Animator.StringToHash("isMoving");

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isMovingRight = Input.GetKey(KeyCode.D);
        _isMovingLeft = Input.GetKey(KeyCode.A);

        _isMoving = (_isMovingRight || _isMovingLeft) && (_isMovingRight && _isMovingLeft) == false;

        if (_isMoving)
        {
            if (_isMovingRight)
                transform.Translate(Vector2.right * Time.deltaTime * _speed);

            if (_isMovingLeft)
                transform.Translate(Vector2.left * Time.deltaTime * _speed);

            _spriteRenderer.flipX = _isMovingRight;
        }

        _animator.SetBool(_movingAnimation, _isMoving);
    }
}
