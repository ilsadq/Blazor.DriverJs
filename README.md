# Blazor DriverJs

C# wrapper for [driverjs](https://driverjs.com/) library

# Installation

`dotnet add package Blazor.DriverJs`

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

@code {

  private ElementReference _ref;

  private async Task ClickHandler()
  {
      await DriverJs.Highlight(new HighlightModel(_ref)
      {
          Title = "Hello World",
      });
  }

}
```

# Preview

![record](./media/video.gif)
