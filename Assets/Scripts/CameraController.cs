using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    public Vector2 mainLvlMinPosition;
    public Vector2 entryLvlMinPosition;
    public Vector2 mainLvlMaxPosition;
    public Vector2 entryLvlMaxPosition;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    private Vector3 velocity = Vector3.zero;
    public float doorYaxis;
    public float mainLvlSize=10;
    public float entryLvlSize=7;
    private void Update()
    {

        if (doorYaxis > player.transform.position.y)
        {
            moveToEntryLvl();
            zoom(entryLvlSize, mainLvlSize);
        }
        else if (doorYaxis < player.transform.position.y)
        {
            moveToMainLvl();
            zoom(mainLvlSize, entryLvlSize);
        }

        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        targetPosition.x = Mathf.Clamp(player.position.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(player.position.y, minPosition.y, maxPosition.y);

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
