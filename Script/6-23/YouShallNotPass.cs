using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouShallNotPass : MonoBehaviour        //���׷� ��������
{
    public GameObject KeiKai;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SomethingToDo());
        }
    }

    IEnumerator SomethingToDo()
    {
        KeiKai.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);        //WaitSomethingToDo

        KeiKai.SetActive(false);

        yield return null;
    }
}
