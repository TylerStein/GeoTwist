using UnityEngine;
using UnityEngine.Events;

public class HeldButtonBehaviour : MonoBehaviour
{
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            onActivate.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Button TriggerExit: " + collision.name);
        if (collision.tag == "Player") {
            onDeactivate.Invoke();
        }
    }
}
