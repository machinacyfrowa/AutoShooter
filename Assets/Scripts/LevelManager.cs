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

    //bezpieczna odleg�o�� spawnu
    float spawnDistance = 30;

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
            //Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

            //wygeneruj randomow� pozycj� na kole o promieniu 1
            Vector2 random = Random.insideUnitCircle.normalized;

            //skonwertuj x,y na x,z i zerow� wysoko��
            Vector3 randomPosition = new Vector3(random.x, 0, random.y);

            //zwielokrotnij odleg�os� od gracza tak, �eby spawn nast�powa� poza kamer�
            randomPosition *= spawnDistance;

            //dodaj do niej pozycje gracza tak, aby nowe wsp�rz�dne by�y pozycj� wzgl�dem gracza
            randomPosition += player.position;

            //stworz nowego przeciwnika z istniej�cego prefaba, na pozycji randomPosition z rotacj� domy�ln�
            Instantiate(basherPrefab, randomPosition, Quaternion.identity);

            //wyzeruj licznik
            timeSinceSpawn = 0;
        }

        
    }
}
