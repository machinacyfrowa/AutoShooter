using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //pozycja gracza
    Transform player;

    //prefab przeciwnika
    public GameObject basherPrefab;

    //czas od ostatniego respawnu
    float timeSinceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //zlinkuj aktualna pozycje gracza do zmiennej transform
        player = GameObject.FindWithTag("Player").transform;

        //zerujemy licznik
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //dodaj do czasu od ostatniego spawnu czas od ostatniej klatki (ostatni update())
        timeSinceSpawn += Time.deltaTime;

        //je�eli d�u�ej ni� jedna sekunda
        if(timeSinceSpawn > 1)
        {
            //wygeneruj losow� pozycje
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

            //dodaj do niej pozycje gracza tak, aby nowe wsp�rz�dne by�y pozycj� wzgl�dem gracza
            randomPosition += player.position;

            //stworz nowego przeciwnika z istniej�cego prefaba, na pozycji randomPosition z rotacj� domy�ln�
            Instantiate(basherPrefab, randomPosition, Quaternion.identity);

            //wyzeruj licznik
            timeSinceSpawn = 0;
        }

        
    }
}
