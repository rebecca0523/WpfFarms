using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using AllData;

namespace WpfFarmsActivity
{
    /// <summary>
    /// ActivityManagement.xaml 的互動邏輯
    /// </summary>
    public partial class ActivityManagement : Window
    {
        public ActivityManagement()
        {
            InitializeComponent();
        }
        int count;
        FarmActivity FA = new FarmActivity();

        AllFarmsDBEntities DB = new AllFarmsDBEntities();
        AllData.ActivityFarmer addActivity = new AllData.ActivityFarmer();
        global::WpfFarmsActivity.UserControl1[] x = new UserControl1[50];
        global::WpfFarmsActivity.ActivityListItem y = new ActivityListItem();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void Activity()
        {
            var query = from c in DB.ActivityCities select c;
            addActivity = new AllData.ActivityFarmer();
            addActivity.ActivityName = FA.ActivityNameInput.Text;
            foreach (var q in query)
            {
                if (FA.CityComboBox.SelectedItem.ToString() == q.CityName)
                { addActivity.CityID = q.CityID; }
            }
            addActivity.MaxQuantity = int.Parse(FA.MaxQuantityInput.Text);
            addActivity.GroupQuantity = int.Parse(FA.GroupQuantityInput.Text);
            addActivity.Price = int.Parse(FA.PriceInput.Text);
            addActivity.ActivityDate = FA.ActivityDate.SelectedDate;
            addActivity.ActivityAddress = FA.ActivityAddressInput.Text;
            addActivity.Phone = FA.PhoneInput.Text;
            addActivity.Email = FA.EmailInput.Text;
            addActivity.ATMBank = FA.ATMBankInput.Text;
            addActivity.ATMAccount = FA.ATMAccountInput.Text;
            addActivity.CreatedDate = System.DateTime.Now;
            addActivity.LastUpdateDate = System.DateTime.Now;
            addActivity.SupplierID = 1;
            string rtfText; //string to save to db
            TextRange tr = new TextRange(FA.RichTextBox1.Document.ContentStart, FA.RichTextBox1.Document.ContentEnd);
            using (MemoryStream ms = new MemoryStream())
            {
                tr.Save(ms, DataFormats.Rtf);
                rtfText = Encoding.ASCII.GetString(ms.ToArray());
            }
            addActivity.ActivityContent = rtfText;
            DB.ActivityFarmers.Add(addActivity);
            DB.SaveChanges();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FA = new FarmActivity();
            var q = from a in DB.ActivityCities select a.CityName;
            FA.ActivityAddressInput.DataContext = DB.Suppliers.First();
            FA.PhoneInput.DataContext = DB.Suppliers.First();
            FA.EmailInput.DataContext = DB.Suppliers.First();
            FA.CityComboBox.ItemsSource = q.ToList();
            FA.ActivityDate.SelectedDate = System.DateTime.Today;
            FA.Show();
            FA.Accept.Click += new RoutedEventHandler(Accept_Click);
            FA.Cancel.Click += new RoutedEventHandler(Cancel_Click);
            FA.ImageAddbtn.Click += new RoutedEventHandler(ImageAddbtn_Click);
        }

        private void ImageAddbtn_Click(object sender, RoutedEventArgs e)
        {
            string filename = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.png;*.jpg;*.gif(Image Files)|*.png;*.jpg;*.gif";
            if (ofd.ShowDialog() == true)
            {
                filename = ofd.FileName;
                //建立段落
                Paragraph para = new Paragraph();
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                double w, h;
                image.Source = GetImage(filename, out w, out h);
                image.Width = 80;
                image.Height = 60;
                para.Inlines.Add(image);//插入圖片到段落
                FA.RichTextBox1.Document.Blocks.Add(para);//插入段落到RichTextBox1
            }
        }
        public static BitmapImage GetImage(string filePath, out double width, out double height)
        {
            BitmapImage b = new BitmapImage();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                System.Drawing.Image img = null;
                img = (Bitmap)System.Drawing.Image.FromStream(fs);
                float r = img.HorizontalResolution;
                width = img.Width;
                height = img.Height;
                using (Bitmap bmp = new Bitmap((int)width, (int)height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmp.SetResolution(r, r);
                            g.DrawImage(img, new System.Drawing.Rectangle(0, 0, img.Width, img.Height), new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                            bmp.Save(ms, ImageFormat.Png);
                            b.BeginInit();
                            b.CacheOption = BitmapCacheOption.OnLoad;
                            b.StreamSource = ms;
                            b.EndInit();
                        }
                    }
                }
            }
            return b;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Activity();
            MessageBox.Show("活動編號" + addActivity.ActivityFarmerID + "新增成功!");
            x[count] = new UserControl1();
            x[count].Name = addActivity.ActivityFarmerID;
            x[count].addActivity.Click += new RoutedEventHandler(AddActivity_Click);
            x[count].EditActivity.Click += new RoutedEventHandler(EditActivity_Click);
            x[count].ActivityName.Name = "ActivityName" + addActivity.ActivityFarmerID;
            x[count].Image.Name = "Image" + addActivity.ActivityFarmerID;
            x[count].ActivityName.Content = FA.ActivityNameInput.Text;
            this.ListWrapPanel.Children.Add(x[count]);
            FA.Hide();
            count++;
        }
        void updateActivity()
        {
            var query = from q in DB.ActivityFarmers select q;
            foreach (var activityfarm in query)
            {
                addActivity.ActivityName = FA.ActivityNameInput.Text;
                if (int.Parse(this.x[count].Name) == activityfarm.ActivityFarmerID)
                {
                    var city = from q in DB.ActivityCities select q;
                    foreach (var selectcity in city)
                    {
                        if(activityfarm.CityID==selectcity.CityID)
                        {
                            FA.CityComboBox.SelectedItem = selectcity.CityName;
                        }
                    }
                    FA.MaxQuantityInput.Text = activityfarm.MaxQuantity.Value.ToString();
                    FA.GroupQuantityInput.Text = activityfarm.GroupQuantity.Value.ToString();
                    FA.PriceInput.Text = activityfarm.Price.Value.ToString();
                    FA.ActivityDate.SelectedDate = activityfarm.ActivityDate;
                    FA.ActivityAddressInput.Text = activityfarm.ActivityAddress;
                    FA.PhoneInput.Text = activityfarm.Phone;
                    FA.EmailInput.Text = activityfarm.Email;
                    FA.ATMBankInput.Text = activityfarm.ATMBank;
                    FA.ATMAccountInput.Text = activityfarm.ATMAccount;
                    string rtfText = activityfarm.ActivityContent;
                    byte[] byteArray = Encoding.ASCII.GetBytes(rtfText);
                    using (MemoryStream ms = new MemoryStream(byteArray))
                    {
                        TextRange tr = new TextRange(FA.RichTextBox1.Document.ContentStart, FA.RichTextBox1.Document.ContentEnd);
                        tr.Load(ms, DataFormats.Rtf);
                    }
                    //DB.SaveChanges();
                    FA.Show();
                }
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            FA.Hide();
        }
        private void EditActivity_Click(object sender, RoutedEventArgs e)
        {
            updateActivity();
            
        }
        private void AddActivity_Click(object sender, RoutedEventArgs e)
        {
            ActivityList activity = new ActivityList();
            activity.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ActivityWeb Web = new ActivityWeb();
            Web.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FA.Close();
        }
    }
}
