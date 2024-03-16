# Blazor DriverJs

C# wrapper for [driverjs](https://driverjs.com/) library

# Installation

```ps
dotnet add package Blazor.DriverJs
```

Add to head

```html
<link rel="stylesheet" href="_content/Blazor.DriverJs/driverjs.css">
```

Add to body
```html
<script src="_content/Blazor.DriverJs/driverjs.js"></script>
```

# Examples

## Default drive

The `DriverStore` component is used here to store references to Popovers and to run the drive.

`DriverJsPopover` is a component that represents a popover in which we specify the step in which it will be called by passing parameters such as title, description, ...

`DriverJsPopoverId` analogous to DriverJsPopover, but in this place there is a link to the element id.

To be able to work with `DriverStore` we must declare a reference variable to interact with the API.

```html
<button @onclick="async () => await _store.StartDrive()">
    Start drive
</button>

<div class="gallery__wrapper">
    <DriverStore @ref="_store">
        <DriverJsPopover Step="1" Title="It's a fish with a nice hat">
            <img src="https://i.pinimg.com/564x/d5/ba/a9/d5baa9d87ceccbcbb8c679b53dc07293.jpg" alt="">
        </DriverJsPopover>

        <DriverJsPopover Step="2" Title="It's a smiley face." Description="He's very happy...">
            <img src="https://i.pinimg.com/564x/29/70/52/2970520b7069945d60d4d3482691f9d7.jpg" alt="">
        </DriverJsPopover>

        <DriverJsPopover Step="3" Title="And that's a cool smiley face">
            <img src="https://i.pinimg.com/736x/40/bb/da/40bbdac7db3945f95eb9cfe572d36ecd.jpg" alt="">
        </DriverJsPopover>

        <DriverJsPopoverId Step="4" Title="Hello World">
            <img src="https://i.pinimg.com/736x/40/bb/da/40bbdac7db3945f95eb9cfe572d36ecd.jpg" alt=""
                 id="@context">
        </DriverJsPopoverId>
    </DriverStore>
</div>

@code {

  private DriverStore _store;

}
```

## Highlight

To highlight a single object, we can use the `DriverJs` service and call the Highlight method by passing it a `HighlightModel`.

```html
<button @onclick="ClickHandler" @ref="_ref">
    Click me
</button>

<button @onclick="ClickHandler2" id="super-button">
    Click me
</button>

@code {

  private ElementReference _ref;

  private async Task ClickHandler()
  {
      await DriverJs.Highlight(new HighlightModel(_ref)
      {
          Title = "Hello World",
      });
  }

  private async Task ClickHandler2()
  {
      await DriverJs.Highlight(new HighlightModel("super-button")
      {
          Title = "Hello World",
      });
  }

}
```

## Get current step

To get the step number, subscribe to the `OnNextStep` event, which returns the step number.

To retrieve the Popover model, utilize the `DriverStore` reference object, which includes the `Popovers` parameter.

```html
<DriverStore @ref="_store" OnNextStep="NextStepHandler"></DriverStore>

@code {

    private DriverStore _store;

    private async Task NextStepHandler(int index)
    {
        var currentPopover = _store.Popovers[index];
    }

}
```

# Preview

![record](./media/video.gif)
