using UnityEngine;
using UnityEngine.Events;

public class ToggleButtonBehaviour : MonoBehaviour
{
    public UnityEvent onToggle;

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            onToggle.Invoke();
        }
    }
}
