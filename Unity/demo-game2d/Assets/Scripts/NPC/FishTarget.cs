using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTarget : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;

    public float rateUpdatePosition;
    public GameObject fishPrefab;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdatePosition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdatePosition()
    {
        yield return new WaitForSeconds(rateUpdatePosition * Random.Range(0.1f, 1f));
        RandomizePosition();
        StartCoroutine(UpdatePosition());
    }

    private void RandomizePosition()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(minHeight, maxHeight));

        Instantiate(fishPrefab, transform.position, Quaternion.identity);
    }
}
