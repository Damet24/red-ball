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
        _GuiEventBus.ChangeMenu += OnChangeGui;
        _GuiEventBus.BackGui += Back;
        ChangeGui(Guis.MainMenu);
    }

    public void HideAllGui()
    {
        foreach (Control item in GetChildren())
        {
            item.Visible = false;
        }
    }

    public void Back()
    {
        ChangeGui(PreviousGui);
    }

    public void OnChangeGui(string GuiName)
    {
        ChangeGui(GuiName);
    }

    public void ToggleUserGui ()
    {
        var userInfo = GetNode<Control>(Guis.UserInfo);
        userInfo.Visible = !userInfo.Visible;
    }

    public void ChangeGui(string GuiName)
    {
        var Gui = GetNode<Control>(GuiName);
        if (Gui != null)
        {
            HideAllGui();
            PreviousGui = CurrentGui;
            CurrentGui = GuiName;
            Gui.Visible = true;
        }
    }
}
