using Elisi01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elisi01
{
    public interface IView
    {
        string FilePath { get; }
        void LoadMeasures(IEnumerable<LevelGaugeMeasure> measures);
        event Action RaiseLoadMeasures;
        void Run();
        void SetFileError(string message);
        void RaiseSomeException(Exception ex);
    }
}
