namespace MauiApp5
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var krunal = new Player
            {
                Name = "Krunal Patel",
                Info = "Has Watched All NBA Finals (1992, 1993, 1994, 1995, 1996, 1997, 1998) were Chicago Bulls Won the With Great Michel Jordan on their Side along with Scotiee Pipen, Denish Roadman, Stev Ker, Tonny Kukoch and many more with Phill Jackson as Coach"
            };

            /*
            //Creates the Binding
            Binding playerBinding = new Binding();
            //Defines the data Sources
            playerBinding.Source = krunal;
            //Defines the name of the property that is shared
            //between the source and control
            playerBinding.Path = "Name";

            lblName.SetBinding(Label.TextProperty, playerBinding);
            */
            BindingContext = krunal;
        }
    }

}
