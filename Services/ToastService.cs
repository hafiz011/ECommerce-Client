namespace Ecommerce.Client.Services
{
    public enum ToastType
    {
        Success,
        Error,
        Warning,
        Info
    }

    public class ToastService
    {
        public event Action<string, ToastType>? OnShow;

        public void ShowToast(string message, ToastType type)
        {
            OnShow?.Invoke(message, type);
        }

        public void ShowSuccess(string message) => ShowToast(message, ToastType.Success);
        public void ShowError(string message) => ShowToast(message, ToastType.Error);
        public void ShowWarning(string message) => ShowToast(message, ToastType.Warning);
        public void ShowInfo(string message) => ShowToast(message, ToastType.Info);
    }

}
