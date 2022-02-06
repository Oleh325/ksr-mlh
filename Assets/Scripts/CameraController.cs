using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject background;
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
            background.transform.position = new Vector3(player.position.x, background.transform.position.y, background.transform.position.z);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
                canvas.SetActive(true);
                pauseMenu.SetActive(true);
            }
        }
    }
}
