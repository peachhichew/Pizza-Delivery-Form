# Pizza Delivery Form

This is a GUI that simulates an online pizza ordering form for a place called "Wooferoni Pizzur". This GUI isn't meant to look horrendous, just a little troll. There are buttons you can press and keyboard interactions to check for valid data, which creates certain effects. For example, there is a “Seekrit button” that moves to a random location when the mouse hovers over it. The form asks for basic information such as name, date, address, details about your pizza, special instructions, and other options you would like to add. There are also radio buttons and check boxes that allow you to customize your pizza to your heart’s content. You can also remove certain items if you wish to.

## Events

- Radio Buttons: smallCrust, mediumCrust, largeCrust, pawmadeCrust, crunchyCrust, deepDishCrust (Note that the crust sizes are grouped together in a Group Box and the crust types are grouped together as well!)

  When these buttons are checked, their text will be appear to be highlighted. For example, if the smallCrust radio button has been checked, the background color of the text will be yellow while the mediumCrust and largeCrust will remain the same color as it was originally.

- secretButton_MouseEnter: Whenever the user hovers over the “Seekrit Button”, the button will reappear at a random location in the window, as long as it’s in the area where you fill out the form and not hidden behind the gif or outside the window.

- zipCodeTextBox_KeyPress: When the user presses ENTER, the form checks to see if valid data has been entered in the zip code text box and displays a message box. If the zip code entered is valid, the background color of the form will change.

- removeTextBox_KeyPress: When the user presses ENTER, the form checks to see if data entered in the Other Options box matches with the data in Remove’s text box or if the data matches the string “pizza”. Displays a pop-up box saying it does or it doesn’t. If the item is successfully removed, the background color of the form will change.

- submitButton_Click: Checks to see if all the necessary data has been provided. This method also checks for data validation in the form (for example, checking the length of the zip code and whether it can be parsed or not). The background color of the form changes after the button has been pressed.

- PrintReceipt( ): This method reverses the string entered in the Speshul Instruktions (Special Instructions) text box. When the method is called in submitButton_Click( ), the message box that appears as a receipt for the order will display the reversed string.
