public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Transform player;
    public Vector3 mainLvlMinPosition;
    public Vector3 entryLvlMinPosition;
    public Vector3 mainLvlMaxPosition;
    public Vector3 entryLvlMaxPosition;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    private Vector3 velocity = Vector3.zero;
    public float doorYaxis;
    private void Update()
    {

        if (doorYaxis > player.transform.position.y)
        {
            moveToEntryLvl();
            zoom(7, 10);
        }
        else if (doorYaxis < player.transform.position.y)
        {
            moveToMainLvl();
            zoom(10, 7);
        }

        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        targetPosition.x = Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 8);

    }


    public void moveToMainLvl()
    {
        minPosition = mainLvlMinPosition;
        maxPosition = mainLvlMaxPosition;

    }

    public void moveToEntryLvl()
    {
        minPosition = entryLvlMinPosition;
        maxPosition = entryLvlMaxPosition;

    }

    public void zoom(float startSize, float targetSize)
    {
        for (float t = 0f; t < 100; t += Time.deltaTime)
        {
            float blend = t / 100;
            Camera.main.orthographicSize = Mathf.SmoothStep(startSize, targetSize, blend);
        }
    }

}
