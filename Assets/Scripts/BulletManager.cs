using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private float _speed = 4.5f;
    [SerializeField] private float _life = 4.0f;
    void Start()
    {
        Destroy(this.gameObject, this._life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
    }
    private void OnCollisonEnter2D(Collision collision)
    {
        Destroy(gameObject);
    }
}
