using UnityEngine;

public class SpaceBackgroundParallax : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    [SerializeField] float resetXPosition = -4f;
    [SerializeField] float startXPosition = 4f;

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= resetXPosition)
        {
            transform.position = new Vector3(startXPosition, transform.position.y, transform.position.z);
        }
    }
}
