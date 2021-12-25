using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Homework_7
{
    public partial class MainForm : Form
    {
        public static readonly SecureRandom random = new SecureRandom();

        public bool block;
        private int score, highScore, time, match;
        private Board board;

        private bool correct;
        private Button[] cardTask;

        public readonly SoundPlayer sp;
        private readonly WindowsMediaPlayer wmp;

        public MainForm()
        {
            InitializeComponent();

            sp = new SoundPlayer();
            wmp = new WindowsMediaPlayer();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            playBGM();
            highScore = DataAccessor.readHighScore();
            board = new Board(this);

            updateHighScore();
            updateScore();
            updateTimeCount();
        }

        private void timerCount_Tick(object sender, EventArgs e)
        {
            ++time;
            updateTimeCount();
        }

        private void timerRecover_Tick(object sender, EventArgs e)
        {
            timerRecover.Stop();
            if (correct)
            {
                sp.Stream = Properties.Resources.Match;
                sp.Play();

                addScore();
                foreach (Button target in cardTask)
                {
                    target.Enabled = false;
                }
            }
            else
            {
                sp.Stream = Properties.Resources.NoMatch;
                sp.Play();

                Image background = board.getCardBackground();
                foreach (Button target in cardTask)
                {
                    target.Image = background;
                }
            }
            block = false;
            btnControl.Enabled = true;
        }

        public void processCard(Button[] cardTask, bool correct)
        {
            btnControl.Enabled = false;
            this.correct = correct;
            this.cardTask = cardTask;
            timerRecover.Start();
        }

        private void addScore()
        {
            int add = 10 - (time / 20);
            if (add <= 0)
            {
                add = 1;
            }
            score += add;
            updateScore();

            if (++match >= Math.Pow(Board.GENERATE_SEQURE, 2) / 2)
            {
                complete();
            }
        }

        private void updateHighScore()
        {
            labelHighScore.Text = "最高紀錄 : " + highScore;
        }

        private void updateScore()
        {
            labelScore.Text = "目前分數 : " + score;
        }

        private void updateTimeCount()
        {
            labelTime.Text = "經過時間 : " + makeTimeReadable();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            switch (btnControl.Text)
            {
                case "開始":
                    {
                        start();
                        btnControl.Text = "強制結束";
                        break;
                    }
                case "強制結束":
                    {
                        forceStop();
                        btnControl.Text = "重置";
                        break;
                    }
                case "重置":
                    {
                        reset();
                        btnControl.Text = "開始";
                        break;
                    }
            }
        }

        private void start()
        {
            sp.Stream = Properties.Resources.Timer;
            sp.Play();

            board.enableButton(true);
            timerCount.Start();
        }

        private void forceStop()
        {
            timerCount.Stop();

            sp.Stream = Properties.Resources.Stop;
            sp.Play();

            board.enableButton(false);
        }

        private void reset()
        {
            pbComplete.Visible = false;
            score = 0;
            time = 0;
            match = 0;
            updateScore();
            updateTimeCount();
            board.reset();
        }

        private void complete()
        {
            timerCount.Stop();
            sp.Stream = Properties.Resources.WinSound;
            sp.Play();

            if (score > highScore)
            {
                DataAccessor.writeHighScore(score);
                highScore = score;
                updateHighScore();
            }
            pbComplete.Visible = true;
            btnControl.Text = "重置";
        }

        private string makeTimeReadable()
        {
            StringBuilder sb = new StringBuilder();
            int minute = time / 60;
            int second = time % 60;
            if (minute > 0)
            {
                sb.Append(minute).Append(" 分 ");
            }
            sb.Append(second).Append(" 秒");
            return sb.ToString();
        }

        private void extractBGM()
        {
            string path = Path.Combine(Path.GetTempPath(), "BGM.mp3");
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(Properties.Resources.BGM, 0, Properties.Resources.BGM.Length);
                fs.Flush();
            }
        }

        public void playBGM()
        {
            try
            {
                extractBGM();
                wmp.URL = Path.Combine(Path.GetTempPath(), "BGM.mp3");
                wmp.settings.volume = 50;
                wmp.settings.setMode("loop", true);
                wmp.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("BGM 播放時發生例外狀況 : " + ex);
            }
        }
    }
}