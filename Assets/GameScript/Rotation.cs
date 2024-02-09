using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;
    float randomNum;

    private void Start()
    {
        randomNum = Random.Range(0, 100);

    }
    private void Update()
    {

        if (randomNum <= 30)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else if (randomNum >= 30 && randomNum <= 80)
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
