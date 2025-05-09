using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dream
{
    public partial class Form1 : Form
    {
        private int gameState = 0;
        private Label storyLabel;
        private Button button1;
        private Button button2;
        private Button button3;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
            Start();
        }

        private void SetupUI()
        {
            this.Text = "DREAM — Start";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            storyLabel = new Label
            {
                Size = new Size(700, 200),
                Location = new Point(50, 30),
                Font = new Font("Segoe UI", 11),
                BackColor = Color.FromArgb(180, Color.White),
                TextAlign = ContentAlignment.TopLeft,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                AutoSize = false
            };
            this.Controls.Add(storyLabel);

            button1 = new Button
            {
                Size = new Size(300, 40),
                Location = new Point(50, 260),
                ForeColor = Color.Black
            };
            this.Controls.Add(button1);

            button2 = new Button
            {
                Size = new Size(300, 40),
                Location = new Point(400, 260),
                ForeColor = Color.Black
            };
            this.Controls.Add(button2);

            button3 = new Button
            {
                Size = new Size(300, 40),
                Location = new Point(225, 320),
                ForeColor = Color.Black,
                Visible = false
            };
            this.Controls.Add(button3);
        }

        private void SetBackground(string filename)
        {
            try
            {
                this.BackgroundImage = Image.FromFile(filename);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {
                MessageBox.Show($"Kunde inte hitta {filename} – lägg bilden i projektmappen!", "Bild saknas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.BackColor = Color.Black;
            }
        }

        private void Start()
        {
            gameState = 1;
            SetBackground("medium.jpg");

            storyLabel.Text = "You woke up here, you feel dizzy. You look around. The room feels familiar yet off…\n\nWhat do you do?";
            button1.Text = "Look around";
            button2.Text = "Leave the room";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;

            ResetAllHandlers();
            button1.Click += new EventHandler(Button1_Click);
            button2.Click += new EventHandler(Button2_Click);
            button3.Click += new EventHandler(Button3_Click);
        }

        private void ResetAllHandlers()
        {
            button1.Click -= Button1_Click;
            button1.Click -= Button4_Click;
            button1.Click -= Button6_Click;
            button1.Click -= Button7_Click;
            button1.Click -= ButtonRun_Click;
            button1.Click -= ButtonHide_Click;
            button1.Click -= CrawlIntoHole;
            button1.Click -= WalkAround;
            button1.Click -= Home;
            button1.Click -= Dog;
            button1.Click -= RestartGame;

            button2.Click -= Button2_Click;
            button2.Click -= Button5_Click;
            button2.Click -= ButtonHide_Click;
            button2.Click -= WalkAround;

            button3.Click -= Button3_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (gameState == 1)
            {
                gameState = 2;
                SetBackground("background.jpg");

                storyLabel.Text = "You notice a small hatch in the corner of the room.\nYou open the hatch and climb through...\n\nYou crawl out into an oddly familiar colourful street.\nNeatly trimmed lawns stretch before you. Yellow houses line the road.\n\nSMALL HATCH: 'Is this… a neighborhood?'";
                button1.Text = "Go inside the house";
                button2.Text = "Stay outside";

                ResetAllHandlers();
                button1.Click += new EventHandler(Button3_Click);
                button2.Click += new EventHandler(Button2_Click);
            }
            else if (gameState == 3)
            {
                Button3_Click(sender, e);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (gameState == 1)
            {
                gameState = 3;
                SetBackground("hallway.jpg");

                storyLabel.Text = "You leave the room, it feels uncanny and rather unsafe. Your instincts are telling you to get out.\n\nYou enter a hallway.  .";
                button1.Text = "Enter the door in front";
                button2.Text = "Walk down the hallway";

                ResetAllHandlers();
                button1.Click += new EventHandler(Button3_Click);
                button2.Click += new EventHandler(Button5_Click);
            }
            else if (gameState == 2)
            {
                gameState = 99;
                storyLabel.Text = "You remain on the street, unsure of what to do. The sky flickers for a second. The neighborhood distorts. Something watches you from behind the windows. You can't stay in a dream for too long.\n\n*** END GAME ***";
                button1.Text = "Restart";
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;

                ResetAllHandlers();
                button1.Click += new EventHandler(RestartGame);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            gameState = 4;
            SetBackground("kitty.jpg");

            storyLabel.Text = "You decide to test your luck and enter the door in front of you. You end up in Kitty's room, an overly pink room filled with cute toys and a nostalgic scent of perfume you recognize.";
            button1.Text = "Look around";
            button2.Visible = false;
            button3.Visible = false;

            ResetAllHandlers();
            button1.Click += new EventHandler(Button4_Click);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            gameState = 5;
            storyLabel.Text = "Careful. Kitty is watching.";
            button1.Text = "Stay";
            button2.Text = "Stay";
            button1.Visible = true;
            button2.Visible = true;

            ResetAllHandlers();
            button1.Click += new EventHandler(EndGame);
            button2.Click += new EventHandler(EndGame);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            gameState = 6;
            SetBackground("funroom1.jpg");

            storyLabel.Text = "You walk down the hallway, the whispers grow louder. You feel a chill down your spine. Suddenly, you see a shadow move...";
            button1.Text = "Run into the door";
            button2.Text = "Run back";

            ResetAllHandlers();
            button1.Click += new EventHandler(Button6_Click);
            button2.Click += new EventHandler(RunBack);
        }

        private void RunBack(object sender, EventArgs e)
        {
            gameState = 7;
            storyLabel.Text = "It was following you. You feel yourself be ripped apart. How did you end up here? Maybe you shouldn't regret what's already done…?\n\n*** END GAME ***";
            button1.Text = "Restart";
            button2.Visible = false;
            button3.Visible = false;

            ResetAllHandlers();
            button1.Click += new EventHandler(RestartGame);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            gameState = 8;
            SetBackground("funroom.jpg");

            storyLabel.Text = "You run into the door and find yourself in a party decorated area, its very unsettling. It reminds you of all your past mistakes. The walls have 'fun' littered all on them, nothing about this feels fun... At least you went forward, right?";
            button1.Text = "Look";

            ResetAllHandlers();
            button1.Click += new EventHandler(Button7_Click);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            gameState = 9;
            storyLabel.Text = "You're being watched!!";
            button1.Text = "Run";
            button2.Text = "Hide";
            button2.Visible = true;

            ResetAllHandlers();
            button1.Click += new EventHandler(ButtonRun_Click);
            button2.Click += new EventHandler(ButtonHide_Click);
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            gameState = 10;
            storyLabel.Text = "You overestimated yourself...\n\n*** END GAME ***";
            button1.Text = "Restart";

            ResetAllHandlers();
            button1.Click += new EventHandler(RestartGame);
        }

        private void ButtonHide_Click(object sender, EventArgs e)
        {
            gameState = 11;
            storyLabel.Text = "You find a dark ballpit and jump in, yet you never felt any solid ground...";
            button1.Text = "Splash";

            ResetAllHandlers();
            button1.Click += new EventHandler(PoolRooms);
        }

        private void PoolRooms(object sender, EventArgs e)
        {
            gameState = 12;
            SetBackground("poolrooms.jpg");

            storyLabel.Text = "You fell through the ballpit. Your body hits warm water fluorescent lights flicker above. It feels quiet… but wrong. You stand up. Endless tiled hallways surround you. The air hums..";
            button1.Text = "Crawl into the hole";
            button2.Text = "Walk around to exit";
            button2.Visible = true;

            ResetAllHandlers();
            button1.Click += new EventHandler(CrawlIntoHole);
            button2.Click += new EventHandler(WalkAround);
        }

        private void CrawlIntoHole(object sender, EventArgs e)
        {
            gameState = 13;
            storyLabel.Text = "You crouch and crawl into the hole. It gets tighter. You keep going. Suddenly… carpet. A soft breeze. You’re back in your room.";
            button1.Text = "Open the door";

            ResetAllHandlers();
            button1.Click += new EventHandler(Home);
        }

        private void WalkAround(object sender, EventArgs e)
        {
            gameState = 14;
            storyLabel.Text = "You walk. And walk. The tiles never end. The lights flicker louder. Your footsteps echo too sharply. You’re stuck. You were never meant to choose safety.";
            button1.Text = "Restart";
            button2.Visible = false;

            ResetAllHandlers();
            button1.Click += new EventHandler(RestartGame);
        }

        private void Home(object sender, EventArgs e)
        {
            gameState = 15;
            SetBackground("home.jpg");

            storyLabel.Text = "You open the door to greet your family, yet no one is at home..Maybe they will be back soon?";
            button1.Text = "Ignore the smiling dog";
            button2.Visible = false;

            ResetAllHandlers();
            button1.Click += new EventHandler(Dog);
        }

        private void Dog(object sender, EventArgs e)
        {
            gameState = 16;
            storyLabel.Text = "You don't remember ever having a pet...\n\n*** END GAME ***";
            button1.Text = "Restart";

            ResetAllHandlers();
            button1.Click += new EventHandler(RestartGame);
        }

        private void EndGame(object sender, EventArgs e)
        {
            storyLabel.Text = "YoU feEL At HomE. YOU WaNnA StAy...\n\n*** END GAME ***";
            button1.Text = "Restart";
            button2.Visible = false;

            ResetAllHandlers();
            button1.Click += new EventHandler(RestartGame);
        }

        private void RestartGame(object sender, EventArgs e)
        {
            Start();
        }
    }
}