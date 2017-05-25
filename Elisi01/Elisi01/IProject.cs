using Elisi01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elisi01
{
    public interface IProject
    {
        IEnumerable<LevelGaugeMeasure> GetMeasures(string filePath);
        Task<IEnumerable<LevelGaugeMeasure>> GetMeasuresAsync(string filePath);
    }
}
