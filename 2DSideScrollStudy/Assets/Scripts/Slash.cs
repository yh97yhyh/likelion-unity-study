using UnityEngine;

public class Slash : MonoBehaviour
{
    private GameObject player;

    Vector2 MousePos;
    Vector3 dir;

    float angle;
    Vector3 dirNo;

    public Vector3 direction = Vector3.right;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Transform tr = player.GetComponent<Transform>();
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector3 pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = pos - tr.position;

        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // 바라보는 각도 구하기
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.position = player.transform.position;
    }

    public void MyDestroy()
    {
        Destroy(gameObject);
    }
}
