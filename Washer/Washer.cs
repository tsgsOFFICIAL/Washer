using System;
using System.Collections.Generic;
using System.Text;

namespace Washer
    {
    class Washer
        {
        #region Fields
        private bool powerState; //powerState refers to wether the washer has power or not
        private bool runState; //runState refers to the state of the washer, is it running or not
        private bool isWaterConnected; //Is the water properly connected
        private bool isDoorOpen; //Is the door open
        private short weight; //Weight in kg's
        private short temperature; //temp refers to the temperature of the water inside the washer
        private string runningProgram; //Holds the running program
        /// <summary>
        /// A list of available programs for your washer
        /// </summary>
        public enum Program
            {
            eco,
            quick
            }
        #endregion

        #region Properties
        public string PowerState
            {
            get { if (this.powerState) { return "on"; } else { return "off"; } }
            }
        public string CentrifugeState
            {
            get { if (this.runState) { return "on"; } else { return "off"; } }
            }
        public string RunningProgram
            {
            get { if (this.runningProgram == null || this.runningProgram == "") { return "nothing"; } else { return this.runningProgram; } }
            }
        public string DoorState
            {
            get { if (this.isDoorOpen) { return "open"; } else { return "closed"; } }
            }
        public string Temperature
            {
            get { return temperature.ToString(); }
            }
        public string Weight
            {
            get { return weight.ToString(); }
            }
        #endregion

        #region Methods
        /// <summary>
        /// Powers on the washing machine, doesn't start it!
        /// </summary>
        private void PowerOn()
            {
            powerState = true;
            }

        /// <summary>
        /// Powers off the washing machine, ending everything it might be doing
        /// </summary>
        private void PowerOff()
            {
            if (runState)
                {
                runState = false;
                runningProgram = "";
                }
            powerState = false;
            }

        /// <summary>
        /// Toggle the power on or off, depending on the current state
        /// </summary>
        public void TogglePower()
            {
            if (powerState)
                {
                PowerOff();
                }
            else
                {
                PowerOn();
                }
            }

        /// <summary>
        /// Start the washer at a certain program
        /// </summary>
        /// <param name="program">Choose what program to run</param>
        /// <returns>This method returns true if successful, otherwise returns false</returns>
        public bool Start(string program)
            {
            if (this.powerState)
                {
                switch (program.ToLower().Trim())
                    {
                    case "eco":
                        break;
                    case "quick":
                        break;
                    default:
                        return false;
                    }
                runningProgram = program.ToLower().Trim();

                runState = true;
                return true;
                }
            else
                {
                return false;
                }
            }

        /// <summary>
        /// Stops the running program, if any.
        /// </summary>
        public void Stop()
            {
            runState = false;
            runningProgram = "";
            }
        #endregion
        }
    }
