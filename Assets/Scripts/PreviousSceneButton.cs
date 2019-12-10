using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousSceneButton : MonoBehaviour
{
    public void BackToMenu()
    {
        Loader.Load(Loader.Scene.Menu);
    }

    public void BackToShop()
    {
        Loader.Load(Loader.Scene.Shop);
    }
}

