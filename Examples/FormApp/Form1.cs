using IRBoardLib;

namespace FormApp
{
    public partial class Form1 : Form
    {
        private IRBoard irboard = new IRBoard();
        private bool exRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        private UInt32 Count
        {
            get
            {
                return irboard.UInt32ValueOf("D0");
            }
            set
            {
                irboard.SetUInt32ValueTo(value, "D0");
            }
        }

        private bool Running
        {
            get
            {
                return irboard.BoolValueOf("M0");
            }
            set
            {
                irboard.SetBoolValueTo(value, "M0");
            }
        }

        private float Speed
        {
            get
            {
                return irboard.FloatValueOf("D2");
            }
            set
            {
                irboard.SetFloatValueTo(value, "D2");
            }
        }

        private void UpdateIpAddresses()
        {
            ipAddressListBox.BeginUpdate();
            ipAddressListBox.Items.Clear();
            foreach (var ip in irboard.IPv4Addresses)
            {
                ipAddressListBox.Items.Add($"{ip} : {irboard.PortNo}");
            }
            ipAddressListBox.EndUpdate();
        }

        private void Start()
        {
            Running = true;
            exRunning = Running;
            timer.Enabled = Running;
            ValidateControls();
        }

        private void Stop()
        {
            Running = false;
            exRunning = Running;
            timer.Enabled = Running;
            ValidateControls();
        }

        private void ValidateControls()
        {
            startButton.Enabled = !Running;
            stopButton.Enabled = Running;
            resetButton.Enabled = !Running;
        }

        private void UpdateCount()
        {
            countLabel.Text = Count.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            irboard.Run();
            UpdateIpAddresses();
            Speed = 1.0f;
            ValidateControls();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Speed < 0.1)
            {
                timer.Interval = 100;
            }
            else
            {
                timer.Interval = (int)(Speed * 1000);
            }
            Count++;
            UpdateCount();

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Count = 0;
        }

        private void monitorTimer_Tick(object sender, EventArgs e)
        {
            if (exRunning != Running)
            {
                if (Running)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
        }
    }
}