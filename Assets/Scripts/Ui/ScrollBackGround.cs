using UnityEngine;
using UnityEngine.UI;

public class ScrollBackGround : MonoBehaviour
{
    [SerializeField] private float speed;
    private float repeatWidth;
    private Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y / 2;
    }
    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}