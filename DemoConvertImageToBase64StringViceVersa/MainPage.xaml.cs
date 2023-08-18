namespace DemoConvertImageToBase64StringViceVersa
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnSelectImage_Clicked(object sender, EventArgs e)
        {
            List<ImageModel> Images = new List<ImageModel>();

            Images.Add(new ImageModel() { Name = "about.jpg"});
            Images.Add(new ImageModel() { Name = "bookings.jpg" });
            Images.Add(new ImageModel() { Name = "contact.png" });
            Images.Add(new ImageModel() { Name = "home.png" });

           foreach(var image in Images)
            {
                //Converting image to base64sting
                using var EnStream = await FileSystem.OpenAppPackageFileAsync(image.Name);
                using var mstream = new MemoryStream();
                EnStream.CopyTo(mstream);
                var convertImage = Convert.ToBase64String(mstream.ToArray());
                Base64String.Text = convertImage;
                ImageLabel.Source = image.Name;

                // Converting image from base64string
                var imageByteSize = Convert.FromBase64String(convertImage);
                MemoryStream memoryStream = new(imageByteSize);
                ImageFromBase.Source = ImageSource.FromStream(()=> memoryStream);

                await Task.Delay(3000);
            }

        }
    }

}
