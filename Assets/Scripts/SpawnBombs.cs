using System.Collections;
using UnityEngine;

public class SpawnBombs : MonoBehaviour
{
    [SerializeField] private int poolCount = 5;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private FallDown prefab;

    private PoolObjects<FallDown> pool;

    void Start()
    {
        this.pool = new PoolObjects<FallDown>(this.prefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(!Player.lose)
        {
            pool.GetFreeElement().gameObject.transform.position = new Vector2(Random.Range(-2.5f, 2.5f), 5.9f);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
