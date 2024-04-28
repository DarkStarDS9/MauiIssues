namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void Button_OnClicked(object? sender, EventArgs e)
	{
		if(sender is not Button btn) return;

		await Shell.Current.GoToAsync($"//{btn.Text}");
	}
}

