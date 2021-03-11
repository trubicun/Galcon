using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Planet))]
public class Hangar : MonoBehaviour
{
    [SerializeField] private int _maxCount;
    [SerializeField] private float _refillTime = 1;
    public int Count { get => _count; }

    private int _count;
    private Planet _planet;

    private void Awake()
    {
        _planet = GetComponent<Planet>();
        _count = Random.Range(0, _maxCount);
        StartCoroutine(Refill());
    }

    public void SetDefault(float refiilTimeInSeconds, int startCount)
    {
        _refillTime = refiilTimeInSeconds;
        _count = startCount;
    }

    public void Deploy(Planet target)
    {
        _count = (int)(_count * 0.5);
        for (int i = 0; i < _count; i++)
        {
            Ship ship = ShipPool.Instance.GetShip();
            ship.transform.position = transform.position;
            ship.gameObject.SetActive(true);
            print(_planet.PlayerId);
            print(_planet.PlayerColor);
            ship.SetPlayer(_planet.PlayerId, _planet.PlayerColor);
            ship.FlyTo(target);
        }
    }

    private IEnumerator Refill()
    {
        while(true)
        {
            yield return new WaitForSeconds(_refillTime);

            if (_count < _maxCount)
            {
                if (_planet.PlayerId != 0) Add();
            }
        }
    }

    public void Kill()
    {
        _count--;
    }

    public void Add()
    {
        _count++;
    }
}
