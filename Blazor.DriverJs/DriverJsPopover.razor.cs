using Blazor.DriverJs.Enums;
using Blazor.DriverJs.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.DriverJs;

public partial class DriverJsPopover : IDisposable
{
    private ElementReference Ref
    {
        set
        {
            Model.Element = value;
            Store.AddPopover(Step, Model);
        }
    }

    [CascadingParameter] public DriverStore Store { get; set; }

    private void UpdateShowButtons()
    {
        var buttons = new List<string>();

        if (ShowNextButton) buttons.Add(DriverJsDefaultValues.ButtonNext);
        if (ShowCloseButton) buttons.Add(DriverJsDefaultValues.ButtonClose);
        if (ShowPreviousButton) buttons.Add(DriverJsDefaultValues.ButtonPrevious);

        Model.ShowButtons = buttons.Count > 0 ? buttons.ToArray() : null;
    }

    private void UpdateDisableButtons()
    {
        var buttons = new List<string>();

        if (DisableCloseButton) buttons.Add(DriverJsDefaultValues.ButtonClose);
        if (DisableNextButton) buttons.Add(DriverJsDefaultValues.ButtonNext);
        if (DisablePreviousButton) buttons.Add(DriverJsDefaultValues.ButtonPrevious);

        Model.DisableButtons = buttons.Count > 0 ? buttons.ToArray() : null;
    }

    public void Dispose()
    {
        Store.RemovePopover(Step);
    }
}