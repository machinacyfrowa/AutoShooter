using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //pozycja gracza
    Transform player;
    //offset kamery
    Vector3 offset;
    //prêdkoœæ kamery
    Vector3 cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //linkujemy pozycje gracza do zmiennej lokalnej
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //zapisujemy aktualny offset kamery
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //policz now¹ pozycjê kamery
        Vector3 targetPosition = player.position + offset;
        //przesuñ kamerê w kierunku celu
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        
        //trzecia metoda - smoothdamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraSpeed, 0.3f);
    }
}
