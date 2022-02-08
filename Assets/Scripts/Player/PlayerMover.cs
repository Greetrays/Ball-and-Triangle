using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _powerJump;
    [SerializeField] private UnityEvent _jumped;

    private bool _isGround;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Start()
    {
        _isGround = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TryJump();
        }

    }

    private void TryJump()
    {
        if (_isGround == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _powerJump);
        _isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isGround = true;
            _jumped?.Invoke();
        }
    }
}
