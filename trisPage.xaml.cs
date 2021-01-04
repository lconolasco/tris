using System;
using System.Diagnostics;
using Xamarin.Forms;namespace tris{    public partial class trisPage : ContentPage    {
        int scoreX = 0, scoreO = 0, scoreTie = 0, spin = 9;
        bool turn = true;
        string[] arrPosition = new string[9];
        public trisPage()        {            InitializeComponent();        }        public void BtnClickOk()        {            entryPlayerX.IsVisible = false;            btnPlayerX.IsVisible = false;            entryPlayerO.IsVisible = true;            btnPlayerO.IsVisible = true;        }        public void BtnClickOkO()        {            entryPlayerO.IsVisible = false;            btnPlayerO.IsVisible = false;            btnNewGame.IsVisible = true;        }        public void BtnRestart()
        {

        }        public void BtnClick(object sender, EventArgs e)        {
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

        public void Win(string player)
        {
            for (int horizontal = 0; horizontal < 8; horizontal += 3)
                if (player == arrPosition[horizontal])
                {
                    if (arrPosition[horizontal] == arrPosition[horizontal + 1] && arrPosition[horizontal] == arrPosition[horizontal + 2])
                    {
                        Debug.WriteLine($"Player {player} ha vinto!");
                        Score(player);
                        spin = 0;
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
                        spin = 0;
                        return;
                    }
                }
            for (int obliquo = 0; obliquo < 8; obliquo += 4)
                if (player == arrPosition[obliquo])
                {
                    if (arrPosition[obliquo] == arrPosition[obliquo + 4] && arrPosition[obliquo] == arrPosition[obliquo + 8])
                    {
                        Debug.WriteLine($"Player {player} ha vinto!");
                        Score(player);
                        spin = 0;
                        return;
                    }
                }
                    
                        for (int obliquo1 = 2; obliquo1 < 4; obliquo1 += 2)
                            if (player == arrPosition[obliquo1])
                            {
                                if (arrPosition[obliquo1] == arrPosition[obliquo1 + 2] && arrPosition[obliquo1] == arrPosition[obliquo1 + 4])
                                {
                                    Debug.WriteLine($"Player {player} ha vinto!");
                                    Score(player);
                                    spin = 0;
                                    return;
                                }
                            
                }
            if (spin == 0)
            {
                scoreTie += 1;
                lblScoreTie.Text = scoreTie.ToString();}
        }

        public void Score(string player)
        {
            if (player == "X")
            {
                scoreX += 1;
                lblScoreX.Text = scoreX.ToString();
            }
            else
            {
                scoreO += 1;
                lblScoreO.Text = scoreO.ToString();
            }
        }

        public void Clear(){
            
        }
    }
}