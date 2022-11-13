// Breads Class

namespace SandwichMidtermPractice.Model
{
  public class SandwichBread 
  {
    public SandwichBread()
    {
    }
    
    public  SandwichBread(string name, double price) 
    {
      Name = name;
      Price = price;
    }
    
    public string Name { get; set; }
    public double Price { get; set; }
  }
}

// Insert in xaml.cs

// Reading sandwich breads information from json docment
private void ImportSandwichBreadsButton_Click(object sender, RoutedEventArgs e)
{
  OpenFileDialog openFileDialog = new OpenFileDialog();
  if (openFileDialog.ShowDialog() == true)
  {
    string sandwichBreadsText = File.ReadAllText(openFileDialog.FileName);
    List<SandwichBread> breads = JsonConvert.DeserializeObject<List<SandwichBread>>(sandwichBreadsText);
    
    foreach (var entry in breads) {
      RadioButton sandwichBreadRadioButton = new();
      
      sandwichBreadRadioButton.Content = $"{entry.Name} (€ {entry.Price.ToString("N2")})";
      sandwichBreadRadioButton.Tag = entry;
      sandwichBreadRadioButton.Checked += SandwichBreadRadioButton_Checked;
      sandwichBreadRadioButton.Unchecked += SandwichBreadRadioButton_Unchecked;
      
      SandwichBreadsStackPanel.Children.Add(sandwichBreadRadioButton);
    }
  }
}


// Closing window correctly

//// IN WINDOW ( THE MOST FIRST IN XAML )
< Window
  ...
  Closing="Window_Closing"
  >

public void  Window_closing (object sender, System.ComponentModel.CancelEventArgs)
{
  e.Cancel = true;
  this.Visibility = Visibility.Hidden;
}
