using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Camera _camera;

    private List<Planet> _planets;

    private RaycastHit _hit;

    private void Start()
    {
        _camera = Camera.main;
        _planets = new List<Planet>();
    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _hit)) 
            {
                Planet planet = _hit.collider.GetComponent<Planet>();
                if (planet && !planet.Selected && planet.PlayerId == 1)
                {
                    planet.Select();
                    _planets.Add(planet);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _hit))
            {
                Planet target = _hit.collider.GetComponent<Planet>();
                if (target)
                {
                    foreach (Planet planet in _planets)
                    {
                        planet.Deploy(target);
                    }
                }
            }

            foreach (Planet planet in _planets)
            {
                planet.UnSelect();
            }

            _planets.Clear();
        }
    }
}
