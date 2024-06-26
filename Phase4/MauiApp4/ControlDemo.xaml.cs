namespace MauiApp4;

public partial class ControlDemo : ContentPage
{
	public ControlDemo()
	{
		InitializeComponent();
		BindingContext = new PlayerViewModel();
	}
	private void imgBtn_Clicked(object sender, EventArgs e)
	{
		DisplayAlert("Alert", "You Clicked the image", "OK");
	}
	private void btn_Clicked(object sender, EventArgs e)
	{
		DisplayAlert("Alert", "You Clicked the Button", "OK");
	}
	private void searchBar_SearchButtonPressed(object sender, EventArgs e)
	{
		infoLabel.Text = $"Searching for {searchBar.Text}";
	}
	private void RadioButton_CheckedChanged(object sender,
		CheckedChangedEventArgs e)
	{
		RadioButton sexBtn = sender as RadioButton;
		infoLabel.Text = $"I see you are {sexBtn.Content}";
	}
	private void CheckBox_CheckedChanged(object sender,
	CheckedChangedEventArgs e)
	{
		infoLabel.Text = $"Clicked CheckBox {e.Value}";
	}

	private void Switch_Toggle(object sender, ToggledEventArgs e)
	{
		infoLabel.Text = $"Clicked Toggle {e.value}";
	}
	private void SwipeItem_Invoked(object sender, EventArgs e)
	{
		infoLabel.Text = $"Marked as Favorite";

	}
	private void SwipeItem_Invoked_1(object sender, EventArgs e)
	{
		infoLabel.Text = $"Marked as Delete";

	}
	private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		sliderLabel.Text = $"People Attending {Convert.ToInt32(slider.Value)}";
	}
	private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		stepperLabel.Text = $"People Paying {Convert.ToInt32(stepper.Value)}";
	}
	private void entry_Completed(object sender, EventArgs e)
	{
		infoLabel.Text = $"Hello {entry.Text}";
	}
	private void Steelers_ItemSelected(object sender,
		SelectedItemChangedEventArgs e)
	{
		string player = "", playerData = "";

		switch (e.SelectedItem)
		{
			case ListModel m when m.Name.StartsWith("Krunal"):
				player = "Krunal Patel";
				playerData = "Hello new developer to the .net community";
				break;
            case ListModel m when m.Name.StartsWith("Milind"):
                player = "Milind Patel";
                playerData = "Hello new developer to the .net community";
                break;
            case ListModel m when m.Name.StartsWith("Deep"):
                player = "Deep Patel";
                playerData = "Hello new developer to the .net community";
                break;
            case ListModel m when m.Name.StartsWith("Udhdhav"):
                player = "Udhdhav Rathod";
                playerData = "Hello new developer to the .net community";
                break;
            case ListModel m when m.Name.StartsWith("Dhvanil"):
                player = "Dhvanil Patel";
                playerData = "Hello new developer to the .net community";
                break;
            case ListModel m when m.Name.StartsWith("Anurag"):
                player = "Anurag Ganvit";
                playerData = "Hello new developer to the .net community";
                break;
            case ListModel m when m.Name.StartsWith("Poorav"):
                player = "Poorav Patel";
                playerData = "Hello new developer to the .net community";
                break;
        }
		DisplayAlert($"{player}", $"{playerData}", "Ok");
    }
}