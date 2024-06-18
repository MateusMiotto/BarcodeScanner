using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;


namespace BarcodeTeste;

public partial class MvvmDemo : ContentPage
{
    public MvvmDemo()
    {
        InitializeComponent();
        On<iOS>().SetUseSafeArea(true);


    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        try
        {

            CheckAndRequestCameraPermissionAsync();
        }
        catch (Exception ex)
        {

        }
    }


    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }

    public static async Task<bool> CheckAndRequestCameraPermissionAsync()
    {
        bool cameraPermissionGranted = await CheckCameraPermision();
        if (!cameraPermissionGranted)
        {
            // Se a permissão não estiver concedida, solicita-a
            cameraPermissionGranted = await RequestCameraPermissionAsync();
            // Aqui você pode lidar com o resultado da solicitação da permissão
        }
        return cameraPermissionGranted;
    }
    private static async Task<bool> RequestCameraPermissionAsync()
    {
        var status = await Permissions.RequestAsync<Permissions.Camera>();
        return status == PermissionStatus.Granted;
    }
    public static async Task<bool> CheckCameraPermision()
    {
        try
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            return status == PermissionStatus.Granted;
        }
        catch
        {
            return false;
        }
    }
}