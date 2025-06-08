using UnityEngine;

[CreateAssetMenu (menuName = "ScriptableObjects/UI/UIDataSO")]
public class UIDataSO : ScriptableObject
{
    public UI_MainMenu UI_MainMenuCanvas;
    public UI_Level UI_LevelCanvas;
    public UI_Pause UI_PauseCanvas;
    public UI_End UI_EndCanvas;
}
