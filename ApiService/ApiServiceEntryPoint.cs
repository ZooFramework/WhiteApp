using ZooFramework.ApiService;
using ZooFramework.Core.Enums.Account;
using ZooFramework.Core.Global;
using ZooFramework.Core.Models.Accounts;
using ZooFramework.Core.Models.Accounts.Rights;
using ZooFramework.Core.Services.Base;
using ZooFramework.Helpers;
using ZooFramework.Hosting.Core.Models.Hosting;

namespace ZooFramework.WhiteApp.ApiService
{
    public class ApiServiceEntryPoint : ApiRpcServiceBase<HostingApiRpcSettings>
    {
        private static void InitAdministratorProfileIfNeeded()
        {
            if (Profile.GetOneByName("Administrators").Result != null)
            {
                return;
            }

            var adminProfile = new Profile
            {
                Description = "Profile des administrateurs",
                ProfileName = "Administrators",
                IsDefault = true,
                ProfileType = ProfileType.Administrators
            };
            Profile.Save(adminProfile).Wait();
        }

        private static void CheckFirstInit()
        {
            ZooFrameworkEnvironment.Current.SetFirstInit(ZooFrameworkUser.Count().Result > 0).Wait();
        }

        public ApiServiceEntryPoint() : base(typeof(IApiService), typeof(ApiServiceRpc), typeof(ApiStartup))
        {
        }

        protected override void PrepareStart()
        {
            base.PrepareStart();
            RetryableHelper.RetryAction(InitAdministratorProfileIfNeeded, nameof(InitAdministratorProfileIfNeeded), 2,
                ServiceContext.Logger);
            RetryableHelper.RetryAction(CheckFirstInit, nameof(CheckFirstInit), 2, ServiceContext.Logger);
        }

        protected override void PrepareStop()
        {
        }
    }
}