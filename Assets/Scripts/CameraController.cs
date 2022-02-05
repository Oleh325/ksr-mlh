using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    private bool isLevelOn;

    private void Awake()
    {
        Pause();
    }

    public void Play()
    {
        isLevelOn = true;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        isLevelOn = false;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (isLevelOn)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
