namespace Serial
{
    public class CUSettings
    {
        private int n;              //number of channels
        public bool[] isSup;        //every bit say if the upper threshold is active for the given channel
        public bool[] isInf;        //every bit say if the lower threshold is active for the given channel
        public float[] Sup;         //contain the upper threshold for the given channel
        public float[] Inf;         //contain the lower threshold for the given channel

        public int N
        {
            get{ return n; }
            set { if (value > 0 && value <= 16) n = value; }
        }

        public CUSettings(int n)      //needed for returning a NULL settings when TempSensor is not initialized
        {
            if (n <= 0 || n > 16)
                Init(0);
            else
                Init(n);
        }

        public CUSettings()
        {
            Init(0);
        }

        //bool operator ==(int r);
        //bool operator !=(int r);
        private void Init(int n)
        {
            this.n = n;
            isSup = new bool[16];
            isInf = new bool[16];
            Sup = new float[16];
            Inf = new float[16];

            for (byte i = 0; i < 16; Sup[i] = 0, Inf[i] = 0, isSup[i] = false, isInf[i] = false, i++) ;
        }

        public static bool operator ==(CUSettings settings, int r)
        {
            return settings.n == r;
        }

        public static bool operator !=(CUSettings settings, int r)
        {
            return settings.n != r;
        }
    }

    public class CalibrationData
    {
        //data relative to the calibration of one channel
        private int channel;                            //the channel to calibrate. 256 means an non-valid object
        public float temperature;                       //the reference temperature

        public int Channel
        {
            get { return channel; }
            set { if (value > 0 && value <= 16) channel = value-1; }
        }

        //The following functions interact with CalibrationData as the channels are numbered starting from 1
        //so if you want to init the number of channel to zero you have to call CalibrationData(1)
        //the same for the operator== and operator!=.
        //For these functions any value outside the 1-16 inclusive range act as a non-valid object
        public CalibrationData()
        {
            channel = 256;
        }

        public CalibrationData(int n)
        {
            if (n <= 0 || n > 16)
		        channel = 256;
	        else
		        channel = n-1;
        }

        public static bool operator ==( CalibrationData cd, int r)
        {
            if (r <= 0 || r > 16)
            {
                if (cd.channel == 256) return true;
                else return false;
            }
            else
            {
                return cd.channel == (r - 1);
            }
        }

        public static bool operator !=(CalibrationData cd, int r)
        {
            if (r <= 0 || r > 16)
            {
                if (cd.channel != 256) return true;
                else return false;
            }
            else
            {
                return cd.channel != (r - 1);
            }
        }

        
        //bool operator !=(int r);
    }

    public class T
    {
        private int n;
        public float[] temps;

        public int N
        {
            get { return n; }
            set { if (value > 0 && value <= 16) n = value; }
        }

        public T(int n)
        {
            if (n > 0 && n <= 16) this.n = n;
            else this.n = 0;
            temps = new float[16];
        }

        public T()
        {
            this.n = 0;
            temps = new float[16];
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
