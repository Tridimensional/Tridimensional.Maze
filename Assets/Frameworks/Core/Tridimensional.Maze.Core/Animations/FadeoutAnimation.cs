using Tridimensional.Maze.Core;
using Tridimensional.Maze.Core.Enums;
using UnityEngine;

public class FadeoutAnimation : MonoBehaviour
{
    public Level NextLevel { get; set; }

    float _duration = 3;
    float _percentage = 0;
    Texture2D _solidColor;

    void Awake()
    {
        _solidColor = new Texture2D(1, 1);
        _solidColor.SetPixel(0, 0, Global.ForegroundColor);
        _solidColor.Apply();
    }

    void OnGUI()
    {
        if (_percentage >= 1) { Application.LoadLevel(NextLevel.ToString()); }

        _percentage += Time.deltaTime / _duration;

        GUI.depth = -1;
        GUI.color = new Color(1, 1, 1, Mathf.Pow(_percentage, 2f));
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _solidColor);
    }
}
