using System.Timers;
using System.Runtime.InteropServices;

namespace AutoClicker
{
    public partial class AutoClicker : Form
    {
        private static System.Timers.Timer aTimer;
        private bool isDoubleClick = false;
        private int clickCount = 0;
        private int maxClicks = -1;
        public AutoClicker()
        {
            InitializeComponent();

            comboClickType.SelectedIndex = 0;
            comboMouseButton.SelectedIndex = 0;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartClicker();
            ClickerActivated();
        }
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
        private void btnChangeKey_Click(object sender, EventArgs e)
        {

        }
        private void StartClicker()
        {
            int rate = CalculateMsClickRate();
            
            clickCount = 0;

            if (rdRepeatIndefinitely.Checked)
            {
                maxClicks = -1;  // infinite
            }
            else
            {
                int.TryParse(fieldRepeatTimes.Text, out maxClicks);
            }

            aTimer = new System.Timers.Timer(rate);
            ChooseMouseButton();
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void LeftClick(Object source, ElapsedEventArgs e)
        {
            // Simulate left click
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            if (isDoubleClick)
            {
                Thread.Sleep(50);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }

            clickCount++;
            if (maxClicks != -1 && clickCount >= maxClicks)
            {
                btnStop.Invoke(new Action(() => btnStop.PerformClick())); // Stop AutoClicker
            }
        }
        private void RightClick(Object source, ElapsedEventArgs e)
        {
            // Simulate right click
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            if (isDoubleClick)
            {
                Thread.Sleep(50);
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }

            clickCount++;
            if (maxClicks != -1 && clickCount >= maxClicks)
            {
                btnStop.Invoke(new Action(() => btnStop.PerformClick())); // Stop AutoClicker
            }
        }
        public int CalculateMsClickRate()
        {
            int h, m, s, ms;
            int.TryParse(fieldHour.Text, out h);
            int.TryParse(fieldMinut.Text, out m);
            int.TryParse(fieldSecond.Text, out s);
            int.TryParse(fieldMilisecond.Text, out ms);

            // Convert to miliseconds and sum:
            int totalMs = (h * 60 * 60 * 1000) + (m * 60 * 1000) + (s * 1000) + ms;

            return totalMs;
        }

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
        public void ChooseTypeOfClick()
        {
            string option = comboClickType.SelectedItem.ToString();

            if (option == "Single")
            {
                isDoubleClick = false;
            }
            else
            {
                isDoubleClick = true;
            }

        }

        public void ClickerActivated()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnChangeKey.Enabled = false;
            containerClickIntervals.Enabled = false;
            containerClickOptions.Enabled = false;
            containerClickRepeat.Enabled = false;
        }
        public void ClickerDesactivated()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnChangeKey.Enabled = true;
            containerClickIntervals.Enabled = true;
            containerClickOptions.Enabled = true;
            containerClickRepeat.Enabled = true;
        }

        private void comboClickType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboClickType.SelectedIndex == 1)
            {
                comboMouseButton.SelectedIndex = 0;
            }
        }

        private void comboMouseButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMouseButton.SelectedIndex == 1)
            {
                comboClickType.SelectedIndex = 0;
            }
        }
    }
}
