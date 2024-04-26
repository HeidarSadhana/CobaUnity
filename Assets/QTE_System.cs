using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class QTE_System : MonoBehaviour
{
    public bool masuk;
    public Transform target;
    public Transform targetstart;
    public Transform targetend;
    public Slider progress;

    void Update()
    {
        if(progress.value < 1)
        {
            progress.value -= Time.deltaTime * 0.03f;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (masuk)
            {
                if(progress.value < 1)
                {
                    progress.value += 0.2f;
                }
                target.position = new Vector2(Random.Range(targetstart.position.x, targetend.position.x), target.position.y);

                Debug.Log("Berhasil");

            }
            else
            {
                if (progress.value > 0)
                {
                    progress.value -= 0.2f;
                }

                Debug.Log("Gagal");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        masuk = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        masuk = false;
    }

    private void OnDrawGizmos()
    {
        if (target != null && targetstart != null && targetend != null)
        {
            Gizmos.DrawLine(target.transform.position, targetstart.position);
            Gizmos.DrawLine(target.transform.position, targetend.position);
        }
    }
}
