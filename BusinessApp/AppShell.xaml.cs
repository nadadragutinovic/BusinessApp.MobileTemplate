using BusinessApp.Features.Dashboard.Views;

namespace BusinessApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        }
    }
}
