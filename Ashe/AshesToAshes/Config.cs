﻿using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK;


// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace AshesToAshes
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "AshesToAshes";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Hoşgeldin AshesToAshes by TopGunner");

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }


        public static class Misc
        {

            private static readonly Menu Menu;
            public static readonly CheckBox _drawW;
            private static readonly CheckBox _ksW;
            private static readonly CheckBox _useAutoW;
            private static readonly CheckBox _useAutoE;
            private static readonly CheckBox _useHeal;
            private static readonly CheckBox _useQSS;
            private static readonly CheckBox _autoBuyStartingItems;
            private static readonly CheckBox _autolevelskills;
            private static readonly Slider _skinId;
            public static readonly CheckBox _useSkinHack;
            private static readonly CheckBox[] _useHealOn = { new CheckBox("", false), new CheckBox("", false), new CheckBox("", false), new CheckBox("", false), new CheckBox("", false) };

            public static bool useHealOnI(int i)
            {
                return _useHealOn[i].CurrentValue;
            }
            public static bool ksW
            {
                get { return _ksW.CurrentValue; }
            }
            public static bool useAutoW
            {
                get { return _useAutoW.CurrentValue; }
            }
            public static bool useE
            {
                get { return _useAutoE.CurrentValue; }
            }
            public static int autoWMana
            {
                get { return Menu["autoWMana"].Cast<Slider>().CurrentValue; }
            }
            public static bool useHeal
            {
                get { return _useHeal.CurrentValue; }
            }
            public static bool useQSS
            {
                get { return _useQSS.CurrentValue; }
            }
            public static bool autoBuyStartingItems
            {
                get { return _autoBuyStartingItems.CurrentValue; }
            }
            public static bool autolevelskills
            {
                get { return _autolevelskills.CurrentValue; }
            }
            public static int skinId
            {
                get { return _skinId.CurrentValue; }
            }
            public static bool UseSkinHack
            {
                get { return _useSkinHack.CurrentValue; }
            }


           static Misc()
            {
                // Initialize the menu values
                Menu = Config.Menu.AddSubMenu("Misc");
                _drawW = Menu.Add("drawW", new CheckBox("Göster W"));
                Menu.AddSeparator();
                _ksW = Menu.Add("ksW", new CheckBox("W ile akıllıca ks at"));
                _useAutoW = Menu.Add("useAutoW", new CheckBox("W otomatik kullan eğer"));
                Menu.Add("autoWMana", new Slider("manam şundan fazla ise > ({0}%)", 80));
                _useAutoE = Menu.Add("useAutoE", new CheckBox("Kullan E"));
                Menu.AddSeparator();
                _useHeal = Menu.Add("useHeal", new CheckBox("Kullan Heal Akıllıca"));
                _useQSS = Menu.Add("useQSS", new CheckBox("Kullan QSS"));
                Menu.AddSeparator();
                for (int i = 0; i < EntityManager.Heroes.Allies.Count; i++)
                {
                    _useHealOn[i] = Menu.Add("useHeal" + i, new CheckBox("Kullan Heal Korumak için dostları " + EntityManager.Heroes.Allies[i].ChampionName));
                }
                Menu.AddSeparator();
                _autolevelskills = Menu.Add("autolevelskills", new CheckBox("Otomatik level arttırma"));
                _autoBuyStartingItems = Menu.Add("autoBuyStartingItems", new CheckBox("Başlangıçta otomatik item alma"));
                Menu.AddSeparator();
                _useSkinHack = Menu.Add("useSkinHack", new CheckBox("Skin Değiştrici Kullan"));
                _skinId = Menu.Add("skinId", new Slider("Skin Numarası", 7, 1, 8));
            }

            public static void Initialize()
            {
            }

        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Modes");

                // Initialize all modes
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

                // Harass
                Harass.Initialize();
                LaneClear.Initialize();
                JungleClear.Initialize();
                Flee.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useR;
                private static readonly CheckBox _useBOTRK;
                private static readonly CheckBox _useYOUMOUS;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }
                public static bool useBOTRK
                {
                    get { return _useBOTRK.CurrentValue; }
                }
                public static bool useYOUMOUS
                {
                    get { return _useYOUMOUS.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Kullan W"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Kullan R"));
                    Menu.AddSeparator();
                    _useBOTRK = Menu.Add("useBotrk", new CheckBox("Kullan Mahvolmuş Kılıcı ve Pala"));
                    _useYOUMOUS = Menu.Add("useYoumous", new CheckBox("Kullan Youmous"));
                }

                public static void Initialize()
                {
                }

            }

            public static class Harass
            {
                public static bool UseQ
                {
                    get { return Menu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool useQMinionKillOnly
                {
                    get { return Menu["harassUseQKillingBlowOnly"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseW
                {
                    get { return Menu["harassUseW"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return Menu["harassUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseR
                {
                    get { return Menu["harassUseR"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["harassMana"].Cast<Slider>().CurrentValue; }
                }

                static Harass()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("Dürtme");
                    Menu.Add("harassUseQ", new CheckBox("Kullan Q"));
                    Menu.Add("harassUseW", new CheckBox("Kullan W"));

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    Menu.Add("harassMana", new Slider("En fazla mana kullanımı ({0}%)", 40));
                }
                public static void Initialize()
                {
                }

            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly Slider _mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static int mana
                {
                    get { return _mana.CurrentValue; }
                }

                static LaneClear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Lane Temizleme");
                    _useQ = Menu.Add("clearUseQ", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("clearUseW", new CheckBox("Kullan W"));
                    _mana = Menu.Add("clearMana", new Slider("En fazla mana kullanımı ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }
            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly Slider _mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static int mana
                {
                    get { return _mana.CurrentValue; }
                }

                static JungleClear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Jungle Clear");
                    _useQ = Menu.Add("jglUseQ", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("jglUseW", new CheckBox("Kullan W"));
                    _mana = Menu.Add("jglMana", new Slider("En fazla mana kullanımı ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }
            public static class Flee
            {
                private static readonly CheckBox _useW;

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                static Flee()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Kaçma(Flee tuş)");
                    _useW = Menu.Add("fleeUseW", new CheckBox("Kullan W"));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}