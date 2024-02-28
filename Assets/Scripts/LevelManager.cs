using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //pozycja gracza
    Transform player;

    //prefab przeciwnika
    public GameObject basherPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //zlinkuj aktualna pozycje gracza do zmiennej transform
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //wygeneruj losow¹ pozycje
        Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0 , Random.Range(-10, 10));

        //dodaj do niej pozycje gracza tak, aby nowe wspó³rzêdne by³y pozycj¹ wzglêdem gracza
        randomPosition += player.position;

        //stworz nowego przeciwnika z istniej¹cego prefaba, na pozycji randomPosition z rotacj¹ domyœln¹
        Instantiate(basherPrefab, randomPosition, Quaternion.identity);
    }
}
