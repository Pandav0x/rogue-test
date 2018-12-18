using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenTK.Input;

namespace GamePadDetector
{
    public partial class MainForm : Form
    {
        public List<String> gamepadList;
        public int index = 0;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Gamepad Detector";

            this.gamepadList = new List<String>();

            for (int i = 0;; i++)
            {
                if (!GamePad.GetState(i).IsConnected)
                    break;

                gamepadList.Add(GamePad.GetName(i));
            }

            if(this.gamepadList.Count > 0)
                GamePadList.DataSource = this.gamepadList;

            return;
        }

        private void GamePadList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.index = GamePadList.SelectedIndex;

            this.mappingBtn.Visible = !GamePad.GetCapabilities(index).IsMapped;

            #region has XXXXX ?
            string textValue = "";
            textValue += "Connected:\t" + GamePad.GetCapabilities(index).IsConnected.ToString() + "\r\n";
            textValue += "Mapped:\t\t" + GamePad.GetCapabilities(index).IsMapped.ToString() + "\r\n\r\n";

            textValue += "Has A:\t\t" + GamePad.GetCapabilities(index).HasAButton.ToString() + "\r\n";
            textValue += "Has B:\t\t" + GamePad.GetCapabilities(index).HasBButton.ToString() + "\r\n";
            textValue += "Has X:\t\t" + GamePad.GetCapabilities(index).HasXButton.ToString() + "\r\n";
            textValue += "Has Y:\t\t" + GamePad.GetCapabilities(index).HasYButton.ToString() + "\r\n";
            textValue += "Has RB:\t\t" + GamePad.GetCapabilities(index).HasRightShoulderButton.ToString() + "\r\n";
            textValue += "Has LB:\t\t" + GamePad.GetCapabilities(index).HasLeftShoulderButton.ToString() + "\r\n\r\n";

            textValue += "Has RT:\t\t" + GamePad.GetCapabilities(index).HasRightTrigger.ToString() + "\r\n";
            textValue += "Has LT:\t\t" + GamePad.GetCapabilities(index).HasLeftTrigger.ToString() + "\r\n\r\n";

            textValue += "Has Right X:\t" + GamePad.GetCapabilities(index).HasRightXThumbStick.ToString() + "\r\n";
            textValue += "Has Right Y:\t" + GamePad.GetCapabilities(index).HasRightYThumbStick.ToString() + "\r\n";
            textValue += "Has Left X:\t" + GamePad.GetCapabilities(index).HasLeftXThumbStick.ToString() + "\r\n";
            textValue += "Has Left Y:\t" + GamePad.GetCapabilities(index).HasLeftYThumbStick.ToString() + "\r\n\r\n";

            textValue += "Has L3:\t\t" + GamePad.GetCapabilities(index).HasRightStickButton.ToString() + "\r\n";
            textValue += "Has R3:\t\t" + GamePad.GetCapabilities(index).HasLeftStickButton.ToString() + "\r\n\r\n";

            textValue += "Has Dpad U:\t" + GamePad.GetCapabilities(index).HasDPadUpButton.ToString() + "\r\n";
            textValue += "Has Dpad D:\t" + GamePad.GetCapabilities(index).HasDPadDownButton.ToString() + "\r\n";
            textValue += "Has Dpad L:\t" + GamePad.GetCapabilities(index).HasDPadLeftButton.ToString() + "\r\n";
            textValue += "Has Dpad R:\t" + GamePad.GetCapabilities(index).HasDPadRightButton.ToString() + "\r\n\r\n";


            textValue += "Has Start:\t" + GamePad.GetCapabilities(index).HasStartButton.ToString() + "\r\n";
            textValue += "Has Back:\t" + GamePad.GetCapabilities(index).HasBackButton.ToString() + "\r\n\r\n";

            textValue += "Has Big button:\t" + GamePad.GetCapabilities(index).HasBigButton.ToString() + "\r\n";
            textValue += "Has Voice Support:\t" + GamePad.GetCapabilities(index).HasVoiceSupport.ToString() + "\r\n\r\n";

            this.capasTB.Text = textValue;
            #endregion

            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            string textValue = "";
            textValue += GamePadList.SelectedItem.ToString() + "\r\n\r\n";

            GamePadState state = GamePad.GetState(index);

            textValue += GamePad.GetCapabilities(index).GamePadType + " - Connected: " + state.IsConnected.ToString() + "\r\n";

            GamePadThumbSticks sticks = state.ThumbSticks;

            #region buttons values
            textValue += "\r\n\r\n\r\n";

            textValue += "LS X - " + sticks.Left.X.ToString("0.00") + "\r\nLS Y - " + sticks.Left.Y.ToString("0.00") + "\r\n\r\n";
            textValue += "RS X - " + sticks.Right.X.ToString("0.00") + "\r\nRS Y - " + sticks.Right.Y.ToString("0.00") + "\r\n\r\n";

            textValue += "LT - " + state.Triggers.Left.ToString("0.00") + "\r\n";
            textValue += "RT - " + state.Triggers.Right.ToString("0.00") + "\r\n\r\n";

            if (state.Buttons.A == OpenTK.Input.ButtonState.Pressed)
                textValue += "A\t";
            if (state.Buttons.B == OpenTK.Input.ButtonState.Pressed)
                textValue += "B\t";
            if (state.Buttons.X == OpenTK.Input.ButtonState.Pressed)
                textValue += "X\t";
            if (state.Buttons.Y == OpenTK.Input.ButtonState.Pressed)
                textValue += "Y\t";

            textValue += "\r\n\r\n";

            if (state.DPad.Up == OpenTK.Input.ButtonState.Pressed)
                textValue += "DpUP\t";
            if (state.DPad.Down == OpenTK.Input.ButtonState.Pressed)
                textValue += "DpDown\t";
            if (state.DPad.Left == OpenTK.Input.ButtonState.Pressed)
                textValue += "DpLeft\t";
            if (state.DPad.Right == OpenTK.Input.ButtonState.Pressed)
                textValue += "DpRight\t";

            textValue += "\r\n\r\n";

            if (state.Buttons.RightStick == OpenTK.Input.ButtonState.Pressed)
                textValue += "R3\t";
            if (state.Buttons.LeftStick == OpenTK.Input.ButtonState.Pressed)
                textValue += "L3\t";
            if (state.Buttons.RightShoulder == OpenTK.Input.ButtonState.Pressed)
                textValue += "RB\t";
            if (state.Buttons.LeftShoulder == OpenTK.Input.ButtonState.Pressed)
                textValue += "LB\t";

            textValue += "\r\n\r\n";

            if (state.Buttons.Back == OpenTK.Input.ButtonState.Pressed)
                textValue += "Back\t";
            if (state.Buttons.Start == OpenTK.Input.ButtonState.Pressed)
                textValue += "Start\t";
            if (state.Buttons.BigButton == OpenTK.Input.ButtonState.Pressed)
                textValue += "BigButton\t";

            textValue += "\r\n\r\n";

            this.ButtonsTB.Text = textValue;
            #endregion

            return;
        }

        private void mappingBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Well, I tried to work on that, but if you see this, it is not quite finished yet.", "Wir haben eine problem");
        }
    }
}
