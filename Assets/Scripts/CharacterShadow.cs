using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShadow : MonoBehaviour
{
    public GameObject triangleObject;
    public GameObject squareObject;
    public GameObject octagonObject;

    public void setShape(ERotationAngle shape) {
        triangleObject.SetActive(false);
        squareObject.SetActive(false);
        octagonObject.SetActive(false);

        switch(shape) {
            case ERotationAngle.TRIANGLE:
                triangleObject.SetActive(true);
                break;
            case ERotationAngle.SQUARE:
                squareObject.SetActive(true);
                break;
            case ERotationAngle.OCTAGON:
                octagonObject.SetActive(true);
                break;
        }
    }
}
