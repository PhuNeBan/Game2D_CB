using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Fly : MonoBehaviour
{
    public float cao, thap;
    public bool isMax;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var namX = transform.position.y;

        // limit mushroom
        if (namX > cao)
        {
            isMax = true;
        }
        if (namX < thap)
        {
            isMax = false;
        }


        if (isMax)
        {
            transform.Translate(new Vector3(0, -Time.deltaTime * speed, 0));
        }
        else
        {
            transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
        }
    }
}
