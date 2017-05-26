using System;
using System.IO;
using System.Security;

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
            try
            {
                if (string.IsNullOrWhiteSpace(_view.FilePath))
                {
                    _view.SetFileError("Выберите файл");
                    return;
                }
                    
                _view.LoadMeasures(await _project.GetMeasuresAsync(_view.FilePath));
            }
            catch (FileNotFoundException)
            {
                _view.SetFileError("Файл не найден");
            }
            catch(DirectoryNotFoundException)
            {
                _view.SetFileError("Файл не найден");
            }
            catch(SecurityException)
            {
                _view.SetFileError("Нет доступа к файлу");
            }
            catch(Exception ex)
            {
                _view.RaiseSomeException(ex);
            }
        }

        public void Run()
        {
            _view.Run();
        }
    }
}
