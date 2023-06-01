using Godot;
using System;

public partial class GuiControl : Control
{
    public GuiEventBus _GuiEventBus;
    public string PreviousGui = "";
    public string CurrentGui = Guis.MainMenu;

    public override void _Ready()
    {
        _GuiEventBus = GetNode<GuiEventBus>("/root/GuiEventBus");
        _GuiEventBus.BackGui += Back;
        _GuiEventBus.HideAll += OnHideAll;
        _GuiEventBus.ChangeMenu += OnChangeGui;
        ChangeGui(Guis.MainMenu);
    }

    public void SetBackground(bool index)
    {
        var Background = GetNode<Control>("Background");
        Background.Visible = index;
    }

    public void HideAllGui(bool background)
    {
        foreach (Control item in GetChildren())
        {
            if (item.Name != "Background") item.Visible = false;
            else if (background) item.Visible = false;
        }
    }

    private void OnHideAll(bool background)
    {
        HideAllGui(background);
    }

    public void Back()
    {
        ChangeGui(PreviousGui);
    }

    public void OnChangeGui(string GuiName, bool WihtBackground)
    {
        SetBackground(WihtBackground);
        ChangeGui(GuiName);
    }

    public void ToggleUserGui()
    {
        var userInfo = GetNode<Control>(Guis.UserInfo);
        userInfo.Visible = !userInfo.Visible;
    }

    public void ChangeGui(string GuiName)
    {
        var Gui = GetNode<Control>(GuiName);
        if (Gui != null)
        {
            HideAllGui(false);
            PreviousGui = CurrentGui;
            CurrentGui = GuiName;
            Gui.Visible = true;
        }
    }
}
