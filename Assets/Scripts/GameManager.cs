using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _playerCount = 1;
    [SerializeField] private float _playersRefill = 0.2f;
    [SerializeField] private int _playersStartShips = 50;
    [SerializeField] private ColorPallete _colorPallete;

    private List<Planet> _planets;

    private void Start()
    {
        _planets = PlanetGenerator.Instance.Planets;

        for(int i = 1; i <= _playerCount; i++)
        {
            int playerPlanet = Random.Range(0, _planets.Count);

            _planets[playerPlanet].SetPlayer(i, _colorPallete.GetColor(i - 1));

            _planets[playerPlanet].GetComponent<Hangar>().SetDefault(_playersRefill,_playersStartShips);

            if (i > 1)
            {
                SimpleBot simpleBot = gameObject.AddComponent<SimpleBot>();
                simpleBot.Init(i);
            }

            _planets.RemoveAt(playerPlanet);
        }
    }

    private void OnValidate()
    {
        if (_playerCount < 1) _playerCount = 1;
        int planetCount = FindObjectOfType<PlanetGenerator>().PlanetCount;
        if (_playerCount > planetCount) _playerCount = planetCount;
        if (_playerCount > _colorPallete.Length) _playerCount = _colorPallete.Length;
    }
}
