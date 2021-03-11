using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    [SerializeField] private bool _isAuto;
    [SerializeField] private Planet _planet;
    [SerializeField, Header("Planet Settings")] private int _planetCount;
    [SerializeField] private float _height;
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private List<Planet> _planets;

    public bool IsAuto { get => _isAuto; }
    public List<Planet> Planets { get => _planets; }
    public int PlanetCount { get => _planetCount; }

    public static PlanetGenerator Instance;


    private void Awake()
    {
        Instance = this;
    }

    public void GeneratePlanetsInEditor()
    {
        DeleteChilds(transform);
        _planets = GeneratePlanets(transform, _planet, _planetCount, _height, _minScale,_maxScale);
    }

    private void DeleteChilds(Transform obj)
    {
        var tempArray = new GameObject[obj.transform.childCount];

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = obj.transform.GetChild(i).gameObject;
        }

        foreach (var child in tempArray)
        {
            DestroyImmediate(child);
        }

    }

    private List<Planet> GeneratePlanets(Transform parent, Planet planetPrefab, int count, float height, float minScale, float maxScale)
    {
        List<Planet> planets = new List<Planet>(); 

        for(int i = 0; i < count; i++)
        {
            Planet createdPlanet = Instantiate(planetPrefab, parent);

            createdPlanet.transform.localScale *= Random.Range(minScale, maxScale);

            float createdRadius = createdPlanet.transform.localScale.x * 0.5f;

            bool isCorrect = false;

            do
            {
                isCorrect = true;

                foreach (Planet planet in planets)
                {
                    float radius = planet.transform.localScale.x + createdRadius;

                    if (Vector3.Distance(planet.transform.position, createdPlanet.transform.position) < radius)
                    {
                        Vector2 orbit = GetRandomPointOnOrbit(planet, planet.transform.localScale.x + radius);
                        createdPlanet.transform.position = planet.transform.position + new Vector3(orbit.x,Random.Range(-height,height), orbit.y);

                        isCorrect = false;
                        break;
                    }
                }

            } while (!isCorrect);

            planets.Add(createdPlanet);
        }

        return planets;
    }

    private Vector2 GetRandomPointOnOrbit(Planet planet, float radius)
    {
        Vector2 planetPoint = new Vector2(planet.transform.position.x, planet.transform.position.z);
        Vector2 orbit = planetPoint + Random.insideUnitCircle.normalized * radius;
        return orbit == Vector2.zero ? Vector2.one : orbit;
    }

    private void OnValidate()
    {
        if (_planetCount < 2) _planetCount = 2;
        if (_height < 0) _height = 0;
        if (_minScale < 0) _minScale = 0;
        if (_maxScale < 0) _maxScale = 0.1f;
    }
}
