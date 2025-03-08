namespace ApplicationSettings
{
    public class CUSettings
    {
        public const int MAX_CHANNELS = 16;

        private int n;              //number of channels
        public bool[] isSup;        //every bit say if the upper threshold is active for the given channel
        public bool[] isInf;        //every bit say if the lower threshold is active for the given channel
        public float[] Sup;         //contain the upper threshold for the given channel
        public float[] Inf;         //contain the lower threshold for the given channel

        public int N
        {
            get { return n; }
            set { if (value > 0 && value <= CUSettings.MAX_CHANNELS) n = value; }
        }

        public CUSettings(int n)      //needed for returning a NULL settings when TempSensor is not initialized
        {
            if (n <= 0 || n > CUSettings.MAX_CHANNELS)
                Init(0);
            else
                Init(n);
        }

        public CUSettings()
        {
            Init(CUSettings.MAX_CHANNELS);
        }

        //bool operator ==(int r);
        //bool operator !=(int r);
        private void Init(int n)
        {
            this.n = n;
            isSup = new bool[CUSettings.MAX_CHANNELS];
            isInf = new bool[CUSettings.MAX_CHANNELS];
            Sup = new float[CUSettings.MAX_CHANNELS];
            Inf = new float[CUSettings.MAX_CHANNELS];

            for (byte i = 0; i < CUSettings.MAX_CHANNELS; Sup[i] = 0, Inf[i] = 0, isSup[i] = false, isInf[i] = false, i++) ;
        }

        public static bool operator ==(CUSettings settings, int r)
        {
            return settings.n == r;
        }

        public override bool Equals(object right)
        {
            if (right is CUSettings)
            {
                return this.N == ((CUSettings)right).N;
            }
            return false;
        }

        public static bool operator !=(CUSettings settings, int r)
        {
            return settings.n != r;
        }

        public override int GetHashCode()
        {
            int ret = N;
            for (int i = 0; i < N; i++)
            {
                ret += (isSup[i] ? 1 : 0);
                ret += (isInf[i] ? 1 : 0);
                ret += (int)Sup[i];
                ret += (int)Inf[i];
            }
            return ret;
        }
    }

    public class CalibrationData
    {
        //data relative to the calibration of one channel
        private int channel;                            //the channel to calibrate. 256 means an non-valid object
        private float temperature;                       //the reference temperature

        public int Channel
        {
            get { return channel; }
            set { if (value > 0 && value <= CUSettings.MAX_CHANNELS) channel = value - 1; }
        }

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        //The following functions interact with CalibrationData as the channels are numbered starting from 1
        //so if you want to init the number of channel to zero you have to call CalibrationData(1)
        //the same for the operator== and operator!=.
        //For these functions any value outside the 1-CUSettings.MAX_CHANNELS inclusive range act as a non-valid object
        public CalibrationData() : this(256,0)
        {
        }

        public CalibrationData(int channel) : this(channel, 0)
        {
        }

        public CalibrationData(int channel, float temperature)
        {
            if (channel <= 0 || channel > CUSettings.MAX_CHANNELS)
                this.channel = 256;
            else
                this.channel = channel - 1;

            this.temperature = temperature;
        }

        public static bool operator ==(CalibrationData cd, int r)
        {
            if (r <= 0 || r > CUSettings.MAX_CHANNELS)
            {
                if (cd.channel == 256) return true;
                else return false;
            }
            else
            {
                return cd.channel == (r - 1);
            }
        }

        public override bool Equals(object right)
        {
            if (right is CUSettings)
            {
                CalibrationData cData = (CalibrationData)right;
                if (cData.Channel <= 0 || cData.Channel > CUSettings.MAX_CHANNELS)
                {
                    if (this.channel == 256) return true;
                    else return false;
                }
                else
                {
                    return this.channel == (cData.Channel - 1);
                }
            }
            return false;
        }

        public static bool operator !=(CalibrationData cd, int r)
        {
            if (r <= 0 || r > CUSettings.MAX_CHANNELS)
            {
                if (cd.channel != 256) return true;
                else return false;
            }
            else
            {
                return cd.channel != (r - 1);
            }
        }

        public override int GetHashCode()
        {
            return (int)(Channel * temperature);
        }

        //bool operator !=(int r);
    }

    public class T
    {
        private int n;
        public float[] temps;

        public float[] Temps
        {
            get
            {
                return temps;
            }
        }

        public int N
        {
            get { return n; }
            set { if (value > 0 && value <= CUSettings.MAX_CHANNELS) n = value; }
        }

        public T(int n)
        {
            if (n > 0 && n <= CUSettings.MAX_CHANNELS) this.n = n;
            else this.n = 0;
            temps = new float[CUSettings.MAX_CHANNELS];
        }

        public T()
        {
            this.n = 0;
            temps = new float[CUSettings.MAX_CHANNELS];
        }

        public float this[int i]
        {
            get
            {
                if (i >= 0 && i < n) return temps[i];
                else return 0.0f;
            }
            set
            {
                if (i >= 0 && i < n) temps[i] = value;
            }
        }
    }
}
