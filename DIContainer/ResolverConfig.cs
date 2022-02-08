﻿using BL.Services.Account;
using BL.Services.ATM;
using BL.Services.Client;
using BL.Services.Common;
using BL.Services.Credit;
using BL.Services.Deposit;
using BL.Services.Transaction;
using Microsoft.Practices.Unity;
using AppContext = ORMLibrary.AppContext;

namespace DIContainer
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IUnityContainer kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IUnityContainer kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IUnityContainer kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.RegisterType<AppContext, AppContext>(new PerThreadLifetimeManager());
            }
            else
            {
                kernel.RegisterType<AppContext, AppContext>();
            }

            #region Services

            kernel.RegisterType<IPlanOfAccountService, PlanOfAccountService>();
            kernel.RegisterType<IAccountService, AccountService>();           
            kernel.RegisterType<IAtmService, AtmService>();
            kernel.RegisterType<IBankService, BankService>();
            kernel.RegisterType<ISystemInformationService, SystemInformationService>();
            kernel.RegisterType<ICreditService, CreditService>();
            kernel.RegisterType<IPlanOfCreditService, PlanOfCreditService>();
            kernel.RegisterType<IDepositService, DepositService>();
            kernel.RegisterType<IPlanOfDepositService, PlanOfDepositService>();
            kernel.RegisterType<ITransactionService, TransactionService>();
            kernel.RegisterType<IClientService, ClientService>();

            #endregion

            #region Repositories 

            #endregion


        }
    }
}
