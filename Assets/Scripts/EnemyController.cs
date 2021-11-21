using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    bool broken = true;
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Animator animator;
    Rigidbody2D rigidbody2D;

    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);

    }

    void OnCollisionStay2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
    }

}




//public class EnemyController : MonoBehaviour
//{
//    public float speed = 3  .0f;
//    int direction = -1;
//    Rigidbody2D rigidbody2d;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rigidbody2d = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector2 position = rigidbody2d.position;

//        if(position.y <= 0.8)
//        {
//            direction = 1;
//        }
//        else if(position.y >= 2.4)
//        {
//            direction = -1;
//        }
//        position.y = position.y + speed * Time.deltaTime * direction;
//        rigidbody2d.MovePosition(position);
//    }
//}
