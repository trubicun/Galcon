using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlanetUI))]
public class Planet : MonoBehaviour
{
    private int _playerId;
    private Renderer _renderer;

    public int PlayerId { get => _playerId; }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    
    public void SetPlayer(int id, Color color)
    {
        _renderer.material.color = color;
        _playerId = id;
    }
}
