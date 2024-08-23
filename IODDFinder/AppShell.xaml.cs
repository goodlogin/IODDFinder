using IODDFinder.Views;

namespace IODDFinder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ProductsView), typeof(ProductsView));
        Routing.RegisterRoute(nameof(ProductDetailsView), typeof(ProductDetailsView));
    }
}

