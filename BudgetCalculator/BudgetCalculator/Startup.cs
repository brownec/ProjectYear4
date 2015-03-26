using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetCalculator.Startup))]
namespace BudgetCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
