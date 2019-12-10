using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneUI : MonoBehaviour
{
   public void SceneOptionsSwitch ()
    {
        Loader.Load(Loader.Scene.Options);
    }

    public void ScenePlayMenuSwitch()
    {
        Loader.Load(Loader.Scene.PlayMenu);
    }

    public void SceneShopSwitch()
    {
        Loader.Load(Loader.Scene.Shop);
    }

    public void SceneLeaderboardSwitch()
    {
        Loader.Load(Loader.Scene.Leaderboard);
    }
}
