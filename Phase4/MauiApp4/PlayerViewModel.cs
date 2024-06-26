namespace MauiApp4;

using System.Collections.ObjectModel;
public class PlayerViewModel
{
    public ObservableCollection<ListModel> MyPlayers { get; set; } = new ObservableCollection<ListModel> {
    new ListModel
    {
        Name = "Krunal Patel",
        Image = "dotnet_bot.png"
    },
    new ListModel
    {
        Name = "Milind Patel",
        Image = "dotnet_bot.png"
    },
    new ListModel
    {
        Name = "Deep Patel",
        Image = "dotnet_bot.png"
    },
    new ListModel
    {
        Name = "Udhdhav Rathod",
        Image = "dotnet_bot.png"
    },
    new ListModel
    {
        Name = "Anurag Ganvit",
        Image = "dotnet_bot.png"
    },
    new ListModel
    {
        Name = "Poorav Patel",
        Image = "dotnet_bot.png"
    },
    new ListModel
    {
        Name = "Dhvanil Patel",
        Image = "dotnet_bot.png"
    }
    };

    public Command<ListModel> DeletePlayer { get; private set; }

    public PlayerViewModel()
    {
        DeletePlayer = new Command<ListModel>(model => 
        { MyPlayers.remove(model); });
    }
}