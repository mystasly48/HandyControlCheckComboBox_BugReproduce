using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HandyControlCheckComboBoxTest {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      // This works
      CheckComboBox1.ItemsSource = new List<Item> {
        new Item("Item 1", true),
        new Item("Item 2", false)
      };

      // This doesn't work
      CheckComboBox2.ItemsSource = new List<Item> {
        new Item("Item 1", true),
        new Item("Item 2", true)
      };
    }

    private void CheckComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      var added = e.AddedItems.Cast<Item>();
      var removed = e.RemovedItems.Cast<Item>();
      Debug.WriteLine("CheckComboBox1_SelectionChanged");
      Debug.WriteLine($"  Added: {string.Join(", ", added)}");
      Debug.WriteLine($"  Removed: {string.Join(", ", removed)}");
    }

    private void CheckComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      var added = e.AddedItems.Cast<Item>();
      var removed = e.RemovedItems.Cast<Item>();
      Debug.WriteLine("CheckComboBox2_SelectionChanged");
      Debug.WriteLine($"  Added: {string.Join(", ", added)}");
      Debug.WriteLine($"  Removed: {string.Join(", ", removed)}");
    }
  }

  public class Item {
    public string Name { get; set; }
    public bool IsSelected { get; set; }

    public Item(string name, bool selected) {
      this.Name = name;
      this.IsSelected = selected;
    }

    public override string ToString() => Name;
  }
}
