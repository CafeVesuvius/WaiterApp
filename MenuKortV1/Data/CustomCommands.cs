using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace MenuKortV1.Data
{
    public static class CustomCommands
    {
        // Dynamisk "Toast" (popup) function
        public static Task AToastToYou(string toastText)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var yourToast = Toast.Make(toastText, ToastDuration.Short, 14).Show(cts.Token);
            return yourToast;
        }
    }
}
