
using System.ComponentModel;


namespace EmployeeComponent
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private string _firstName = "";

        public EmployeeViewModel()
        {


        }
        public int Id { get; set; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
  
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
