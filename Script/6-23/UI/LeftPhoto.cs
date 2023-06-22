using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LeftPhoto : MonoBehaviour
{
    public Text text;
    public bool TruePhoto;
    private void Update()
    {
        if (TruePhoto)
            Tag();
        else
            Tag2();
    }

    void Tag()
    {
        if (DontDestory.photoCount > 0 && DontDestory.photoCount < 7)
        {
            text.text = (" : " + (DontDestory.photoCount));
        }
        else if (DontDestory.photoCount == 0)
        {
            text.text = (" : 0");
        }
        else
        {
            text.text = ("");
        }
    }

    void Tag2()
    {
        if (DontDestory.illgeeCount > 0 && DontDestory.illgeeCount < 7)
        {
            text.text = (" : " + (DontDestory.illgeeCount));
        }
        else if (DontDestory.illgeeCount == 0)
        {
            text.text = (" : 0");
        }
        else
        {
            text.text = ("");

        }
    }
}
