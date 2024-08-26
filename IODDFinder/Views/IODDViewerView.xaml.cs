using IODDFinder.ViewModels;

namespace IODDFinder.Views;

public partial class IODDViewerView : ContentPage
{
	private readonly IODDViewerViewModel _ioddViewerViewModel;

    public IODDViewerView(IODDViewerViewModel ioddViewerViewModel)
	{
		InitializeComponent();
        _ioddViewerViewModel = ioddViewerViewModel;
		BindingContext = _ioddViewerViewModel;
	}
}
