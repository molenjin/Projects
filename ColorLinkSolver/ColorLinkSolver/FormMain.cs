using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using static ColorLinkSolver.AppSettings;

namespace ColorLinkSolver
{
    public partial class FormMain : Form
    {
        private AppSettings? appsettings;
        private BoardGraphic board;

        public FormMain()
        {
            InitializeComponent();

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            appsettings = config.GetRequiredSection("AppSettings").Get<AppSettings>();

            board = new BoardGraphic(pnBoard.CreateGraphics(), pnBoard.Size);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {          
            cbTasks.Items.Clear();
            foreach (AppSettings.Task task in appsettings.Tasks)
            {
                cbTasks.Items.Add(task.Name);
            }
            lblBoardStatus.Text = "";
        }

        private void cbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var task = appsettings.Tasks.Find(Task => Task.Name == cbTasks.Text);

            board.SetBoard(task.BoardSizeX, task.BoardSizeY);
            foreach (AppSettings.Task.Point point in task.Points) board.SetEndPoint(point.X, point.Y, Color.FromName(point.Color));
            board.DrawBoard();

            btnSolve.Enabled = true;
            lblBoardStatus.Text = String.Empty;
            lblTimer.Text = String.Empty;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            btnSolve.Enabled = false;
            lblTimer.Text = String.Empty;
            
            var timer = new Stopwatch();
            timer.Start();

            board.Prepare();

            BoardStatus boardStatus = board.Solve();
            board.DrawBoard();
            lblBoardStatus.Text = boardStatus.ToString();

            timer.Stop();            
            lblTimer.Text = "Elapsed time: " + timer.ElapsedMilliseconds.ToString() + " milliseconds";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}