using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Input;

// Name: Sky Wan
// Date: 05/09/17
// Description: This is a GUI that simulates an online pizza ordering form for a place called "Wooferoni Pizzur".
// This GUI isn't meant to look horrendous, just a little troll. There are buttons you can press and keyboard 
// interactions to check for valid data, which creates certain effects. For example, there is a “Seekrit button”
// that moves to a random location when the mouse hovers over it. The form asks for basic information such as 
// name, date, address, details about your pizza, special instructions, and other options you would like to add.
// There are also radio buttons and check boxes that allow you to customize your pizza to your heart’s content. 
// You can also remove certain items if you wish to.

namespace Wan_P5
{
    public partial class wooferoniPizzur : Form
    {
        // field for Random object
        private Random generator;
        // three lists for the address, pizza, and the receipt that confirms the order
        private List<string> address = new List<string>();
        private List<string> pizzaOrder = new List<string>();
        private List<string> receipt = new List<string>();
        // boolean that checks whether the ENTER key has been pressed
        private bool pressed;
        // three strings that hold the address, pizza, and entire order
        private string fullAddress, fullPizza, fullOrder;

        public wooferoniPizzur()
        {
            InitializeComponent();
            // display welcome message when running form
            System.Windows.Forms.MessageBox.Show(this,"HAI FRIEND. Tenks 4 visiting. Click 'OK' to start ur " + Environment.NewLine + "online order and we will delivur as fest as we ken.", "WHALECOME!!");
        }

        // smallCrust_CheckedChanged(object sender, EventArgs e)
        // parms: object sender, EventArgs e
        // returns: none
        // purpose: changes the bg color of the label based on whether it's been checked or not
        private void smallCrust_CheckedChanged(object sender, EventArgs e)
        {
            if (smallCrust.Checked) {
                smallCrust.BackColor = Color.FromArgb(252, 242, 63);
            }

            else {
                smallCrust.BackColor = this.BackColor;
            }
        }

        // mediumCrust_CheckedChanged(object sender, EventArgs e)
        // parms: object sender, EventArgs e
        // returns: none
        // purpose: changes the bg color of the label based on whether it's been checked or not
        private void mediumCrust_CheckedChanged(object sender, EventArgs e)
        {
            if (mediumCrust.Checked) {
                mediumCrust.BackColor = Color.FromArgb(252, 242, 63);
            }

            else {
                mediumCrust.BackColor = this.BackColor;
            }
        }

        // largeCrust_CheckedChanged(object sender, EventArgs e)
        // parms: object sender, EventArgs e
        // returns: none
        // purpose: changes the bg color of the label based on whether it's been checked or not
        private void largeCrust_CheckedChanged(object sender, EventArgs e)
        {
            if (largeCrust.Checked) {
                largeCrust.BackColor = Color.FromArgb(252, 242, 63);
            }

            else {
                largeCrust.BackColor = this.BackColor;
            }
        }

        // pawmadeCrust_CheckedChanged(object sender, EventArgs e)
        // parms: object sender, EventArgs e
        // returns: none
        // purpose: changes the bg color of the label based on whether it's been checked or not
        private void pawmadeCrust_CheckedChanged(object sender, EventArgs e)
        {
            if (pawmadeCrust.Checked) {
                pawmadeCrust.BackColor = Color.FromArgb(252, 242, 63);
            }

            else {
                pawmadeCrust.BackColor = this.BackColor;
            }
        }
        
        // crunchyCrust_CheckedChanged(object sender, EventArgs e)
        // parms: object sender, EventArgs e
        // returns: none
        // purpose: changes the bg color of the label based on whether it's been checked or not
        private void crunchyCrust_CheckedChanged(object sender, EventArgs e)
        {
            if (crunchyCrust.Checked) {
                crunchyCrust.BackColor = Color.FromArgb(252, 242, 63);
            }

            else {
                crunchyCrust.BackColor = this.BackColor;
            }
        }

        // deepDishCrust_CheckedChanged(object sender, EventArgs e)
        // parms: object sender, EventArgs e
        // returns: none
        // purpose: changes the bg color of the label based on whether it's been checked or not
        private void deepDishCrust_CheckedChanged(object sender, EventArgs e)
        {
            if (deepDishCrust.Checked) {
                deepDishCrust.BackColor = Color.FromArgb(252, 242, 63);
            }

            else {
                deepDishCrust.BackColor = this.BackColor;
            }
        }

        // secretButton_MouseEnter(object sender, EventArgs e)
        // parms: object sender, EventArgs e
        // returns: none
        // purpose: forces the button to appear at a random location on the form 
        private void secretButton_MouseEnter(object sender, EventArgs e)
        {
            // initializes the Random object
            generator = new Random();

            // declares two new variables for the width and height of the form
            int formWidth = this.Size.Width;
            int formHeight = this.Size.Height;

            // declares x variable that uses the Random object and sets the lower bound as the width of the 
            // image and the upper bound as the form width - button width
            int xCoord = generator.Next(dogGif.Size.Width, formWidth - secretButton.Size.Width);

            // declares y variable that uses Random object and sets lower bound to 0 and upper bound as
            // the height of the image
            int yCoord = generator.Next(0, dogGif.Size.Height);

            // creates a new Poiint object to relocated the button to the x and y values
            secretButton.Location = new Point(xCoord, yCoord);
            MessageBox.Show("curiosity killed the catses." + Environment.NewLine + "u dun goofed friend!!!");
            //MessageBox.Show(xCoord + " " + yCoord);
        }
        
        // zipcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        // params: object sender, KeyPressEventArgs e
        // returns: none
        // purpose: detects whether if the ENTER key has been pressed. if so, check for data validation and 
        // display the appropriate messages if the data is valid or invalid
        private void zipcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // sets the boolean pressed to false, meaning that ENTER has NOT been pressed
            pressed = false;

            // checks if ENTER has been pressed. if yes, set pressed to TRUE
            if (Keyboard.IsKeyDown(Key.Enter)) {
                pressed = true;
            }

            // if pressed is TRUE, check whether the data is valid. if so, change the bg color and display a 
            // confirmation message
            if (pressed) {
                // checks whether if the data in the text box is able to be parsed and if the length is > 5 and < 1
                double zipParsed;
                bool success = double.TryParse(zipcodeTextBox.Text, out zipParsed);
                if (zipcodeTextBox.Text == "" || !success || zipcodeTextBox.Text.Length != 5) {
                    MessageBox.Show(this, "plz enter a valid zip code. k ty.", "ERROR!!");
                }

                else {
                    PrintAddress();
                    this.BackColor = Color.FromArgb(158, 209, 239);
                    MessageBox.Show(this, "Is dis ur address?" + Environment.NewLine + Environment.NewLine + fullAddress + Environment.NewLine + Environment.NewLine + "Press 'OK' to confirm.", "PLZ CONFIRM");
                }
            }
        }

        // removeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        // params: object sender, KeyPressEventArgs e
        // returns: none
        // purpose: checks whether if the ENTER key has been pressed. if it has been pressed, set the pressed
        // boolean to TRUE. when pressed is TRUE, check if the user input matches the string pizzaText or 
        // whether the text in the remove box matches what is in the options box. if there are matches,
        // remove the appropriate information. this method also checks for the input of valid data.
        private void removeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // sets pressed to false and sets the string pizzaText to hold "pizza"
            pressed = false;
            string pizzaText = "pizza";

            // if ENTER has been pressed, set pressed to TRUE
            if (Keyboard.IsKeyDown(Key.Enter)) {
                pressed = true;
            }

            // if pressed is true, do the following checks:
            if (pressed) {
                double removeParsed;
                bool success = double.TryParse(removeTextBox.Text, out removeParsed);
                // checks if numbers are entered in the box and whether if the box is empty
                if (removeTextBox.Text == "" || success) {
                    MessageBox.Show(this, "Plz entur a valid item.", "ERROR!!");
                }

                else {
                    // if the text in the remove box matches pizzaText, remove the fullPizza string from the 
                    // receipt List and reset the options text box. change the bg color and display a pop-up that
                    // confirms the changes
                    if (removeTextBox.Text.ToUpper() == pizzaText.ToUpper()) {
                        receipt.Remove(fullPizza);
                        optionsTextBox.Text = "";
                        this.BackColor = Color.FromArgb(173, 192, 204);
                        MessageBox.Show(this, "ur item " + removeTextBox.Text + " has been removed.", "SUCCESS!!");
                    }

                    // if the text in removeTextBox matches anything the user has typed in the optionsTextBox,
                    // remove the item from the receipt List, reset the optionsTextBox, and change the bg color.
                    // also display a pop-up for confirmation.
                    else if (removeTextBox.Text.ToUpper() == optionsTextBox.Text.ToUpper()) {
                        receipt.Remove(optionsTextBox.Text);
                        optionsTextBox.Text = "";
                        this.BackColor = Color.FromArgb(173, 192, 204);
                        MessageBox.Show(this, "ur item " + removeTextBox.Text + " has been removed.", "SUCCESS!!");
                    }

                    // if there are no matches, display a pop-up saying so
                    else {
                        MessageBox.Show(this, "ur item " + removeTextBox.Text + " does not exist.", "ERROR!!");
                    }
                }
            }
        }
        
        // PrintAddress()
        // params: none
        // returns: none
        // purpose: this function first populates the address List and then adds all of the List's elements
        // into the string fullAddress. lastly, it adds fullAddress as a string in the receipt List.
        public void PrintAddress() {
            // clears list and resets the fullAddress string to prevent duplicated data
            address.Clear();
            fullAddress = "";

            // adds the following information to the address List
            address.Add(doorNumTextBox.Text);
            address.Add(streetNameComboBox.Text);
            address.Add(cityComboBox.Text);
            address.Add(countryLabel.Text);
            address.Add(zipcodeTextBox.Text);

            // iterates through the address List to format the text
            for (int i = 0; i < address.Count; i++) {
                if (i < 2) {
                    fullAddress += address[i] + " ";
                }
                
                else if (i == 2) {
                    fullAddress += Environment.NewLine + address[i] + ", ";
                }

                else if (i > 2 && i < address.Count - 1) {
                    fullAddress += address[i] + ", ";
                }

                else if (i == address.Count - 1) {
                    fullAddress += address[i] + " ";
                }
            }

            // adds the fullAddress string to the receipt List
            receipt.Add("ADDRESS: " + fullAddress); 
        }

        // PrintPizza()
        // params: none
        // returns: none
        // purpose: resets the fullPizza string and checks whether the radion buttons related to the crust
        // and check boxes for the toppings have been checked. if a specific button/check box has been changed,
        // populate the pizzaOrder List.
        public void PrintPizza() {
            // clears the pizzaOrder List and resets the fullPizza string to prevent duplicated data
            pizzaOrder.Clear();
            fullPizza = "";

            // CHECK IF CRUST SIZE BUTTON HAVE BEEN CHECKED AND ADD TO LIST IF IT HAS
            if (smallCrust.Checked) {
                pizzaOrder.Insert(0, "crust size: " + smallCrust.Text);
            }

            else if (mediumCrust.Checked) {
                pizzaOrder.Insert(0, "crust size: " + mediumCrust.Text);
            }

            else if (largeCrust.Checked) {
                pizzaOrder.Insert(0, "crust size: " + largeCrust.Text);
            }

            // CHECK IF THE CRUST TYPE BOX HAVE BEEN CHECKED AND ADD TO LIST IF IT HAS
            if (pawmadeCrust.Checked) {
                pizzaOrder.Insert(1, "crust type: " + pawmadeCrust.Text);
            }

            else if (crunchyCrust.Checked) {
                pizzaOrder.Insert(1, "crust type: " + crunchyCrust.Text);
            }

            else if (deepDishCrust.Checked) {
                pizzaOrder.Insert(1, "crust type: " + deepDishCrust.Text);
            }

            // CHECK IF ANY OF THE TOPPINGS CHECK BOXES HAVE BEEN CHECKED AND ADD TO LIST IF IT HAS
            if (smallBonesBox.Checked) {
                pizzaOrder.Add(smallBonesBox.Text);
            }

            if (chickenMeatBox.Checked) {
                pizzaOrder.Add(chickenMeatBox.Text);
            }

            if (jerkyBox.Checked) {
                pizzaOrder.Add(jerkyBox.Text);
            }

            if (berriesBox.Checked) {
                pizzaOrder.Add(berriesBox.Text);
            }

            if (pbBox.Checked) {
                pizzaOrder.Add(pbBox.Text);
            }

            if (babyCarrotsBox.Checked) {
                pizzaOrder.Add(babyCarrotsBox.Text);
            }
            
            if (cheeseBox.Checked) {
                pizzaOrder.Add(cheeseBox.Text);
            }

            if (cornCobBox.Checked) {
                pizzaOrder.Add(cornCobBox.Text);
            }

            // iterate through the List and add the elements in the List to the fullPizza string. also
            // formats the string at the same time
            for (int i = 0; i < pizzaOrder.Count; i++) {
                if (i < 2) {
                    fullPizza += pizzaOrder[i] + Environment.NewLine;
                }

                else if (i == 2) {
                    fullPizza += "toppings: " + pizzaOrder[i];
                }

                else if (i > 2) {
                    fullPizza += ", " + pizzaOrder[i];
                }
            }

            // add the fullPizza string to the receipt List
            receipt.Add("UR PIZZUR: " + Environment.NewLine + fullPizza);
            //MessageBox.Show("Ur pizzur so far... " + Environment.NewLine + fullPizza);
            //pizzaOrder.Clear();
        }

        // PrintReceipt()
        // params: none
        // returns: none
        // purpose: adds all the remaining necessary information to the receipt List, such as the name, other
        // options, and special instructions. this method also reformats the text in the special instructions
        // text box so that the text is displayed backwards
        public void PrintReceipt() {
            // clears the receipt List and 
            receipt.Clear();
            fullOrder = "";

            // adds in the remaining necessary information for the receipt 
            receipt.Add("NAME: " + nameTextBox.Text);
            receipt.Add("DATE: " + showDateTime.Value);

            // calls the PrintAddress() and PrintPizza() methods to add that data in
            PrintAddress();
            PrintPizza();
            receipt.Add("OTHER OPTIONS: " + optionsTextBox.Text);

            // declares two new strings: specialInstructions and backwards
            // specialInstructions uses the text in the text box while backwards is an empty string
            string specialInstructions = instructionsTextBox.Text;
            string backwards = "";

            // using a for loop, reverse the text in the special isntructions text box 
            for (int i = 1; i < specialInstructions.Length + 1; i++) {
                backwards += specialInstructions[specialInstructions.Length - i];
            }

            // then, add the backwards string in the receipt List
            receipt.Add("SPESHUL INSTRUKTIONS: " + backwards);
            
            // finally, update the fullOrder string and format it using a for loop
            for (int i = 0; i < receipt.Count; i++) {
                fullOrder += receipt[i] + Environment.NewLine;
            }

            // use a message box to display the order
            MessageBox.Show(this, fullOrder, "Ur ordur so far....");
        }

        // submitButton_Click(object sender, EventArgs e)
        // params: object sender, EventArgs e
        // returns: none
        // purpose: when the submit button has been pressed, first check to see if the name and zip code fields
        // contain valid data. if so, print out the receipt and then display another message after the user 
        // presses 'OK'. 
        private void submitButton_Click(object sender, EventArgs e)
        {
            // doubles and booleans used in parsing the data
            double nameParsed, zipParsed;
            bool nameSuccess, zipSuccess;
            nameSuccess = double.TryParse(nameTextBox.Text, out nameParsed);
            zipSuccess = double.TryParse(zipcodeTextBox.Text, out zipParsed);
            // checks to see if the name field contains a number or is empty. also checks if the zipcode
            // is empty and if the length isn't 5 characters
            if (nameSuccess || nameTextBox.Text == "" || zipcodeTextBox.Text == "" || !zipSuccess || 
                zipcodeTextBox.Text.Length != 5) {
                MessageBox.Show(this, "Plz check to see if the data u have filled in is valid!", "ERROR!!");
            }

            // if the data is valid, change the bg color and display the receipt
            else {
                this.BackColor = Color.FromArgb(255, 214, 132);
                PrintReceipt();
                MessageBox.Show(this, "o on second thought, we r too lazy 2 delivur. sry friend.", "WE R SURRY!!");
            }
        }
    }
}
