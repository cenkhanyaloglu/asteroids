
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// An asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // set random sprite for asteroid
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = asteroidSprite0;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = asteroidSprite1;
        }
        else
        {
            spriteRenderer.sprite = asteroidSprite2;
        }
    }

    public void Initialize(Direction direction, Vector3 location)
    {
        transform.position = location;

        float angle = Random.Range(0, Mathf.PI / 2);
        if (direction == Direction.Up)
        {
            angle += 45 * Mathf.Deg2Rad;
        }
        else if (direction == Direction.Right)
        {
            angle += -45 * Mathf.Deg2Rad;
        }
        else if (direction == Direction.Down)
        {
            angle += -135 * Mathf.Deg2Rad;
        }
        else if (direction == Direction.Left)
        {
            angle += -225 * Mathf.Deg2Rad;
        }
        StartMoving(angle);
    }

    public void StartMoving(float angle)
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;

        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);

            //Destroys bullet
            Destroy(collision.gameObject);
            if (gameObject.transform.localScale.x <= 0.5)
            {
                Destroy(gameObject);
            }
            else
            {
                //Make the asteroid split in half
                Vector3 scale = gameObject.transform.localScale;
                scale.x /= 2;
                scale.y /= 2;
                gameObject.transform.localScale = scale;
                GetComponent<CircleCollider2D>().radius /= 2;
            }
        }
    }
}
