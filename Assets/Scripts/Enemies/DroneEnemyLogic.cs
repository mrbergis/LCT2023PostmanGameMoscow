using System;
using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class DroneEnemyLogic : MonoBehaviour
    {
        [SerializeField] private Transform startPoint, endPoint;


        [SerializeField]
        [Range(0, 25)]
        private float MoveSpeed = 1f;

        private Coroutine LerpCoroutine;
        
        private void Start()
        {
            if (LerpCoroutine != null)
            {
                StopCoroutine(LerpCoroutine);
            }
            
            LerpCoroutine = StartCoroutine(LerpRectFixedSpeed());
        }

        private void Update()
        {
            
        }

        private IEnumerator LerpRectFixedSpeed()
        {
            transform.rotation = Quaternion.identity;

            while (true)
            {
                Flip();
                float distance = Vector3.Distance(startPoint.position, endPoint.position);
                float remainingDistance = distance;
                while (remainingDistance > 0)
                {
                    transform.position = Vector3.Lerp(startPoint.position, endPoint.position, 1 - (remainingDistance / distance));
                    remainingDistance -= MoveSpeed * Time.deltaTime;
                    yield return null;
                }

                Flip();
                remainingDistance = distance;
                while (remainingDistance > 0)
                {
                    transform.position = Vector3.Lerp(startPoint.position, endPoint.position, remainingDistance / distance);
                    remainingDistance -= MoveSpeed * Time.deltaTime;
                    yield return null;
                }
            }
        }

        private void Flip()
        {
            Vector3 localScale = transform.localScale;
            localScale.z *= -1;
            transform.localScale = localScale;
        }


    }
}
