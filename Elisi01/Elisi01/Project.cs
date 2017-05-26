using System.Collections.Generic;
using System.Threading.Tasks;
using Elisi01.Models;
using System.IO;
using System.Xml.Serialization;

namespace Elisi01
{
    public class Project : IProject
    {
        public IEnumerable<LevelGaugeMeasure> GetMeasures(string filePath)
        {
            filePath = Path.GetFullPath(filePath);
            IEnumerable<LevelGaugeMeasure> res;
            var xml = new XmlSerializer(typeof(LevelGaugeMeasure[]), new XmlRootAttribute("measurement"));
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                res = (IEnumerable<LevelGaugeMeasure>)xml.Deserialize(stream);
            }
            return res;
        }

        public async Task<IEnumerable<LevelGaugeMeasure>> GetMeasuresAsync(string filePath)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return GetMeasures(filePath);
                }
                catch
                {
                    throw;
                }
            });
        }
    }
}
