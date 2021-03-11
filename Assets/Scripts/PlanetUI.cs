using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Hangar),typeof(Planet))]
public class PlanetUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    private Hangar _hangar;
    private Planet _planet;

    private void Start()
    {
        _hangar = GetComponent<Hangar>();
        _planet = GetComponent<Planet>();

        UpdateText();
    }

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (_planet.PlayerId == 0 || _planet.PlayerId == 1)
        {
            _text.text = _hangar.Count.ToString();
        } else
        {
           _text.text = "";
        }
    }
}
