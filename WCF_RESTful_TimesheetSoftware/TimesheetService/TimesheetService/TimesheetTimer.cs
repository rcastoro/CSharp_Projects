using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;

namespace TimesheetService
{
    public static class TimesheetTimer
    {
        static int _timerInterval = 5000;
        static Timer _timer;
        static List<DateTime> _timerResults;

        public static int TimerInterval
        {
            get
            {
                return _timerInterval;
            }
            set
            {
                _timerInterval = value;
            }
        }

        public static List<DateTime> DateList
        {
            get
            {
                if (_timerResults == null)
                {
                    Start();
                }
                return _timerResults;
            }
        }

        static void Start()
        {
            _timerResults = new List<DateTime>();
            _timer = new Timer(_timerInterval);

            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true;
        }

        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timerResults.Add(DateTime.Now);
        }

    }
}