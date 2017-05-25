using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elisi01
{
    public class Presenter
    {
        IProject _project;
        IView _view;

        public Presenter(IProject project, IView view)
        {
            _project = project;
            _view = view;
            _view.RaiseLoadMeasures += _view_RaiseLoadMeasures;
        }

        private async void _view_RaiseLoadMeasures()
        {
            _view.LoadMeasures(await _project.GetMeasuresAsync(_view.FilePath));
        }

        public void Run()
        {
            _view.Run();
        }
    }
}
