using System;
using System.Xml.Serialization;

namespace Elisi01.Models
{
    [XmlType(TypeName = "measure")]
    public class LevelGaugeMeasure
    {
        [XmlIgnore]
        public DateTime TS
        {
            get
            {
                DateTime res;
                if (DateTime.TryParse(TimeStamp, out res))
                    return res;
                else
                    throw new InvalidOperationException("Измерение имеет недопустимый формат даты");
            }
            set
            {
                TimeStamp = value.ToString("dd.MM.yyyy hh:mm:ss");
            }
        }

        [XmlIgnore]
        public double Meters
        {
            get
            {
                return (double)Millimeters / 1000;
            }
        }

        [XmlElement(ElementName = "value")]
        public int Millimeters { get; set; }

        [XmlElement(ElementName = "isMaxValue")]
        public bool IsMaxValue { get; set; }

        [XmlElement(ElementName = "timestamp")]
        public string TimeStamp { get; set; }
    }
}
