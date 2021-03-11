using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    private int _playerId;
    private Color _playerColor;

    public int PlayerId { get => _playerId; }
    public Color PlayerColor { get => _playerColor;}

    public void SetPlayer(int id, Color color)
    {
        _playerId = id;
        _playerColor = color;

        print("Player setted");
        print("Id is " + id);

        ChangeColor(color);
    }

    protected abstract void ChangeColor(Color color);
}