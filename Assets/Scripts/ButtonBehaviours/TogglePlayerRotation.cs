using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    public void toggleRotation() {
        player.toggleRotationDirection();
    }

    public void setRotation(bool clockwise) {
        player.setRotationDirection(clockwise);
    }
}
