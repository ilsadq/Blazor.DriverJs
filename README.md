# Blazor DriverJs

C# wrapper for [driverjs](https://driverjs.com/) library

## Examples

The `DriverStore` component is used here to store references to Popovers and to run drive.

`DriverJsPopover` is a component that represents a popover in which we specify the step in which it will be called by passing parameters such as title, description, ...

To be able to work with `DriverStore` we must declare a reference variable to interact with the api.

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

  [Inject] public DriverJs DriverJs { get; set; }

}
```
