using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto
{
    public partial class Form1 : KryptonForm
    {
        public class KryptonFormProxy
        {
            private KryptonForm _form;

            public KryptonFormProxy(KryptonForm form)
            {
                _form = form;
            }

            [Category("Appearance")]
            [Description("The text associated with the control.")]
            [DefaultValue("")]
            public string Text
            {
                get { return _form.Text; }
                set { _form.Text = value; }
            }

            [Category("Appearance")]
            [Description("The extra text associated with the control.")]
            [DefaultValue("")]
            public string TextExtra
            {
                get { return _form.TextExtra; }
                set { _form.TextExtra = value; }
            }

            [Category("Appearance")]
            [Description("The icon associated with the control.")]
            [DefaultValue("")]
            public Icon Icon
            {
                get { return _form.Icon; }
                set { _form.Icon = value; }
            }

            [Category("Visuals")]
            [Description("Should custom chrome be allowed for this KryptonForm instance.")]
            [DefaultValue(true)]
            public bool AllowFormChrome
            {
                get { return _form.AllowFormChrome; }
                set { _form.AllowFormChrome = value; }
            }

            [Category("Visuals")]
            [Description("Should the form status strip be considered for merging into chrome.")]
            [DefaultValue(true)]
            public bool AllowStatusStripMerge
            {
                get { return _form.AllowStatusStripMerge; }
                set { _form.AllowStatusStripMerge = value; }
            }

            [Category("Visuals")]
            [Description("Header style for a main form.")]
            [DefaultValue(typeof(HeaderStyle), "Form")]
            public HeaderStyle HeaderStyle
            {
                get { return _form.HeaderStyle; }
                set { _form.HeaderStyle = value; }
            }

            [Category("Visuals")]
            [Description("Chrome group border style.")]
            [DefaultValue(typeof(PaletteBorderStyle), "FormMain")]
            public PaletteBorderStyle GroupBorderStyle
            {
                get { return _form.GroupBorderStyle; }
                set { _form.GroupBorderStyle = value; }
            }

            [Category("Visuals")]
            [Description("Chrome group background style.")]
            [DefaultValue(typeof(PaletteBackStyle), "FormMain")]
            public PaletteBackStyle GroupBackStyle
            {
                get { return _form.GroupBackStyle; }
                set { _form.GroupBackStyle = value; }
            }

            [Category("Visuals")]
            [Description("Overrides for defining common form appearance that other states can override.")]
            public PaletteFormRedirect StateCommon
            {
                get { return _form.StateCommon; }
            }

            [Category("Visuals")]
            [Description("Overrides for defining inactive form appearance.")]
            public PaletteForm StateInactive
            {
                get { return _form.StateInactive; }
            }

            [Category("Visuals")]
            [Description("Overrides for defining active form appearance.")]
            public PaletteForm StateActive
            {
                get { return _form.StateActive; }
            }

            [Category("Visuals")]
            [Description("Collection of button specifications.")]
            public KryptonForm.FormButtonSpecCollection ButtonSpecs
            {
                get { return _form.ButtonSpecs; }
            }

            [Category("Window Style")]
            [DefaultValue(true)]
            public bool ControlBox
            {
                get { return _form.ControlBox; }
                set { _form.ControlBox = value; }
            }

            [Category("Window Style")]
            [DefaultValue(true)]
            public bool MaximizeBox
            {
                get { return _form.MaximizeBox; }
                set { _form.MaximizeBox = value; }
            }

            [Category("Window Style")]
            [DefaultValue(true)]
            public bool MinimizeBox
            {
                get { return _form.MinimizeBox; }
                set { _form.MinimizeBox = value; }
            }

            [Category("Window Style")]
            [DefaultValue(true)]
            public bool ShowIcon
            {
                get { return _form.ShowIcon; }
                set { _form.ShowIcon = value; }
            }
        }
        private Button[] buttons;
        //private Button selectedButton;
        private string activeButton;
        private KryptonCheckButton selectedButton;
        private ComboBox dropdownMenu;

        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton_copy;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton_Equip;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton_Issue;

        private Color walmartgreencolor = Color.FromArgb(4, 244, 120);
        private Color lightbluecolor = Color.FromArgb(220, 233, 246);
        private Color darkbluecolor = Color.FromArgb(0, 120, 215);
        private Color slategraycolor = Color.SlateGray; 
        private Color goldencolor = Color.Gold;

        public Form1()
        {
            InitializeComponent();
            LoadComps();
            Functions.CreateDictions();
        }

        private void LoadComps()
        {
            KryptonManager kryptonManager = new KryptonManager();
            activeButton = "";

            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            RecalcNonClient();

            kryptonManager.GlobalPaletteMode = PaletteModeManager.SparkleBlue;
            this.Text = "AutoTicket";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  ResetButtonColors();

        }


        // Event handler for button clicks
        private void Button_Click(object sender, EventArgs e)
        {
            KryptonCheckButton clickedButton = (KryptonCheckButton)sender;
            string buttonName = clickedButton.Name;

            if (activeButton == buttonName)
                return;
            else
                selectedButton = clickedButton;



            // Call HandleButtonClick to update the state and dropdown
            this.HandleButtonClick(buttonName);
        }

        public void HandleButtonClick(string buttonName)
        {
            // Turn off the previously active button
            if (activeButton != "")
            {
                TurnOffButton(activeButton);
            }

            // Turn on the clicked button and update the active button
            TurnOnButton(buttonName);
            activeButton = buttonName;

            // Call the pre-existing function to update the drop-down menu
            UpdateDropDown(activeButton);
        }

        // Function to turn on a button (You can customize this as needed)
        private void TurnOnButton(string buttonName)
        {
            // Code to turn on the button
        }

        // Function to turn off a button (You can customize this as needed)
        private void TurnOffButton(string buttonName)
        {
            selectedButton.Checked = false;
        }

   

        private void kryptonCheckButton_Inquiry_Click(object sender, EventArgs e)
        {
            kryptonCheckButton_Inquiry.Checked = true;
            //CheckButtonControls();
        }



        private void kryptonGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

  



     



     

        private void kryptonDropButton_subject_Click(object sender, EventArgs e)
        {
            //kryptonDropButton_subject.SuspendLayout();
            //PopulateDropDown(selectedButton.Name);
            //kryptonDropButton_subject.ResumeLayout();
            //kryptonDropButton_subject.Update();

 
        }

        private void UpdateDropDown(string butname)
        {
            kryptonDropButton_subject.SuspendLayout();
            Functions.PopulateDropDown(kryptonDropButton_subject, butname);
            kryptonDropButton_subject.ResumeLayout();
            kryptonDropButton_subject.Update();
        }
    }
}
