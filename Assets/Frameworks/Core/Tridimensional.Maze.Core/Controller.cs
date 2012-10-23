using Tridimensional.Maze.Core.Enums;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool Fadein;
    public bool Fadeout;

    bool _added;

    void Awake()
    {
        if (Fadein)
        {
            gameObject.AddComponent<FadeinAnimation>();
        }

        SendMessage("Init", SendMessageOptions.DontRequireReceiver);
    }

    protected void LoadLevel(Level level)
    {
        if (!Fadeout)
        {
            Application.LoadLevel(level.ToString());
        }
        else if (!_added)
        {
            gameObject.AddComponent<FadeoutAnimation>().NextLevel = level;

            _added = true;
        }
    }
}
