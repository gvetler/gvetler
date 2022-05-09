using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace HAD_NEBOLI_SNAKE
{
    public partial class Form1 : Form
    {
        // Had
        private List<MapObject> Snake = new List<MapObject>();
        // Jidlo
        private MapObject food = new MapObject();
        // počet ticků které se při pohybování hadem přeskakujou, tim se snižuje jeho rychlost
        private int tmpSkipC;
        // Mapy
        private List<Map> Maps = new List<Map>();
        private int CurrentMap = 0;

        private bool GameRunning = false;
        private Direction tmpDir;
        private List<Difficulty> Difficulties = new List<Difficulty>();
        private int HeartCount = 3;
       
        public Form1()
        {
            // každý postup levelem zvýší obtížnost
            int tmpScore = 100;
            Difficulties.Add(new Difficulty("Nejlehčí", tmpScore, 2));
            Difficulties.Add(new Difficulty("Lehká", tmpScore, 2));
            Difficulties.Add(new Difficulty("Střední", tmpScore, 2));
            Difficulties.Add(new Difficulty("Střednější", tmpScore, 2));
            Difficulties.Add(new Difficulty("Těžká", tmpScore, 2));
            Difficulties.Add(new Difficulty("Nejtěžší", tmpScore, 2));

            //------------------------------------ přidání map -----------------------------------
            // přidá první mapu 60x40, kde had začíná na pozici [7,4], bez překážek
            List<MapObject> tmpObstacles = new List<MapObject>();
            Map tmpMap;
            tmpMap = new Map(60, 40, 7, 4, Direction.Down, tmpObstacles, true, 1000);
            Maps.Add(tmpMap);

            tmpObstacles = new List<MapObject>
            {
                new MapObject(14, 4, 1, 32),
                new MapObject(59 - 14, 4, 1, 32)
            };
            tmpMap = new Map(60, 40, 7, 4, Direction.Down, tmpObstacles, true, 1400);
            Maps.Add(tmpMap);

            tmpObstacles = new List<MapObject>
            {
                new MapObject(14, 24, 1, 10),
                new MapObject(30, 24, 1, 10),
                new MapObject(31, 33, 15, 1),
                new MapObject(59 - 14, 6, 1, 10),
                new MapObject(59 - 30, 6, 1, 10),
                new MapObject(14, 6, 15, 1)
            };
            tmpMap = new Map(60, 40, 7, 4, Direction.Down, tmpObstacles, true, 1700);
            Maps.Add(tmpMap);

            tmpObstacles = new List<MapObject>
            {
                new MapObject(14, 24, 1, 9),
                new MapObject(59 - 14, 24, 1, 9),
                new MapObject(14, 33, 32, 1),
                new MapObject(14, 7, 1, 9),
                new MapObject(59 - 14, 7, 1, 9),
                new MapObject(14, 6, 32, 1)
            };
            tmpMap = new Map(60, 40, 7, 4, Direction.Down, tmpObstacles, true, 1900);
            Maps.Add(tmpMap);

            tmpObstacles = new List<MapObject>
            {
                new MapObject(12, 0, 1, 23),
                new MapObject(12, 28, 1, 7),
                new MapObject(59 - 19, 34, 1, 6),
                new MapObject(12, 22, 29, 1),
                new MapObject(12, 28, 29, 1),
                new MapObject(12, 34, 29, 1),
                new MapObject(59 - 12, 5, 1, 7),
                new MapObject(59 - 12, 17, 1, 23),
                new MapObject(19, 0, 1, 6),
                new MapObject(19, 5, 29, 1),
                new MapObject(19, 11, 29, 1),
                new MapObject(19, 17, 29, 1)
            };
            tmpMap = new Map(60, 40, 7, 4, Direction.Down, tmpObstacles, true, 2000);
            Maps.Add(tmpMap);
            //-------------------------------------------------------------------------------------

            InitializeComponent();

            //----- je strašnej odpad ale líp to neumim :(, ve Form1.Designer.cs se to furt přepisuje
            Icon = Properties.Resources.Ikonka;
            Text = SettingsConst.String_WindowTitle;
            labelControls0.Text = SettingsConst.String_Controls;
            checkboxSettingsWalls.Text = SettingsConst.String_SettingWalls;
            pbGameField.Width = SettingsConst.Num_GameWidth;
            pbGameField.Height = SettingsConst.Num_GameHeight;
            radioButtonSettings1.Text = Difficulties[0].Name;
            radioButtonSettings2.Text = Difficulties[1].Name;
            radioButtonSettings3.Text = Difficulties[2].Name;
            //------------------------

            labelGameOver.Text = SettingsConst.String_Start;
            panelSettings.Visible= false;

            // nastaví game timer
            // GameTimer.Interval = SettingsConst.Num_TickInterval;
            GameTimer.Interval = 5;
            GameTimer.Tick += UpdateScreen;
            GameTimer.Start();
        }

        private void StartGame()
        {
            GameRunning = true;
            HideStuff();
            pbGameField.Select(); // odznačí nastavení aby ho hráč po konci hry omylem nezměnil (zmáčknutím šipky/mezerníku)
            if (HeartCount < 1)
            {
                HeartCount = 3;
                UpdateHearts();
            }

            // nastaví nastavení na defaultní - směr pohledu, skóre...
            // new SettingsVar();
            // nastaví nastavení na defaultní podle mapy
            new SettingsVar(Maps[CurrentMap]);
            //SetDifficulty();
            //SettingsVar.Walls = checkboxSettingsWalls.Checked;
            tmpDir = SettingsVar.Direction;
            //UnitWidth = pbGameField.Width / SettingsVar.MapWidth;
            //UnitHeight = pbGameField.Height / SettingsVar.MapHeight;

            // přidá hadovi hlavu
            MapObject head = new MapObject(SettingsVar.StartingX, SettingsVar.StartingY);
            Snake.Add(head);

            labelFoodCount0.Text = SettingsVar.FoodCount.ToString();
            labelScore0.Text = SettingsVar.Score.ToString();
            GenerateFood();
        }

        // položí ovoce na náhodnou pozici, pokud je na ní had tak zkusí znovu
        private void GenerateFood()
        {
            bool IsColliding = true;
            bool SnakeCol;
            bool ObsCol;
            while (IsColliding == true)
            {
                SnakeCol = false;
                ObsCol = false;
                Random random = new Random();
                food = new MapObject(random.Next(0, SettingsVar.MapWidth), random.Next(0, SettingsVar.MapHeight));

                foreach (MapObject x in Snake)
                {
                    if (x.IsColliding(food.X, food.Y))
                    {
                        SnakeCol = true;
                        break;
                    }
                }
                if (SnakeCol) continue;

                if (Maps[CurrentMap].Obstacles.Count > 0) {
                    foreach (MapObject x in Maps[CurrentMap].Obstacles)
                    {
                        if (x.IsColliding(food.X, food.Y))
                        {
                            ObsCol = true;
                            break;
                        }
                    }
                }
                if (ObsCol) continue;
                IsColliding = false;                
            }
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            // zkontroluje jestli hra běží
            if (!GameRunning)
            {
                // zkontroluje jestli je enter nebo mezernik stlačen
                if (Input.KeyPressed(Keys.Enter) || Input.KeyPressed(Keys.Space))
                {
                    StartGame();
                }
                // zkontroluje jestli je stlačen esc
                if (Input.KeyPressed(Keys.Escape))
                {
                    Application.Exit();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Escape))
                {
                    Input.ChangeState(Keys.Escape, false);
                    EndGame(false);
                }
                if ((Input.KeyPressed(Keys.Right) || Input.KeyPressed(Keys.D)) && SettingsVar.Direction != Direction.Left)
                    tmpDir = Direction.Right;
                else if ((Input.KeyPressed(Keys.Left) || Input.KeyPressed(Keys.A)) && SettingsVar.Direction != Direction.Right)
                    tmpDir = Direction.Left;
                else if ((Input.KeyPressed(Keys.Up) || Input.KeyPressed(Keys.W)) && SettingsVar.Direction != Direction.Down)
                    tmpDir = Direction.Up;
                else if ((Input.KeyPressed(Keys.Down) || Input.KeyPressed(Keys.S)) && SettingsVar.Direction != Direction.Up)
                    tmpDir = Direction.Down;
                
                // přeskakování ticků pro úpravu obtížnosti
                if (Difficulties[SettingsVar.Difficulty].SkipCount > 0)
                {
                    if (tmpSkipC > 0)
                    {
                        tmpSkipC--;
                        return;
                    }
                    else
                    {
                        tmpSkipC = Difficulties[SettingsVar.Difficulty].SkipCount;
                    }
                }
                SettingsVar.Direction = tmpDir;
                MovePlayer();
            }
            pbGameField.Invalidate();
        }

        private void pbGameField_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (GameRunning)
            {
                Maps[CurrentMap].SetCanvas(e.Graphics);
                int UnitWidth = Maps[CurrentMap].UnitWidth;
                int UnitHeight = Maps[CurrentMap].UnitHeight;
                Maps[CurrentMap].Draw();
                // nakreslí hada
                for (int i = 0; i < Snake.Count; i++)
                {
                    Brush snakeColour;
                    // volba barvy
                    if (i == 0)
                        snakeColour = Brushes.DarkMagenta; // hlava je černá
                    else
                        snakeColour = Brushes.DarkOrange; // tělo zelený

                    // vybarví kolečko
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * UnitWidth,
                                      Snake[i].Y * UnitHeight,
                                      UnitWidth, UnitHeight));
                }

                //Nakreslí jídlo
                canvas.FillEllipse(Brushes.ForestGreen,
                    new Rectangle(food.X * UnitWidth,
                         food.Y * UnitHeight, UnitWidth, UnitHeight));

            }
        }
        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                // pohyb hlavy
                if (i == 0)
                {
                    switch (SettingsVar.Direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }

                    // detekuje kolize s okrajema. když nejsou zdi tak teleportuje na druhou stranu
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= SettingsVar.MapWidth || Snake[i].Y >= SettingsVar.MapHeight)
                    {
                        if (SettingsVar.Edges)
                        {
                            EndGame();
                            return;
                        }
                        else
                        {
                            if (Snake[i].X < 0)
                            {
                                Snake[i].X = SettingsVar.MapWidth - 1;
                            }
                            else if (Snake[i].Y < 0)
                            {
                                Snake[i].Y = SettingsVar.MapHeight - 1;
                            }
                            else if (Snake[i].X >= SettingsVar.MapWidth)
                            {
                                Snake[i].X = 0;
                            }
                            else if (Snake[i].Y >= SettingsVar.MapHeight)
                            {
                                Snake[i].Y = 0;
                            }
                        }
                    }

                    // detekuje kolize s tělem
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X &&
                           Snake[i].Y == Snake[j].Y)
                        {
                            EndGame();
                            return;
                        }
                    }

                    // detekuje kolize s jídlem
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        EatFood();
                        if (SettingsVar.Score >= Maps[CurrentMap].ScoreNext)
                        {
                            LevelUp();
                            return;
                        }
                    }

                    // detekuje kolize s překážkama, jestli nějaký sou
                    if (Maps[CurrentMap].Obstacles.Count > 0)
                    {
                        foreach (MapObject Obstacle in Maps[CurrentMap].Obstacles)
                        {
                            if (Obstacle.IsColliding(Snake[i].X, Snake[i].Y))
                            {
                                EndGame();
                                return;
                            }
                        }
                    }
                }
                else
                {
                    // pohyb těla
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);

            // tyhle 2(+2) řádky způsoběj že
            // se nastavení nebude moct měnit klávesama (šipkama se ovládaj třeba radio čudlíky)
            // a odstraněj zvuk při zmáčknutí většiny kláves
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void EatFood()
        {
            // přidá kruh k tělu
            MapObject circle = new MapObject
            (
                X:Snake[Snake.Count - 1].X,
                Y:Snake[Snake.Count - 1].Y
            );
            Snake.Add(circle);

            // updatuje skóre
            int tmpScore = 0;
            tmpScore += Difficulties[SettingsVar.Difficulty].ScoreInc;
            /*
            if (SettingsVar.Edges)
            {
                tmpScore *= SettingsConst.Num_WallsMultiplier;
            }*/

            SettingsVar.Score += tmpScore;

            labelScore0.Text = SettingsVar.Score.ToString();

            GenerateFood();

            // updatuje jídla
            SettingsVar.FoodCount++;
            labelFoodCount0.Text = SettingsVar.FoodCount.ToString();
        }

        private void EndGame(bool death = true)
        {
            GameRunning = false;
            Snake.Clear();
            if (death)
            {
                HeartCount--;
                if (HeartCount > 0)
                {
                    labelGameOver.Text = "JEJDA!\nZTRATIL JSI ŽIVOT\n\nSTISKNI ENTER PRO POKRAČOVÁNÍ";
                }
                if (HeartCount < 1)
                {
                    labelGameOver.Text = "KONEC HRY\n\nZTRATIL JSI VŠECHNY ŽIVOTY\n\nSTISKNI ENTER PRO NOVOU HRU";
                    CurrentMap = 0;
                    SettingsVar.Difficulty = 0;
                }
            }
            else if (CurrentMap < 5)
            {
                labelGameOver.Text = "DOKONČIL JSI ÚROVEŇ:  " + CurrentMap + "\n\nSTISKNI ENTER PRO POKRAČOVÁNÍ";
            }
            else
            {
                labelGameOver.Text = "GRATULUJU!\n\n" + "DOKONČIL JSI VŠECHNY ÚROVNĚ\n\nSTISKNI ENTER PRO DALŠÍ HRU";
                CurrentMap = 0;
                SettingsVar.Difficulty = 0;
            }
            UpdateHearts(); // skryje srdíčka
            if (HeartCount < 0)
            {
                CurrentMap = 0;
                SettingsVar.Difficulty = 0;
                HeartCount = 3;
            }


            /*
            labelGameOver.Text = "KONEC HRY\n\n" +
                                "TVOJE FINÁLNÍ SKÓRE JE:  " + SettingsVar.Score +
                                "\n\nSNĚDL JSI:  " + SettingsVar.FoodCount + " JÍDLA" +
                                "\n\nSTISKNI ENTER PRO DALŠÍ POKUS";
            */

            ShowStuff();
        }

        private void LevelUp()
        {
            CurrentMap++;
            SettingsVar.Difficulty++;
            EndGame(false); // false neubere život
        }

        private void UpdateHearts()
        {
            switch (HeartCount)
            {
                case 0:
                    pictureBoxHeart1.Image = Properties.Resources.HeartEmpty;
                    break;
                case 1:
                    pictureBoxHeart2.Image = Properties.Resources.HeartEmpty;
                    break;
                case 2:
                    pictureBoxHeart3.Image = Properties.Resources.HeartEmpty;
                    break;
                case 3:
                    pictureBoxHeart1.Image = Properties.Resources.Heart;
                    pictureBoxHeart2.Image = Properties.Resources.Heart;
                    pictureBoxHeart3.Image = Properties.Resources.Heart;
                    break;
            }
        }

        private void HideStuff()
        {
            labelGameOver.Visible = false;
            // panelSettings.Enabled = false; // nebo Visible
        }

        private void ShowStuff()
        {
            labelGameOver.Visible = true;
            // panelSettings.Enabled = true;
        }

        private void SetDifficulty()
        {
            if (radioButtonSettings1.Checked)
            {
                SettingsVar.Difficulty = 0;
            }
            else if (radioButtonSettings2.Checked)
            {
                SettingsVar.Difficulty = 1;
            }
            else if (radioButtonSettings3.Checked)
            {
                SettingsVar.Difficulty = 2;
            }
        }
    }
}
