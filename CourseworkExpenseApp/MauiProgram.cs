﻿using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using CourseworkExpenseApp.Services;

namespace CourseworkExpenseApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<ICashFlowService, CashFlowService>();
            builder.Services.AddSingleton<IDebtFlowService, DebtFlowService>();
            builder.Services.AddSingleton<AuthenticationStateService>();

            builder.Services.AddSingleton<AppState>();



#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddMudServices();

#endif

            return builder.Build();
        }
    }
}
