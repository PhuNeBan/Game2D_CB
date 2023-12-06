using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //nhân vật
    public GameObject player;
    //điểm bắt đầu và kết thúc của màn chơi
    public float start, end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //lấy thông tin của nhân vật
        var playerX = player.transform.position.x;
        var playerY = player.transform.position.y;



        //lấy vị trí camera
        var camX = transform.position.x;
        var camY = transform.position.y;
        var camZ = transform.position.z;

        //print(camX + " và" + camY);
        //nếu người chơi ở trong khoảng có thể chạy được
        if (playerX >= start && playerX <= end)
        {
            camX = playerX;

        }
        camY = playerY;
        if (playerY < 0)
        {
            camY = 0;
        }

        //gán vị trí vào camera
        transform.position = new Vector3(camX, camY, camZ);
    }
}
