using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Move : MonoBehaviour
{
    public float left, right;
    public bool isRight;
    public int speed;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var namX = transform.position.x;

        // limit mushroom
        if (namX < left)
        {

            isRight = true;
        }
        if (namX > right)
        {

            isRight = false;
        }


        if (isRight)
        {
            transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
        else
        {
            transform.Translate(new Vector3(-Time.deltaTime * speed, 0, 0));
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }
    }
}
