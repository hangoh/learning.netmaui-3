using System.Diagnostics;

namespace quotes;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

    void generate_button_Clicked(System.Object sender, System.EventArgs e)
    {
        int[] startColor = rndrgb();
        int[] endColor = rndrgb();
        color_start.Color = Color.FromRgb(startColor[0], startColor[1], startColor[2]);
        color_end.Color = Color.FromRgb(endColor[0], endColor[1], endColor[2]);
        changeQuote();
    }

	static int[] rndrgb() {
        Random rnd = new Random();
        int r = rnd.Next(0, 256);
        int g = rnd.Next(0, 256);
        int b = rnd.Next(0, 256);
        List<int> rgb = new List<int>();
        rgb.Add(r);
        rgb.Add(g);
        rgb.Add(b);
        int[] colorRGB = rgb.ToArray();
        return colorRGB;
    }

    async void changeQuote() {
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("quotes.txt");
        using StreamReader sr = new(fileStream);
        List<string> quotes = new List<string>();
        Random rnd = new Random();
        while (sr.ReadLine() != null) {
            quotes.Add(sr.ReadLine());
        }
        int endArray = quotes.Count + 1;
        string[] quotesArray = quotes.ToArray();
        quote_label.Text = quotesArray[rnd.Next(0, endArray)];
    }

}


