using UnityEngine;
using System.Collections;

public class CameraCycle : MonoBehaviour
{
    public Transform[] cameraPoints;
    public float stayTime = 3f;
    public float moveSpeed = 2f;

    private int currentIndex = 0;

    void Start()
    {
        StartCoroutine(CycleCamera());
    }

    IEnumerator CycleCamera()
    {
        while (true)
        {
            Transform target = cameraPoints[currentIndex];

            // move smoothly to next point
            while (Vector3.Distance(transform.position, target.position) > 0.01f)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * moveSpeed);
                yield return null;
            }

            
            transform.position = target.position;
            transform.rotation = target.rotation;

            // wait 3 seconds
            yield return new WaitForSeconds(stayTime);


            currentIndex = (currentIndex + 1) % cameraPoints.Length;
        }
    }
}