using Microsoft.Maui.Layouts;

namespace MatchGame2431096;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        SetUpGame();

        IDispatcherTimer timer;
        timer = Dispatcher.CreateTimer();
        int count = 0;
        Timerlbl.Text = "0";
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            count += 1;
            Timerlbl.Text = count.ToString();
        };
        timer.Start();
    }
    private void SetUpGame()
    {
        List<string> animalEmoji = new List<string>()
        {
            "😀","🐖",
            "👺","🙉",
            "👻","👨‍🦽",
            "🦍","🐪",
            "😈","👨‍🦯",
            "🦶","💀",
            "🧜‍♂️","🧙‍♂️",
            "🧓","🤙",
        };
        Random random = new Random();
        foreach (Button view in Grid1.Children)
        {
            int index = random.Next(animalEmoji.Count);

            string nextEmoji = animalEmoji[index];

            view.Text = nextEmoji;
            animalEmoji.RemoveAt(index);
        };


    }
    Button ultimoButtonClicked;
    bool encontrandoMatch = false;

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (encontrandoMatch == false)
        {
            button.IsVisible = false;
            ultimoButtonClicked = button;
            encontrandoMatch = true;
        }
        else if (button.Text == ultimoButtonClicked.Text)
        {
            button.IsVisible = false;
            encontrandoMatch = false;
        }
        else
        {
            ultimoButtonClicked.IsVisible = true;
            encontrandoMatch = false;
        }
    }
  
    private void ButtonReiniciarClicked (object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }
}

