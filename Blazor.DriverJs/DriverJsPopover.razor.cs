using Blazor.DriverJs.Enums;
using Blazor.DriverJs.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.DriverJs;

public partial class DriverJsPopover : IAsyncDisposable
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

    protected override void OnInitialized()
    {
        OnDisableButtonUpdate += UpdateDisableButtons;
        OnShowButtonUpdate += UpdateShowButtons;
        base.OnInitialized();
    }

    private void UpdateShowButtons(object? sender, EventArgs args)
    {
        var buttons = new List<string>();

        if (ShowNextButton) buttons.Add(DriverJsDefaultValues.ButtonNext);
        if (ShowCloseButton) buttons.Add(DriverJsDefaultValues.ButtonClose);
        if (ShowPreviousButton) buttons.Add(DriverJsDefaultValues.ButtonPrevious);

        Model.ShowButtons = buttons.Count > 0 ? buttons.ToArray() : null;
    }

    private void UpdateDisableButtons(object? sender, EventArgs args)
    {
        var buttons = new List<string>();

        if (DisableCloseButton) buttons.Add(DriverJsDefaultValues.ButtonClose);
        if (DisableNextButton) buttons.Add(DriverJsDefaultValues.ButtonNext);
        if (DisablePreviousButton) buttons.Add(DriverJsDefaultValues.ButtonPrevious);

        Model.DisableButtons = buttons.Count > 0 ? buttons.ToArray() : null;
    }

    public ValueTask DisposeAsync()
    {
        OnDisableButtonUpdate -= UpdateDisableButtons;
        OnShowButtonUpdate -= UpdateShowButtons;
        Store.RemovePopover(Step);
        return ValueTask.CompletedTask;
    }
}