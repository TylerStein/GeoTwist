using UnityEngine;
using UnityEngine.Events;

public class SetSpawnTrigger : MonoBehaviour
{
    public Transform spawnTransform;
    public PlayerShape spawnShape = null;
    public int spawnDirection = 0;
    public bool spawnClockwise = true;

    public UnityEvent onReset = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
            player.spawnTrigger = this;

            Transform spawn = spawnTransform == null ? gameObject.transform : spawnTransform;
            player.setSpawnTransform(spawn);
            player.setSpawnShape(spawnShape, spawnDirection, spawnClockwise);
        }
    }

    public void onRespawn() {
        onReset.Invoke();
    }
}
