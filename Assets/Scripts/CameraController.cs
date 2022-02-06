using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject canvas;
    private float currentPosX;
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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
                canvas.SetActive(true);
                pauseMenu.SetActive(true);
            }
        }
    }
}
