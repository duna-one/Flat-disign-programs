# How it works

## Table of contents

1. [Styles](#Styles)
2. [Controls](#Controls)


## <a name="Styles"></a>  Styles
### KeyboardButton
- Margin **5**
- FontSize **20**
- (Border)CornerRadius **20**

### OutputTextBox
- HorizontalContentAlignment **Right**
- VerticalContentAlignment **Center**
- FontSize **24**
- TextWrapping **Wrap**
- Margin **5,0,5,0**
- IsReadOnly **True**
- (Border)CornerRadius **20**

### TitleButton
- Margin **5**
- HorizontalContentAlignment **Center**
- VerticalContentAlignment **Center**
- Width **30**
- FontSize **20**
- (Border)CornerRadius **20**

### TitleText
- FontSize **14**
- HorizontalContentAlignment **Center**
- HorizontalAlignment **Center**


## <a name="Controls"></a> Controls
### Window title

Window title is intended to replace standard controls, since the style of the main window is set to None, in order to implement rounded corners and custom window design.

The header consists of a Grid containing a Label and a stack panel. The stack panel in turn contains 2 buttons.

Implementation:

    <Grid Margin="5">
         <Grid.ColumnDefinitions>
             <ColumnDefinition/>
             <ColumnDefinition Width="65"/>
          </Grid.ColumnDefinitions>        
          <Label Name="TitleLabel" Content="Title" Width="235" Style="{StaticResource TitleText}" MouseLeftButtonDown="MoveWindow"/>        
          <StackPanel Orientation="Horizontal" Grid.Column="1">
              <Button Content="_" Style="{StaticResource TitleButton}" Click="MiniButton_Click"/>
             <Button Content="X" Style="{StaticResource TitleButton}" Click="CloseButton_Click"/>
          </StackPanel>
    </Grid>

The buttons refer to the TitleButton style and have a "Click" event handler. And the label also has a handler for the "MouseLeftButtonDown" event

        private void MiniButton_Click(object sender, RoutedEventArgs e)
        {
            Window myWindow = Window.GetWindow(this);
            myWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            Window myWindow = Window.GetWindow(this);
            myWindow.DragMove();
        }
        
These handlers allow you to close, minimize, and move the application window.

### Keyboard
The keyboard consists of 24 buttons located on a Grid, divided into 4 columns and 6 rows.

This control was created for the convenience of working with the input and simplifying the further expansion of the functionality (if any is planned)

The click event handler is the same for all buttons. It creates a "KeyClick" event and sends a character indicating the text value of the button via the sender argument:

        public event RoutedEventHandler KeyClick;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] button = sender.ToString().Split();
            KeyClick?.Invoke(button[1], e);
        }