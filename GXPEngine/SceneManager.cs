using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class SceneManager : GameObject
    {
        private int whatLevel = 0;
        private static SceneManager _instance;
        public static SceneManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SceneManager();
                }
                return _instance;
            }
        }

        public SceneManager()
        {
            if (_instance != null)
            {
                Destroy();
                return;
            }

            _instance = this;
        }

        void Update()
        {

        }
        public void loadLevel(string LevelName)
        {
            foreach (GameObject Child in GetChildren())
            {
                Child.Destroy();
            }

            switch (LevelName)
            {
                case "MainMenu":
                    MainMenu mainMenu = new MainMenu();
                    AddChild(mainMenu);
                    break;
                case "LevelHighScore":
                    LevelHighScore level2 = new LevelHighScore();
                    AddChild(level2);
                    break;
                case "Level1":
                    Level1 level1 = new Level1();
                    AddChild(level1);
                    break;
                case "Death":
                    Death death = new Death();
                    AddChild(death);
                    break;
                default:
                    Console.WriteLine($"{LevelName} is not supported");
                    break;


            }
        }
    }
}

