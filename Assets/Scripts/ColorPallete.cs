using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ColorPallete", menuName = "ColorPallete", order = 51)]
public class ColorPallete : ScriptableObject
{
    [SerializeField] private List<Color> _colors;

    public Color GetColor(int playerId)
    {
        return _colors[playerId];
    }
}
