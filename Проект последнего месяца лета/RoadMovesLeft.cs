using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadMovesLeft : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestoyPlatformPlace")
        {
            Destroy(gameObject);
        }
    }
    /*-----------------------------Not used code or Alternative-------------------------------------------------

            ---------------------------------Не подходит----------------------------------
            public float destroyTime = 20f; не подходит для игры где игрoк остонавливается и неудобно
            private void Start()
            {
                Destroy(gameObject, destroyTime);
            }

            ----------------------------Нужно доработать----------------------------------
            private void OnBecameInvisible() <- Надо точно обозначить границы камеры скорее всего, платформы
            {                                   уже далеко за камерой игрока, но удаляются очень далеко за границами
                Destroy(gameObject);
            }

            ---------------------Замедления платформ херово работающее--------------------
            private float _slowDown = 0.2f;
            if (Input.GetKeyDown(KeyCode.E)) <- заменить на код который раз в n секунд будет уменьшать скорость
            {
                speed = speed - _slowDown; <- надо создать лимит, который не дасть скорости уйти в минус
            }
    */

    //-------------------------------------------------------------------------------------------------------
}
