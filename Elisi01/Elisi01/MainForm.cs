using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elisi01.Models;

namespace Elisi01
{
    public partial class MainForm : Form, IView, INotifyPropertyChanged
    {
        string _filePath;
        TimeSpan? _sumTime;

        public MainForm()
        {
            InitializeComponent();
            txtFilePath.DataBindings.Add(new Binding("Text", this, nameof(FilePath)));
            var timeSpanBinding = new Binding("Text", this, nameof(SumTime));
            timeSpanBinding.Format += TimeSpanBinding_Format;
            lblSum.DataBindings.Add(timeSpanBinding);
        }

        private void TimeSpanBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value == null)
                return;

            e.Value = $"Общее время превышения максимума - {((TimeSpan)e.Value).ToString(@"hh\:mm\:ss")}";
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged(nameof(FilePath));
                }
            }
        }

        public TimeSpan? SumTime
        {
            get
            {
                return _sumTime;
            }

            private set
            {
                if (_sumTime != value)
                {
                    _sumTime = value;
                    OnPropertyChanged(nameof(SumTime));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action RaiseLoadMeasures;

        public void LoadMeasures(IEnumerable<LevelGaugeMeasure> measures)
        {
            var sum = new TimeSpan();
            lstMeasures.Items.Clear();
            foreach (var measure in measures.Where(m => m.IsMaxValue))
            {
                lstMeasures.Items.Add(new ListViewItem(new string[] { measure.TS.ToString(), measure.Meters.ToString() }));
                sum = sum.Add(new TimeSpan(0, 0, 0, 10));
            }
            SumTime = sum;
        }

        public void Run()
        {
            Application.Run(this);
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RaiseLoadMeasures?.Invoke();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dlgXml.FileName = FilePath;
            if (dlgXml.ShowDialog() != DialogResult.OK)
                return;

            FilePath = dlgXml.FileName;
        }
    }
}
