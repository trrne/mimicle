using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Self
{
    public static class Constant
    {
        public enum Sindex
        {
            Title = 0,
            Main = 1
        }

        public static readonly string
        Main = "Main",
        Title = "Title";

        public static readonly string
        Horizontal = "Horizontal",
        Vertical = "Vertical",
        Fire = "Fire",
        Reload = "Reload",
        Parry = "Parry",
        Menu = "Menu",
        VUp = "VUp",
        VDown = "VDown",
        ChangeWeapon1 = "ChangeWeapon1",
        ChangeWeapon2 = "ChangeWeapon2",
        ChangeLogo = "ChangeLogo",

        Jump = "Jump",
        MouseX = "Mouse X",
        MouseY = "Mouse Y",
        Volume = "Volume";

        public static readonly string
        Player = "Player",
        Enemy = "Enemy",
        Safety = "LifeZone",
        Dark = "Dark",
        Manager = "Manager",
        Charger = "Charger",
        LilC = "LilC",
        PlayerBullet = "Bullet",
        PlayerRocket = "RocketLauncher",
        Logo = "Logo",
        Boss = "Boss",
        TriggerZone = "TriggerArea",
        EnemyBullet = "EnemyBullet",
        WaveManager = "WaveManager",
        UpgradeItem = "Upgrade",
        Ring = "Ring",
        Canvas = "Canvas";

        public readonly struct Damage
        {
            public static int[] Player = { 25, 30, 35 };
            public static int PlayerRocket = 33;
            public static int Charger = 5;
            public static int LilC = 10;
            public static int BigC = 5;
            public static int Spide = 19;
            public static int Shuriken = 11;
            public static int Ring = 33;
            public static int[] Horming = { 0, 7, 9, 11, 15 };
        }

        public readonly struct Point
        {
            public static int Charger = 100;
            public static int LilC = 500;
            public static int BigC = 500;
            public static int Boss = 10000;
            public static int Spide = 250;
            public static int Ninja = 400;

            public static int RedCharger = -10;
            public static int RedLilC = -100;
            public static int RedLilCBullet = -10;
            public static int RedBigCBullet = -10;
            public static int RedHoming = -10;
            public static int RedSpide = -50;
            public static int RedShuriken = -10;
        }

        public readonly struct Key
        {
            public static KeyCode Reload = KeyCode.LeftShift;
            public static KeyCode Fire = KeyCode.Space;
            public static KeyCode Mute = KeyCode.M;
            public static KeyCode Stop = KeyCode.Backspace;
            public static KeyCode VUp = KeyCode.UpArrow;
            public static KeyCode VDown = KeyCode.DownArrow;
            public static KeyCode MChange = KeyCode.LeftArrow;
            public static KeyCode Parry = KeyCode.E;
        }

    }
}