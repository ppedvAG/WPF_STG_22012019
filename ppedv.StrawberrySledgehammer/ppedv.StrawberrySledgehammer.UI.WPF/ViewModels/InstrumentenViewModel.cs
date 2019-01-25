using ppedv.StrawberrySledgehammer.Logic;
using ppedv.StrawberrySledgehammer.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ppedv.StrawberrySledgehammer.UI.WPF.ViewModels
{
    public class InstrumentenViewModel : BaseViewModel
    {
        Core core = new Core();


        public ObservableCollection<Instrument> Instrumente { get; set; } = new ObservableCollection<Instrument>();

        public ObservableCollection<Material> Materialien { get; set; } = new ObservableCollection<Material>();

        private Instrument _selectedInstrument;

        public Instrument SelectedInstrument
        {
            get { return _selectedInstrument; }
            set
            {
                _selectedInstrument = value;

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedInstrument"));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedInstrument)));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Namestextlänge)));
                IHaveChanged();
                OnPropChanged(nameof(Namestextlänge));
                OnPropChanged(nameof(Name));

            }
        }


        public string Name
        {
            get => SelectedInstrument?.Name;
            set
            {
                if (SelectedInstrument != null)
                    SelectedInstrument.Name = value;
                //IHaveChanged();
                //OnPropChanged(nameof(Namestextlänge));
                OnPropChanged(nameof(Instrumente));
                OnPropChanged("");
                OnPropChanged(nameof(SelectedInstrument));

            }
        }
        public int Namestextlänge
        {
            get
            {
                if (SelectedInstrument == null)
                    return -1;
                return SelectedInstrument.Name.Length;
            }
        }


        public ICommand SaveCommand { get; set; }
        public ICommand SaveCommandInCool { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DelteCommand { get; set; }


        public InstrumentenViewModel()
        {
            core.Repository.GetAll<Instrument>().ToList().ForEach(x => Instrumente.Add(x));
            Enum.GetValues(typeof(Material)).Cast<Material>().ToList().ForEach(x => Materialien.Add(x));

            SaveCommand = new SaveCommand(core);
            SaveCommandInCool = new RelayCommand(o => core.Repository.SaveAll());
            NewCommand = new RelayCommand(UserWantsToAddNewInstrument);
            DelteCommand = new RelayCommand(UserWantsToDeleteSelectedInstrument, o => SelectedInstrument != null);
        }

        private void UserWantsToDeleteSelectedInstrument(object obj)
        {
            if (SelectedInstrument != null)
            {
                core.Repository.Delete(SelectedInstrument);
                Instrumente.Remove(SelectedInstrument);
            }
        }

        private void UserWantsToAddNewInstrument(object obj)
        {
            var i = new Instrument() { Name = "NEU NEU NEU" };
            core.Repository.Add(i);
            Instrumente.Add(i);
            SelectedInstrument = i;
        }
    }
}
