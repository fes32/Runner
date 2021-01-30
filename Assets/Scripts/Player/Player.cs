using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _hitJumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _hitEffect;

    public event UnityAction Dying;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> ScoreZoneEntered;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private bool _grounded;
    private int _score;

    public Animator Animator => _animator;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public bool Grounded => _grounded;
    public float Speed => _speed;
    public int Score => _score;

    private void OnValidate()
    {
        if (_minHealth >= _maxHealth)
        {
            _minHealth = _maxHealth - 1;
        }
        if(_health > _maxHealth)
        {
            _health = (int)_maxHealth;
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = _spawnPoint.position;
        _grounded = true;
        _score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Spike spike))
        {
            Animator.Play("Hit");
            TakeDamage(spike.Damage);
            Hit();
        }    
        else if (collision.gameObject.GetComponent<ScoreZone>())
        {
            _score++;
            ScoreZoneEntered?.Invoke(_score);
        }
    }

    private void Die()
    {
        Dying?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();

        HealthChanged?.Invoke(_health);
    }

    public void Jump()
    {
        _grounded = false;
        Rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        Rigidbody2D.AddForce(Vector2.up*_jumpForce);
    }

    public void Grounding()
    {
        _grounded = true;
    }

    private void Hit()
    {
        Rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        Rigidbody2D.AddForce(Vector2.up * _hitJumpForce);

        Vector3 hitEffectSpawnPoint = transform.position;

        _hitEffect.transform.position = hitEffectSpawnPoint;
        _hitEffect.Play();
    }
}