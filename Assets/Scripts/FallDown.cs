using UnityEngine;

public class FallDown : MonoBehaviour
{
    [SerializeField]
    private float fallSpeed = 3f;

    void Update()
    {
        if (transform.position.y < -6f)
            gameObject.SetActive(false);
        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }
}
