using Godot;
using System;

public partial class HeartGI : HBoxContainer
{
    private int PlayerLives = 3;

    private Texture2D TextureHearth = ResourceLoader.Load<Texture2D>("res://assets/sprites/hud_items.png");

    public override void _Ready()
    {
        var playerEventBus = GetNode<PlayerEventBus>("/root/PlayerEventBus");
        playerEventBus.IsDeath += OnDeath;
        playerEventBus.SetLives += OnSetLives;
		UpdateLivesHud(PlayerLives);
    }

    private void OnSetLives(int Lives)
    {
        PlayerLives = Lives;
		UpdateLivesHud(Lives);
        GD.Print("Porqe no se esta ejecutando esta mandá " + Lives);
    }

    private void OnDeath(int Lives)
    {
        PlayerLives = Lives;
    }

    private TextureRect CreateHeart(int Index)
    {
        var HeartSprite = new AtlasTexture();
        HeartSprite.Atlas = TextureHearth;
        HeartSprite.Region = new Rect2(0, 0, 16, 16);
        var Heart = new TextureRect();
        Heart.Texture = HeartSprite;
        Heart.StretchMode = TextureRect.StretchModeEnum.KeepAspectCentered;
        Heart.Name = "Hart" + Index;
        return Heart;
    }

    private void AddHeartToUi(TextureRect Texture)
    {
        AddChild(Texture);
    }

    private void RemoveHeartOnUi(int NewLives)
    {
        var diff = PlayerLives - NewLives;
        for (int i = 0; i < diff; i++)
        {
            RemoveChild(GetNode("Heart" + (i + 1)));
        }
    }

    private void UpdateLivesHud(int NewLives)
    {
        var HeartOnUi = GetChildCount();
        if (HeartOnUi > 0)
        {
			RemoveHeartOnUi(NewLives);
        }

		for (int i = 0; i < NewLives; i++)
		{
			AddHeartToUi(CreateHeart(i));
		}
    }
}
