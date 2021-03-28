using System;
using System.Linq;
//using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace tris
{
    public partial class MainPage : ContentPage
    {
        private int scoreX = 0, scoreO = 0, scoreTie = 0, spin = 9;
        private bool turn = true;
        private readonly string[] arrPosition = new string[9];
        public MainPage()
        {
            InitializeComponent();
        }
        public void Handle_Clicked(object sender, EventArgs e)
        {
            entryPlayerX.IsVisible = false;
            btnPlayerX.IsVisible = false;

            entryPlayerO.IsVisible = true;
            btnPlayerO.IsVisible = true;
        }

        public void BtnClickOk(object sender, EventArgs e)
        {
            entryPlayerX.IsVisible = false;
            btnPlayerX.IsVisible = false;

            entryPlayerO.IsVisible = true;
            btnPlayerO.IsVisible = true;
        }

        public void BtnClickOkO(object sender, EventArgs e)
        {
            entryPlayerO.IsVisible = false;
            btnPlayerO.IsVisible = false;
            btnNewGame.IsVisible = true;
        }

        public void BtnRestart(object sender, EventArgs e)
        {
            Clear();
        }

        [Obsolete]
        public async void BtnClick(object sender, EventArgs e)
        {
            //Debug.WriteLine($"Initial spin Value: {spin}");
            Button btn = (Button)sender;
            if (lblPlayerX.IsEnabled && lblPlayerX.Text == string.Empty && lblPlayerO.IsEnabled && lblPlayerO.Text == string.Empty)
            {
                _ = TextToSpeech.SpeakAsync("Desidera proseguire senza impostare i nomi degli partecipanti?");
                string action = await Application.Current.MainPage.DisplayActionSheet("Desidera proseguire senza impostare i nomi degli partecipanti?", "Sì", "No");
                //Debug.WriteLine("Action: " + action);
                if (action == "Sì")
                {
                    //Debug.WriteLine("Azione scelta Sì!");
                    lblPlayerX.IsEnabled = false;
                    lblPlayerO.IsEnabled = false;
                    entryPlayerX.IsVisible = false;
                    entryPlayerO.IsVisible = false;
                    btnPlayerX.IsVisible = false;
                    btnPlayerO.IsVisible = false;
                    btnNewGame.IsVisible = true;

                }
                else
                {
                    //Debug.WriteLine("Azione scelta No!");
                    return;
                }

            }
            if (btn.Text == "" && spin > 0)
            {
                if (turn)
                {
                    btn.Text = "X";
                    btn.ImageSource = "X.png";
                    arrPosition[int.Parse(btn.ClassId)] = btn.Text;
                    btn.IsEnabled = false;
                    turn = !turn;
                    //Debug.WriteLine($"Call Button: {btn.ClassId}");
                    //Debug.WriteLine($"Current turn Value: {turn}");
                    Win(btn.Text);
                }
                else
                {
                    btn.Text = "O";
                    btn.ImageSource = "O.png";
                    arrPosition[int.Parse(btn.ClassId)] = btn.Text;
                    btn.IsEnabled = false;
                    turn = !turn;
                    //Debug.WriteLine($"Call Button: {btn.ClassId}");
                    //Debug.WriteLine($"Current turn Value: {turn}");
                    Win(btn.Text);
                }
                spin--;
                //Debug.WriteLine($"Current spin Value: {spin}");
            }
        }

        [Obsolete]
        public virtual async void Win(string player)
        {
            if (spin <= 5)
            {
                for (int horizontal = 0; horizontal < 8; horizontal += 3)
                {
                    if (player == arrPosition[horizontal])
                    {
                        if (arrPosition[horizontal] == arrPosition[horizontal + 1] && arrPosition[horizontal] == arrPosition[horizontal + 2])
                        {
                            //Debug.WriteLine($"Player {player} ha vinto!");
                            switch (horizontal)
                            {
                                case 0:
                                    btn0.ImageSource = "riga.png";
                                    btn1.ImageSource = "riga.png";
                                    btn2.ImageSource = "riga.png";
                                    break;
                                case 3:
                                    btn3.ImageSource = "riga.png";
                                    btn4.ImageSource = "riga.png";
                                    btn5.ImageSource = "riga.png";
                                    break;
                                case 6:
                                    btn6.ImageSource = "riga.png";
                                    btn7.ImageSource = "riga.png";
                                    btn8.ImageSource = "riga.png";
                                    break;
                                default:
                                    break;
                            }
                            DisableBtnClick();
                            Score(player);
                            await Task.Delay(1250);
                            Clear();
                            return;
                        }
                    }
                }

                for (int vertical = 0; vertical < 3; vertical++)
                {
                    if (player == arrPosition[vertical])
                    {
                        if (arrPosition[vertical] == arrPosition[vertical + 3] && arrPosition[vertical] == arrPosition[vertical + 6])
                        {
                            //Debug.WriteLine($"Player {player} ha vinto!");
                            switch (vertical)
                            {
                                case 0:
                                    btn0.ImageSource = "rigaVerticale.png";
                                    btn3.ImageSource = "rigaVerticale.png";
                                    btn6.ImageSource = "rigaVerticale.png";
                                    break;
                                case 1:
                                    btn1.ImageSource = "rigaVerticale.png";
                                    btn4.ImageSource = "rigaVerticale.png";
                                    btn7.ImageSource = "rigaVerticale.png";
                                    break;
                                case 3:
                                    btn2.ImageSource = "rigaVerticale.png";
                                    btn5.ImageSource = "rigaVerticale.png";
                                    btn8.ImageSource = "rigaVerticale.png";
                                    break;
                                default:
                                    break;
                            }
                            DisableBtnClick();
                            Score(player);
                            await Task.Delay(1250);
                            Clear();
                            return;
                        }
                    }
                }

                if (player == arrPosition[0])
                {
                    if (arrPosition[0] == arrPosition[4] && arrPosition[0] == arrPosition[8])
                    {
                        //Debug.WriteLine($"Player {player} ha vinto!");
                        btn0.ImageSource = "rigaObliquaSinistra.png";
                        btn4.ImageSource = "rigaObliquaSinistra.png";
                        btn8.ImageSource = "rigaObliquaSinistra.png";
                        DisableBtnClick();
                        Score(player);
                        await Task.Delay(1250);
                        Clear();
                        return;
                    }
                }

                if (player == arrPosition[2])
                {
                    if (arrPosition[2] == arrPosition[4] && arrPosition[2] == arrPosition[6])
                    {
                        //Debug.WriteLine($"Player {player} ha vinto!");
                        btn2.ImageSource = "rigaObliquaDestra.png";
                        btn4.ImageSource = "rigaObliquaDestra.png";
                        btn6.ImageSource = "rigaObliquaDestra.png";
                        DisableBtnClick();
                        Score(player);
                        await Task.Delay(1250);
                        Clear();
                        return;
                    }

                }

            }
            if (spin <= 1)
            {
                DisableBtnClick();
                scoreTie += 1;
                lblScoreTie.Text = scoreTie.ToString();
                _ = TextToSpeech.SpeakAsync($"Avete pareggiato. Siete Bravi!!! Riproviamo");
                await Application.Current.MainPage.DisplayAlert("PAREGGIO", "Siete Bravi!!!", "Riproviamo");
                Clear();
            }


        }
        public async void Score(string player)
        {
            if (player == "X")
            {
                if (lblPlayerX.Text != string.Empty)
                {
                    _ = TextToSpeech.SpeakAsync($"Punto per {lblPlayerX.Text}");
                   // await Task.Delay(1250);
                    await Application.Current.MainPage.DisplayAlert("VITTORIA", $"Punto per {lblPlayerX.Text}", "Ok");
                    
                }
                else
                {
                    _ = TextToSpeech.SpeakAsync($"Punto per player {player}");
                   // await Task.Delay(1250);
                    await Application.Current.MainPage.DisplayAlert("VITTORIA", $"Punto per Player {player}", "Ok");
                    
                }
               
                scoreX += 1;
                lblScoreX.Text = scoreX.ToString();
            }
            else
            {
                if (lblPlayerO.Text != string.Empty)
                {
                    _ = TextToSpeech.SpeakAsync($"punto per {lblPlayerO.Text}");
                    //await Task.Delay(1250);
                    await Application.Current.MainPage.DisplayAlert("VITTORIA", $"Punto per {lblPlayerO.Text}", "Ok");
                }
                else
                {
                    _ = TextToSpeech.SpeakAsync($"Punto per player zero");
                    //await Task.Delay(1250);
                    await Application.Current.MainPage.DisplayAlert("VITTORIA", $"Punto per Player {player}", "Ok");
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

            btn0.ImageSource = null; btn1.ImageSource = null; btn2.ImageSource = null;
            btn3.ImageSource = null; btn4.ImageSource = null; btn5.ImageSource = null;
            btn6.ImageSource = null; btn7.ImageSource = null; btn8.ImageSource = null;

            btn0.IsEnabled = true; btn1.IsEnabled = true; btn2.IsEnabled = true;
            btn3.IsEnabled = true; btn4.IsEnabled = true; btn5.IsEnabled = true;
            btn6.IsEnabled = true; btn7.IsEnabled = true; btn8.IsEnabled = true;

            spin = 9;
        }

        public void DisableBtnClick()
        {
            btn0.IsEnabled = false; btn1.IsEnabled = false; btn2.IsEnabled = false;
            btn3.IsEnabled = false; btn4.IsEnabled = false; btn5.IsEnabled = false;
            btn6.IsEnabled = false; btn7.IsEnabled = false; btn8.IsEnabled = false;
        }
    }
}
