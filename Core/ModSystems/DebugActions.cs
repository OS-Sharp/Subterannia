﻿using Terraria.ModLoader;
using Terraria;
using Humanizer;
using Microsoft.Xna.Framework;
using Subterannia.Core.Subworlds;
using Subterannia.Core.Subworlds.LinuxSubworlds;
using Microsoft.Xna.Framework.Graphics;
using Subterannia.Core.Utility;
using ReLogic.Content;

public class DebugActions : ModSystem
{
    public override void Load()
    {
        On_Main.DoUpdate += Update;
        On_Main.DrawWoF += Draw;
    }

    private void Update(On_Main.orig_DoUpdate orig, Main self, ref GameTime gameTime)
    {
        orig(self, ref gameTime);
        if (Main.gameMenu) return;

        if (Main.LocalPlayer.controlHook)
        {
            if(!Main.LocalPlayer.GetModPlayer<SubworldPlayer>().InSubworld)
            {
                //SubworldManager.EnterSubworld<CutsceneSubworld>();
            }
            else
            {
                SubworldManager.ReturnToMainWorld();
            }
            Main.LocalPlayer.controlHook = false;
        }

        //TODO: Make 672 Util magic no.
        if (Main.LocalPlayer.position.Y >= Main.bottomWorld - 672f - Main.LocalPlayer.height && !Main.LocalPlayer.GetModPlayer<SubworldPlayer>().InSubworld)
        {
            SubworldManager.EnterSubworld<CutsceneSubworld>();
        }
    }

    private void Draw(On_Main.orig_DrawWoF orig, Main self)
    {
        orig(self);

        if (Main.gameMenu) return; 
    }
}