using CommunityToolkit.Mvvm.Messaging;

namespace SampleApp;

public partial class SecondPage : ContentPage
{
	public SecondPage()
	{
		InitializeComponent();

	}

    protected override void OnAppearing()
    {
        BindingContext = new SecondPageViewModel();

        var isRegister = WeakReferenceMessenger.Default.IsRegistered<SecondPage>(this);
        if (!isRegister)
        {
            WeakReferenceMessenger.Default.Register<SecondPage, DeleteMessage>(this, async (r, m) =>
            {
                var result = await r.DisplayAlert("Warning", "Delete?", "Yes", "No");
                m.Reply(result);
            });
        }
    }

    protected override void OnDisappearing()
    {
        WeakReferenceMessenger.Default.Unregister<DeleteMessage>(this);
    }
}