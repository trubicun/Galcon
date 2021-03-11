using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBot : MonoBehaviour
{
    private int _playerId;

    private List<Planet> _botPlanets;
    private Planet[] _planets;

    //Бота писал на скорую руку

    private void Start()
    {
        _planets = FindObjectsOfType<Planet>();
    }

    private void Update()
    {
        Scan();
    }

    public void Init(int id)
    {
        _playerId = id;

        _botPlanets = new List<Planet>();
    }

    //Бота писал на скорую руку

    private void Scan()
    {
        FindBotPlanets();

        foreach(Planet botPlanet in _botPlanets)
        {
            Planet target = botPlanet;
            if (botPlanet.ShipCount > Random.Range(10, 21))
            {
                for (int i = 0; i < _planets.Length; i++)
                {
                    if (_planets[i].PlayerId != _playerId)
                    {
                        if (botPlanet.ShipCount * 0.5 >= _planets[i].ShipCount - Random.Range(2,10))
                        {
                            target = _planets[i];
                        }
                    }
                }

                if (target != botPlanet) botPlanet.Deploy(target);
            }
        }
    }

    private void FindBotPlanets()
    {
        _botPlanets.Clear();
        for(int i = 0; i < _planets.Length; i++)
        {
            if (_planets[i].PlayerId == _playerId)
            {
                _botPlanets.Add(_planets[i]);
            }
        }
    }
}
