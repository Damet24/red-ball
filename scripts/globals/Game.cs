using Godot;
using System;

public partial class Game : Node2D
{
    private GameEventBus _GameEventBus;
    private LevelControl _LevelControl;
    private GuiEventBus _GuiEventBus;

    public bool InGame = false;
    public bool IsPaused = false;

    public override void _Ready()
    {
        _GameEventBus = GetNode<GameEventBus>("/root/GameEventBus");
        _GameEventBus.StartGame += OnStartGame;
        _GameEventBus.ResumeGame += ResumeGame;
        _LevelControl = GetNode<LevelControl>("/root/LevelControl");
        _GuiEventBus = GetNode<GuiEventBus>("/root/GuiEventBus");
    }

    public override void _Process(double delta)
    {
        if (InGame)
        {
            if (Input.IsActionJustPressed("ui_cancel"))
            {
                if (!IsPaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }
    }

    public void ResumeGame()
    {
        GetTree().Paused = false;
        IsPaused = false;
        _GuiEventBus.EmitHideAll(true);
        _GuiEventBus.EmitChangeMenu(Guis.UserInfo);
    }

    public void PauseGame()
    {
        GetTree().Paused = true;
        IsPaused = true;
        _GuiEventBus.EmitChangeMenu(Guis.InGameMainMenu, true);
    }

    private void OnStartGame(string LevelName)
    {
        InGame = true;
        _GuiEventBus.EmitHideAll();
        _GuiEventBus.EmitChangeMenu(Guis.UserInfo);
        _LevelControl.EmitChangeLevelSignal(LevelName);
    }

    public void ToggleProccessGame()
    {
        GetTree().Paused = !GetTree().Paused;
    }
}
