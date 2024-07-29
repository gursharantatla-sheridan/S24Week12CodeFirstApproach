using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S24Week12CodeFirstApproach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // define object of context class
        StudentContext db = new StudentContext();

        public MainWindow()
        {
            InitializeComponent();
            PopulateStandardComboBox();
        }

        private void PopulateStandardComboBox()
        {
            cmbStandard.ItemsSource = db.Standards.ToList();
            cmbStandard.DisplayMemberPath = "Name";
            cmbStandard.SelectedValuePath = "StandardId";
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            grdStudents.ItemsSource = db.Students.ToList();

            // hide unwanted columns
            grdStudents.Columns[4].Visibility = Visibility.Hidden;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Student std = new Student();
            std.Name = txtName.Text;
            std.StandardId = (int)cmbStandard.SelectedValue;
            std.Age = 8;

            db.Students.Add(std);
            db.SaveChanges();

            // refresh data grid
            grdStudents.ItemsSource = db.Students.ToList();
            grdStudents.Columns[4].Visibility = Visibility.Hidden;

            MessageBox.Show("New student added");
        }
    }
}