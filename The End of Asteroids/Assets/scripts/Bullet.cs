using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    const float BulletLive = 2f;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = BulletLive;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyForce(Vector2 direction)
    {
        const float ForceMagnitude = 10f;
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(ForceMagnitude * direction, ForceMode2D.Impulse);
    }
}
