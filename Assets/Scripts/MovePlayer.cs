using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private float speed = 10f;

    void OnMouseDrag()
    {
        if (!Player.lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < -2.5f)
            {
                mousePos.x = -2.5f;
            }
            else
            {
                mousePos.x = mousePos.x;
            }

            if (mousePos.x > 2.5f)
            {
                mousePos.x = 2.5f;
            }
            else
            {
                mousePos.x = mousePos.x;
            }

            player.position = Vector2.MoveTowards(player.position, new Vector2(mousePos.x, player.position.y),
                speed * Time.deltaTime);
        }

    }
}
