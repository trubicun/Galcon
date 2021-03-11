using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlanetUI))]
[RequireComponent(typeof(Hangar))]
public class Planet : Player
{
    [SerializeField] private float _selectSize = 1.2f;

    public bool Selected { get => _selected; }

    public int ShipCount { get => _hangar.Count; }

    private Vector3 _scale;
    private Vector3 _selectedScale;
    private Hangar _hangar;
    private bool _selected;
    private Renderer _renderer;

    private void Start()
    {
        _hangar = GetComponent<Hangar>();
        _hangar.enabled = false;

        _scale = transform.localScale;
        _selectedScale = _scale * _selectSize;

        _renderer = GetComponent<Renderer>();
    }

    public void Select()
    {
        _selected = true;
        transform.localScale = _selectedScale;
    }

    public void UnSelect()
    {
        _selected = false;
        transform.localScale = _scale;
    }

    public void Deploy(Planet target)
    {
        if (target != this) _hangar.Deploy(target);
    }

    public void Attack(int id, Color color)
    {
        if (_hangar.Count < 0) SetPlayer(id, color);
        else
        if (id == PlayerId) _hangar.Add();
        else _hangar.Kill();
    }

    protected override void ChangeColor(Color color)
    {
        _renderer.material.color = color;
    }
}
