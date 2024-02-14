using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pobierz stan kontrolera (poziom)
        float x = Input.GetAxis("Horizontal");
        //wylicz docelowy ruch poziomo (lewo/prawo po osi x) mno¿¹c wychylenie kontrolera przez "1" oraz czas od ostatniej klatki
        Vector3 movement = Vector3.right * x * Time.deltaTime;

        //pobierz stan kontrolera (pion)
        float y = Input.GetAxis("Vertical");
        movement += Vector3.forward * y * Time.deltaTime;

        //normalizuj ruch
        movement = movement.normalized;

        //pomnó¿ ruch przez prêdkoœæ
        movement *= moveSpeed;

        //na³ó¿ zmianê po³o¿enia na obiekt gracza
        transform.position += movement;
        
    }
}
