using System.Timers;
using System.Runtime.InteropServices;
using Gma.System.MouseKeyHook;

namespace AutoClicker
{
    public partial class AutoClicker : Form
    {
        private static System.Timers.Timer aTimer;  // Timer for clicking interval
        private bool isDoubleClick = false;         // Flag to determine single or double click
        private int clickCount = 0;                 // Count how many clicks have been performed
        private int maxClicks = -1;                 // Maximum number of clicks (-1 means infinite)

        private IKeyboardMouseEvents globalHook;    // Global keyboard/mouse hook for hotkey detection
        private Keys hotkey = Keys.F6;              // Default hotkey to start/stop autoclicker
        private bool waitingForHotkey = false;      // Flag to indicate if waiting for user to press a new hotkey

        public AutoClicker()
        {
            InitializeComponent();

            // Initialize combo boxes with default selected indices
            comboClickType.SelectedIndex = 0;
            comboMouseButton.SelectedIndex = 0;

            // Update button text with current hotkey
            btnChangeKey.Text = $"Change Hotckey: {hotkey}";

            // Subscribe to global keyboard events
            SubscribeGlobalHook();
        }

        // Import mouse_event function from user32.dll for simulating mouse clicks
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        // Constants for mouse event flags (down/up for left and right mouse buttons)
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        // Start button click event handler: starts the autoclicker
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartClicker();
            ClickerActivated();
        }

        // Stop button click event handler: stops the autoclicker and disposes timer
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
                aTimer = null;
            }
            ClickerDesactivated();
        }

        // Change Hotkey button click: waits for the user to press a new hotkey
        private void btnChangeKey_Click(object sender, EventArgs e)
        {
            waitingForHotkey = true;
            btnChangeKey.Text = "Press a key...";
        }

        // Subscribe to global keyboard events to listen for hotkey presses
        private void SubscribeGlobalHook()
        {
            globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalHook_KeyDown;
        }

        // Unsubscribe and dispose of the global hook to free resources
        private void UnsubscribeGlobalHook()
        {
            if (globalHook != null)
            {
                globalHook.KeyDown -= GlobalHook_KeyDown;
                globalHook.Dispose();
                globalHook = null;
            }
        }

        // Handler for global key down events
        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (waitingForHotkey)
            {
                // If waiting for new hotkey, set it here
                hotkey = e.KeyCode;
                waitingForHotkey = false;
                
                btnStart.Text = $"Start ({hotkey})";
                btnStop.Text = $"Stop ({hotkey})";
                btnChangeKey.Text = $"Current key: {hotkey}";

                e.Handled = true;
                return;
            }

            // If pressed key matches the hotkey, toggle autoclicker start/stop
            if (e.KeyCode == hotkey)
            {
                if (btnStart.Enabled)
                {
                    btnStart.PerformClick();
                }
                else
                {
                    btnStop.PerformClick();
                }
                e.Handled = true;
            }
        }

        // Unsubscribe hook when form is closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnsubscribeGlobalHook();
            base.OnFormClosing(e);
        }

        // Method to start the autoclicker timer and configure click parameters
        private void StartClicker()
        {
            int rate = CalculateMsClickRate();  // Calculate click interval in ms

            clickCount = 0;

            if (rdRepeatIndefinitely.Checked)
            {
                maxClicks = -1;  // Set to infinite clicks
            }
            else
            {
                int.TryParse(fieldRepeatTimes.Text, out maxClicks); // Parse max clicks from input
            }

            aTimer = new System.Timers.Timer(rate); // Initialize timer with click rate interval
            ChooseMouseButton();                     // Subscribe to appropriate click event
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        // Simulate left mouse click, optionally double click
        private void LeftClick(Object source, ElapsedEventArgs e)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

            if (isDoubleClick)
            {
                Thread.Sleep(50);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }

            clickCount++;

            // Stop if max clicks reached (unless infinite)
            if (maxClicks != -1 && clickCount >= maxClicks)
            {
                btnStop.Invoke(new Action(() => btnStop.PerformClick())); // Stop autoclicker safely on UI thread
            }
        }

        // Simulate right mouse click
        private void RightClick(Object source, ElapsedEventArgs e)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);

            clickCount++;

            // Stop if max clicks reached (unless infinite)
            if (maxClicks != -1 && clickCount >= maxClicks)
            {
                btnStop.Invoke(new Action(() => btnStop.PerformClick())); // Stop autoclicker safely on UI thread
            }
        }

        // Calculate the total click interval in milliseconds from user inputs
        public int CalculateMsClickRate()
        {
            int h, m, s, ms;
            int.TryParse(fieldHour.Text, out h);
            int.TryParse(fieldMinut.Text, out m);
            int.TryParse(fieldSecond.Text, out s);
            int.TryParse(fieldMilisecond.Text, out ms);

            // Convert hours, minutes, seconds, and milliseconds to total milliseconds
            int totalMs = (h * 60 * 60 * 1000) + (m * 60 * 1000) + (s * 1000) + ms;

            return totalMs;
        }

        // Subscribe timer event to the chosen mouse button click handler
        public void ChooseMouseButton()
        {
            string option = comboMouseButton.SelectedItem.ToString();

            if (option == "Left")
            {
                aTimer.Elapsed += LeftClick;
            }
            else
            {
                aTimer.Elapsed += RightClick;
            }
        }

        // Set click type (single or double) based on combo box selection
        public void ChooseTypeOfClick()
        {
            string option = comboClickType.SelectedItem.ToString();

            isDoubleClick = option == "Double";
        }

        // Update UI controls when autoclicker is activated (disable some controls)
        public void ClickerActivated()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnChangeKey.Enabled = false;
            containerClickIntervals.Enabled = false;
            containerClickOptions.Enabled = false;
            containerClickRepeat.Enabled = false;
        }

        // Update UI controls when autoclicker is deactivated (enable controls)
        public void ClickerDesactivated()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnChangeKey.Enabled = true;
            containerClickIntervals.Enabled = true;
            containerClickOptions.Enabled = true;
            containerClickRepeat.Enabled = true;
        }

        // If user selects double click type, force mouse button to Left (only left supports double click)
        private void comboClickType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboClickType.SelectedIndex == 1)
            {
                comboMouseButton.SelectedIndex = 0;
            }
        }

        // If user selects right mouse button, force click type to Single (double click not supported)
        private void comboMouseButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMouseButton.SelectedIndex == 1)
            {
                comboClickType.SelectedIndex = 0;
            }
        }
    }
}
