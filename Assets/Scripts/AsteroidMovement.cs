using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    GameObject scoreUITextGO;

    private float minSpeed = 2f;
    private float maxSpeed = 5f;
    public float rotationSpeed = 100f;

    public GameObject AsteroidExplosion;

    private float speed;
    private Vector2 direction;

    void Start()
    {
        // Tạo tốc độ ngẫu nhiên cho asteroid
        speed = Random.Range(minSpeed, maxSpeed);

        // Tạo hướng ngẫu nhiên cho asteroid (trôi xuống với một chút lệch về hai bên)
        float randomX = Random.Range(-1f, 1f);
        direction = new Vector2(randomX, -1).normalized;

        // Đặt tốc độ xoay ngẫu nhiên
        rotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);

        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    void Update()
    {
        // Di chuyển asteroid
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Xoay asteroid
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "PlayerShipTag") || (collision.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            scoreUITextGO.GetComponent<GameScore>().Score += 100;

            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(AsteroidExplosion);

        explosion.transform.position = transform.position;
        explosion.transform.rotation = transform.rotation;
    }
}
