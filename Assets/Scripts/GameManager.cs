using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _playerCount = 1;
    [SerializeField] private ColorPallete _colorPallete;

    private List<Planet> _planets;

    private void Start()
    {
        _planets = PlanetGenerator.Instance.Planets;

        for(int i = 0; i < _playerCount; i++)
        {
            int playerPlanet = Random.Range(0, _planets.Count);

            _planets[playerPlanet].SetPlayer(i, _colorPallete.GetColor(i));

            _planets.RemoveAt(playerPlanet);
        }
    }

    private void OnValidate()
    {
        if (_playerCount < 1) _playerCount = 1;
        int planetCount = FindObjectOfType<PlanetGenerator>().PlanetCount;
        if (_playerCount > planetCount) _playerCount = planetCount;
    }
}
