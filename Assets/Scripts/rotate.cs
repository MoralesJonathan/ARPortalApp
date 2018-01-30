using UnityEngine;

public class rotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * 10);
    }
}
