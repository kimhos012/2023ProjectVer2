using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouShallNotPass : MonoBehaviour        //버그로 수정당함
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
