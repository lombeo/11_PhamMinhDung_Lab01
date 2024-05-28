using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Nếu ngôi sao đi ra ngoài màn hình ở dưới thì vị trí sẽ trở lại ngẫu nhiên ở phía góc trên màn hình
        if(transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.y), max.y);
        }
    }
}
