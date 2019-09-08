using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move Directions", menuName = "Move Directions")]
public class PlayerShape : ScriptableObject
{
    public ERotationAngle type;

    public Sprite[] clockwiseSprites;
    public Sprite[] counterClockwiseSprites;
    public Sprite[] deathSprites;

    public float[] angles = new float[] {
        0,
        90,
        180,
        270
    };
}
