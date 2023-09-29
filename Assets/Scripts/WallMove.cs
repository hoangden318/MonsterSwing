using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected float Miny = -1.09f;
    [SerializeField] protected float Maxy = 1.09f;

    [SerializeField] protected float startPs = 10f;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
 
    }

    // Update is called once per frame
    void Update()
    {
        this.WallMov();
    }

    protected virtual void WallMov()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0f, 0f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ResetWall"))
        {
            obj.transform.position = new Vector3(startPs, Random.Range(Miny, Maxy + 1.03f), 0f);
        }
        
    }
}
