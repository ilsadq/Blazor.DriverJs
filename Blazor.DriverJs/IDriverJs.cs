using Blazor.DriverJs.Models;
using Microsoft.JSInterop;

namespace Blazor.DriverJs;
public interface IDriverJs : IDisposable
{
    Task StartDrive(DriverModel model, DotNetObjectReference<DriverStore> dotObj);
    Task Highlight(HighlightModel model);
}