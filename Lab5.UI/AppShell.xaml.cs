using Lab5.UI.Pages;

namespace Lab5.UI {
    public partial class AppShell : Shell {
        public AppShell() {
            Routing.RegisterRoute(nameof(Details),
                typeof(Details));
            InitializeComponent();
        }
    }
}