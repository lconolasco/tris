using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;namespace tris{    public partial class trisPage : ContentPage    {
        int scoreX = 0, scoreO = 0, scoreTie = 0, spin = 9;
        bool turn = true;
        string[] arrPosition = new string[9];
        public trisPage()        {            InitializeComponent();        }        public void BtnClickOk()        {            entryPlayerX.IsVisible = false;            btnPlayerX.IsVisible = false;            entryPlayerO.IsVisible = true;            btnPlayerO.IsVisible = true;        }        public void BtnClickOkO()        {            entryPlayerO.IsVisible = false;            btnPlayerO.IsVisible = false;            btnNewGame.IsVisible = true;        }        public void BtnRestart()
        {
            Clear();
        }
        public void BtnClick(object sender, EventArgs e)        {
            Debug.WriteLine($"Value Initial spin: {spin}");            Button btn = (Button)sender;
            if (btn.Text == "" && spin > 0)
            {
                if (turn)
                {
                    btn.Text = "X";
                    btn.Image = "X_100@100_trsp.png";
                    arrPosition[int.Parse(btn.ClassId)] = btn.Text;
                    btn.IsEnabled = false;
                    turn = !turn;
                    Debug.WriteLine($"Call Button: {btn.ClassId}");
                    Debug.WriteLine($"Value Actual turn: {turn}");
                    Win(btn.Text);
                }
                else {
                    btn.Text = "O";
                    btn.Image = "O_100@100_trsp.png";
                    arrPosition[int.Parse(btn.ClassId)] = btn.Text;
                    btn.IsEnabled = false;
                    turn = !turn;
                    Debug.WriteLine($"Call Button: {btn.ClassId}");
                    Debug.WriteLine($"Value Actual turn: {turn}");
                    Win(btn.Text);
                }
                spin--;
                Debug.WriteLine($"Value Actual spin: {spin}");
            }        }

        public async virtual void Win(string player)
        {
            if (spin <= 5)
            {
                for (int horizontal = 0; horizontal < 8; horizontal += 3)
                    if (player == arrPosition[horizontal])
                    {
                        if (arrPosition[horizontal] == arrPosition[horizontal + 1] && arrPosition[horizontal] == arrPosition[horizontal + 2])
                        {
                            Debug.WriteLine($"Player {player} ha vinto!");
                            Score(player);
                            Clear();
                            await Task.Delay(1250);
                            return;
                        }
                    }

                for (int vertical = 0; vertical < 3; vertical++)
                    if (player == arrPosition[vertical])
                    {
                        if (arrPosition[vertical] == arrPosition[vertical + 3] && arrPosition[vertical] == arrPosition[vertical + 6])
                        {
                            Debug.WriteLine($"Player {player} ha vinto!");
                            Score(player);
                            Clear();
                            await Task.Delay(1250); return;
                        }
                    }
                if (player == arrPosition[0])
                {
                    if (arrPosition[0] == arrPosition[4] && arrPosition[0] == arrPosition[8])
                    {
                        Debug.WriteLine($"Player {player} ha vinto!");
                        Score(player);
                        Clear();
                        await Task.Delay(1250); return;
                    }
                }

                if (player == arrPosition[2])
                {
                    if (arrPosition[2] == arrPosition[4] && arrPosition[2] == arrPosition[6])
                    {
                        Debug.WriteLine($"Player {player} ha vinto!");
                        Score(player);
                        Clear();
                        await Task.Delay(1250); return;
                    }

                }

                if (spin <= 1)
                {
                    scoreTie += 1;
                    lblScoreTie.Text = scoreTie.ToString();

                    await DisplayAlert("PAREGGIO", "Siete Bravi!!!", "Riproviamo");
                    Clear();
                }
            }

        }

        public void Score(string player)
        {
            if (player == "X")
            {
                if (lblPlayerX.Text != string.Empty)
                {
                    DisplayAlert("VITTORIA", $"Punto per {lblPlayerX.Text}", "Ok");
                }
                else {
                    DisplayAlert("VITTORIA", $"Punto per Player {player}", "Ok");
                }
                scoreX += 1;
                lblScoreX.Text = scoreX.ToString();
            }
            else
            {
                if (lblPlayerO.Text != string.Empty)
                {
                    DisplayAlert("VITTORIA", $"Punto per {lblPlayerO.Text}", "Ok");
                }
                else {
                    DisplayAlert("VITTORIA", $"Punto per Player {player}", "Ok");
                }
                scoreO += 1;
                lblScoreO.Text = scoreO.ToString();
            }
        }

        public void Clear()
        {
            for (int i = 0; i < 9; i++)
            {
                arrPosition[i] = null;
            }
            btn0.Text = ""; btn1.Text = ""; btn2.Text = "";
            btn3.Text = ""; btn4.Text = ""; btn5.Text = "";
            btn6.Text = ""; btn7.Text = ""; btn8.Text = "";

            btn0.Image = null; btn1.Image = null; btn2.Image = null;
            btn3.Image = null; btn4.Image = null; btn5.Image = null;
            btn6.Image = null; btn7.Image = null; btn8.Image = null;

            btn0.IsEnabled = true; btn1.IsEnabled = true; btn2.IsEnabled = true;
            btn3.IsEnabled = true; btn4.IsEnabled = true; btn5.IsEnabled = true;
            btn6.IsEnabled = true; btn7.IsEnabled = true; btn8.IsEnabled = true;

            spin = 9;
        }
    }
}