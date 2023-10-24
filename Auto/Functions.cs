using ComponentFactory.Krypton.Toolkit;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto
{
    public static class Functions
    {
        public static Dictionary<string, string> equipmentDict = new Dictionary<string, string>();

        public static void CreateDictions()
        {
            // Initialize the equipment dictionary
            equipmentDict = new Dictionary<string, string>
            {
                {"ACC: USB-A Headset (JPL-400)",               "HW_Duo_Headset"},
                {"ACC: Webcam (Lenovo 500)",               "HW_Webcam"},
                {"ACC: Numeric Keypad (Targus)",           "HW_W_10Key"},
                {"ACC: Keyboard and Mouse Set (Dell KM636)",   "HW_W_KBM"},
                {"ACC: Wirelesss Mouse (Logitech M510)",       "HW_W_Mouse"},
                {"HUB: x2 USB-A 3.0, x2 USB-C (Dev & MBP)",    "HW_USBC_Hub_Power"},
                {"HUB: x3 USB-A 2.0 w/ Ethernet (USB-C))",     "HW_USBC_RJ45"},
                {"HUB: x4 USB-A 2.0 (Ultra-Mini)",         "HW_USB2_Hub"},
                {"HUB: x3 USB-A 3.0 w/ Ethernet (USB-C)",      "HW_USBC_RJ45_hub"},
                {"CABLE: Display Port to Display Port (6ft)",  "HW_6ft_DP"},
                {"CABLE: HDMI to HDMI (6ft)",              "HW_6ft_HDMI"},
                {"CABLE: USB-C to HDMI (6ft)",             "HW_6ft_USBC_HDMI"},
                {"CABLE: RJ45 Ethernet (6ft)",                 "HW_6ft_RJ45"},
                {"CABLE: USB-C to USB-C (3ft)",            "HW_W_USBC_USBC"},
                {"ADPT: Dell 90-Watt (USB-C Power)",           "HW_USBC_Power_Adapter"},
                {"ADPT: Dell 130-Watt (USB-C Power)",          "HW_USBC_Power_Adapter"},
                {"ADPT: USB-C to HDMI (StarTech)",         "HW_USBC_HDMI"},
                {"DONGLE: USB-C to USB-A",             "HW_USBC_USBA_Dongle"},
                {"BATT: AA",                       "HW_dub_A"},
                {"BATT: AAA",                          "HW_trip_A"},
                {"YUBI: USB-C",                    "HW_Yubikey-C"},
                {"YUBI: Nano",                     "HW_Yubikey-Nano"},
                {"YUBI: Neo",                          "HW_Yubikey-Neo"}
            };
        }

        public static void PopulateDropDown(KryptonDropButton dropbut, string option)
        {
            try { dropbut.KryptonContextMenu = GetSubjectItems(option); }
            catch (Exception ex) { MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public static KryptonContextMenu GetSubjectItems(string a)
        {
            KryptonContextMenu contextMenu = new KryptonContextMenu();

            try
            {
                KryptonContextMenuItems items = GetMenuItems(a);

                if (items != null)
                    contextMenu.Items.Add(items);
            }
            catch (Exception ex) { MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return contextMenu;
        }

        private static KryptonContextMenuItems GetMenuItems(string butname)
        {
            KryptonContextMenuItems menuItems = new KryptonContextMenuItems();

            try
            {
                switch (butname)
                {
                    case "CheckButton_Inquiry":
                        menuItems.Items.Add(new KryptonContextMenuItem("Inquiry 1", null, Item_Click));
                        menuItems.Items.Add(new KryptonContextMenuItem("Inquiry 2", null, Item2_Click));
                        break;
                    case "CheckButton_Equip":
                        foreach (KeyValuePair<string, string> entry in equipmentDict)
                        {
                            KryptonContextMenuItem item = new KryptonContextMenuItem(entry.Key, null, Item_Click);
                            menuItems.Items.Add(item);
                        }
                        break;
                    case "CheckButton_Issue":
                        menuItems.Items.Add(new KryptonContextMenuItem("Issue 1", null, Item_Click));
                        menuItems.Items.Add(new KryptonContextMenuItem("Issue 2", null, Item2_Click));
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return menuItems;
        }

        private static void Item_Click(object sender, EventArgs e)
        {
            try
            {
                // Handle Item 1 click
            }
            catch (Exception ex) { MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }           
        }

        private static void Item2_Click(object sender, EventArgs e)
        {
            // Handle Item 2 click
        }

  
    }
}
