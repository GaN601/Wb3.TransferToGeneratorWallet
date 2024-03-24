using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace GaN.Web3.Action;

class Program : MauiApplication
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    static void Main(string[] args)
    {
        var app = new Program();
        app.Run(args);
    }
}