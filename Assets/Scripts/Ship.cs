using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Ship : Player
{
    [SerializeField] private float _speed = 1;

    private Rigidbody _rigidbody;
    private Planet _target;
    private Renderer _renderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = transform.GetChild(0).GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Planet planet = collision.gameObject.GetComponent<Planet>();
        if (planet && planet == _target)
        {
            planet.Attack(PlayerId,PlayerColor);

            ShipPool.Instance.ReturnShip(this);
        }
    }

    public void FlyTo(Planet target)
    {
        gameObject.SetActive(true);
        _target = target;
        transform.LookAt(_target.transform.position);
        StartCoroutine(Flying());
    }

    private IEnumerator Flying()
    {
        while(true)
        {
            _rigidbody.velocity = (_target.transform.position - transform.position).normalized * _speed;
            yield return null;
        }
    }

    protected override void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }
}
