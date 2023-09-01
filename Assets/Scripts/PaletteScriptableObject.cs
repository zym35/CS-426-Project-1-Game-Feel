using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PaletteScriptableObject", order = 1)]
public class PaletteScriptableObject : ScriptableObject
{
    public List<Color> backgroundColors = new List<Color>()
    {
        new (249f / 255f, 237f / 255f, 105f / 255f),
        new (54 / 255f, 79 / 255f, 107 / 255f),
        new (168f / 255f, 216f / 255f, 234f / 255f),
        new (240f / 255f, 245f / 255f, 249f / 255f)
    };

    public List<Color> squareColors = new List<Color>()
    {
        new(240 / 255f, 138 / 255f, 93 / 255f),
        new(63 / 255f, 193 / 255f, 201 / 255f),
        new(170 / 255f, 150 / 255f, 218 / 255f),
        new(201 / 255f, 214 / 255f, 223 / 255f)
    };
    
    public List<Color> circleColors = new List<Color>()
    {
        new(184 / 255f, 59 / 255f, 94 / 255f),
        new(245 / 255f, 245 / 255f, 245 / 255f),
        new(252 / 255f, 186 / 255f, 211 / 255f),
        new(82 / 255f, 97 / 255f, 107 / 255f)
    };
    
    public List<Color> clickColors = new List<Color>()
    {
        new(106 / 255f, 44 / 255f, 112 / 255f),
        new(252 / 255f, 81 / 255f, 133 / 255f),
        new(255 / 255f, 255 / 255f, 210 / 255f),
        new(30 / 255f, 32 / 255f, 34 / 255f)
    };
}
