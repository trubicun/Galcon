using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPool : MonoBehaviour
{
    [SerializeField] private int _startCount;
    [SerializeField] private Ship _ship;

    public static ShipPool Instance;

    private Queue<Ship> _ships;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _ships = new Queue<Ship>();

        for(int i = 0; i < _startCount; i++)
        {
            Ship ship = Instantiate(_ship, transform);
            ship.gameObject.SetActive(false);
            _ships.Enqueue(ship);
        }
    }

    public Ship GetShip()
    {
        if (_ships.Count <= 0)
        {
            _ships.Enqueue(Instantiate(_ship,transform));
        }
        return _ships.Dequeue();
    }

    public void ReturnShip(Ship ship)
    {
        _ships.Enqueue(ship);
        ship.gameObject.SetActive(false);
    }
}
